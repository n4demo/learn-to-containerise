# Audience
Developers, Solution Architects


# Migrating web applications into Docker images
The purpose of this training course is to remove the magic associated with containerising an application, running and deploying to a container registry.

## Prerequisites

* Gain admin rights to your laptop
* Download and install GIT onto your laptop  (optional)
* Download and install VS Code onto your laptop  
* Download and install Docker Desktop onto your laptop  
* Double click on fve.reg to allow you to switch between running Linux and Windows containers

A possible rebot may be beneficial.  

## Check your Prerequisites
run a command prompt as admin and type:

* git version  
* docker version 
* Double click on fve.reg  

A possible rebot may be beneficial. 

## Clone repo code to laptop folder 
* create a new folder e.g: c:\docker
* using Windows explorer navigate to this folder
* either, right click for a Bash Git command and paste in: git clone https://github.com/n4demo/learn-to-containerise
* or, download the zip file, extract and copy to your above floder

## (Optional) to save download time in lab
To download base images\layers (on wifi) to speed things up when building Docker images, open a terminal in VS Code or command prompt and run:
* docker pull ubuntu  
* docker pull python  
* docker pull python:3.6  
* docker pull python:3.6-alpine  
* docker pull php:apache  
* docker pull mcr.microsoft.com/dotnet/core/aspnet:3.0  
* docker pull mcr.microsoft.com/dotnet/core/sdk:3.0  
* docker pull microsoft/aspnet:4.7.2-windowsservercore-1803  

## Start lab
* In VS Code File...Open Folder.. c:\docker\docker-root\docker-apps\linux\ubuntu
* follow the readme.md for instructions



