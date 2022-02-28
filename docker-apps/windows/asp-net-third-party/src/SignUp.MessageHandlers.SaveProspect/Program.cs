﻿using System;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Configuration;
using NATS.Client;
using Prometheus;
using SignUp.Core;
using SignUp.Entities;
using SignUp.Messaging;
using SignUp.Messaging.Messages.Events;
using SignUp.Model;

namespace SignUp.MessageHandlers.SaveProspect
{
    class Program
    {
        private static ManualResetEvent _ResetEvent = new ManualResetEvent(false);

        private const string QUEUE_GROUP = "save-handler";
        private const string HANDLER_NAME ="SaveProspect";

        private static Gauge _InfoGauge;
        private static Counter _EventCounter;

        static void Main(string[] args)
        {
            if (Config.Current.GetValue<bool>("Metrics:Server:Enabled"))
            {
                StartMetricServer();
                _InfoGauge = Metrics.CreateGauge("app_info", "Application info", "netfx_version", "version");
                _InfoGauge.Labels(AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName, "20.11").Set(1);
                if (Config.Current.GetValue<bool>("Metrics:Application:Enabled"))
                {
                    _EventCounter = Metrics.CreateCounter("message_handler_events", "Event count", "handler", "status");
                }
            }

            var queue = new MessageQueue(Config.Current);

            Console.WriteLine($"Connecting to message queue url: {Config.Current["MessageQueue:Url"]}");
            try 
            {
                using (var connection = queue.CreateConnection())
                {
                    var subscription = connection.SubscribeAsync(ProspectSignedUpEvent.MessageSubject, QUEUE_GROUP);
                    subscription.MessageHandler += SaveProspect;
                    subscription.Start();
                    Console.WriteLine($"Listening on subject: {ProspectSignedUpEvent.MessageSubject}, queue: {QUEUE_GROUP}"); 
                    _ResetEvent.WaitOne();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot connect to message queue. Doing nothing."); 
                _ResetEvent.WaitOne();
            }
        }

        private static void SaveProspect(object sender, MsgHandlerEventArgs e)
        {
            if (_EventCounter != null)
            {
                _EventCounter.Labels(HANDLER_NAME, "processed").Inc();
            }

            Console.WriteLine($"Received message, subject: {e.Message.Subject}");
            var eventMessage = MessageHelper.FromData<ProspectSignedUpEvent>(e.Message.Data);
            Console.WriteLine($"Saving new prospect, signed up at: {eventMessage.SignedUpAt}; event ID: {eventMessage.CorrelationId}");

            var prospect = eventMessage.Prospect;
            try
            {
                SaveProspect(prospect);
                Console.WriteLine($"Prospect saved. Prospect ID: {eventMessage.Prospect.ProspectId}; event ID: {eventMessage.CorrelationId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Save prospect FAILED, email address: {prospect.EmailAddress}, ex: {ex}");
                if (_EventCounter != null)
                {
                    _EventCounter.Labels(HANDLER_NAME, "failed").Inc();
                }
            }
        }

        private static void SaveProspect(Prospect prospect)
        {
            using (var context = new SignUpContext())
            {
                //reload child objects:
                prospect.Country = context.Countries.Single(x => x.CountryCode == prospect.Country.CountryCode);
                prospect.Role = context.Roles.Single(x => x.RoleCode == prospect.Role.RoleCode);

                context.Prospects.Add(prospect);
                context.SaveChanges();
            }
        }

        private static void StartMetricServer()
        {
            var metricsPort = Config.Current.GetValue<int>("Metrics:Server:Port");
            var server = new MetricServer(metricsPort);
            server.Start();
            Console.WriteLine($"Metrics server listening on port: {metricsPort}");
        }
    }
}