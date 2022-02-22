# ASP.NET. .Net Framework (Windows)

1. Switch to run Windows Containers by right clicking Docker (Whale) icon in system tray - Switch to Windows containers 

### Containers feature is disabled. Enable it using the PowerShell script (in an administrative PowerShell) and restart your computer before using Docker Desktop: 

```
Enable-WindowsOptionalFeature -Online -FeatureName $("Microsoft-Hyper-V", "Containers") -All
```

3. open a new terminal and first download base image - and go and get a coffee

```
docker pull mcr.microsoft.com/dotnet/framework/aspnet:4.8
```

4. now build the image
```
docker image build . -t node4demo/webforms:v3 -f ./webformsbasic/Dockerfile
```

### If you receive this error: 'This error may indicate that the docker daemon is not running.' - switch to Windows Containers

5. Look inside the container at the folder structure

```
docker run -it --rm --entrypoint powershell --name webforms node4demo/webforms:v3 ls 
```

6. Run the Webforms app

```
docker run -it --rm -p 5014:80 --name webforms node4demo/webforms:v3
```

6. run in browser

*http://localhost:5014*


