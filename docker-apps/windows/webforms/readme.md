# ASP.NET. .Net Framework (Windows)

## This example shows how published (unchanged) ASP.NET Webforms files can be copied into the default wwwroot folder in a container and executed.

1. Switch to run Windows Containers by right clicking Docker (Whale) icon in system tray - Switch to Windows containers 

### Containers feature is disabled. For older versions of Windows that predates WSL2, enable it using the PowerShell script (in an administrative PowerShell) and restart your computer before using Docker Desktop: 

```
Enable-WindowsOptionalFeature -Online -FeatureName $("Microsoft-Hyper-V", "Containers") -All
```

3. open a new terminal and first download base image - and go and get a coffee

```
docker pull mcr.microsoft.com/dotnet/framework/aspnet:4.8
```

4. now build the image
```
docker image build . -t node4demo/webforms:v3
```

### If you receive this error: 'This error may indicate that the docker daemon is not running.' - switch to Windows Containers

5. run the container and gain a command prompt
6. User dir to view file structure

```
docker run -it --rm --entrypoint powershell --name webforms-powershell node4demo/webforms:v3 cmd 

dir inetpub\wwwroot 

exit
```

7. Run the Webforms web app

```
docker run -it -d --rm -p 5014:80 --name webforms node4demo/webforms:v3
```

8. Obtain the ContainerID

```
docker ps -a 
```

9. Gain a command shell into the running container and list the directories and logs

```
docker exec -it  ContainerID cmd

dir

curl localhost/index.html

docker logs webforms
```

10. run in browser

*http://localhost:5014*


