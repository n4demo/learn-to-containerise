# ASP.NET. .Net Framework (Windows)

1. Switch to run Windows Containers by right clicking Docker (Whale) icon in system tray - Switch to Windows containers 

### Containers feature is disabled. For older versions of Windows that predates WSL2, enable it using the PowerShell script (in an administrative PowerShell) and restart your computer before using Docker Desktop: 

```
Enable-WindowsOptionalFeature -Online -FeatureName $("Microsoft-Hyper-V", "Containers") -All
```

3. open a new terminal and download base images - and go and get a coffee

```
docker pull mcr.microsoft.com/dotnet/framework/sdk:4.8

docker pull mcr.microsoft.com/dotnet/framework/aspnet:4.8
```

4. now build the image
```
docker image build . -t node4demo/wingtips:test -f ./c#/wingtiptoys/Dockerfile
```

### If you receive this error: 'This error may indicate that the docker daemon is not running.' - switch to Windows Containers

5. run the container and gain a command prompt
6. User dir to view file structure

```
docker run -it --rm --entrypoint powershell --name wingtips-powershell node4demo/wingtips:test cmd 

dir C:\web-app

exit
```

7. Run the Webforms web app

```
docker run -it -d --rm -p 5015:80 --name wingtips node4demo/wingtips:test
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

*http://localhost:5015*


