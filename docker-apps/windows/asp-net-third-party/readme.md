# ASP.NET. .Net Framework (Windows)

1. Switch to run Windows Containers by right clicking Docker (Whale) icon in system tray - Switch to Windows containers 

3. open a new terminal and download base images - and go and get a coffee

```
docker pull mcr.microsoft.com/dotnet/framework/sdk:4.8
docker pull mcr.microsoft.com/dotnet/framework/aspnet:4.8
c:
```

4. now build the image
```
docker image build . -t node4demo/web:test -f ./Dockerfile
```

### If you receive this error: 'This error may indicate that the docker daemon is not running.' - switch to Windows Containers

5. run the container and gain a command prompt
6. User dir to view file structure

```
docker run -it --rm --entrypoint powershell --name web-test node4demo/web:test cmd 
```

```
dir C:\
```

```
exit
```

7. Run the web app

```
docker run -it -d --rm -p 5016:80 --name web node4demo/web:test
```

8. Obtain the ContainerID

```
docker ps -a 
```

9. Gain a command shell into the running container and list the directories and logs

```
docker exec -it  ContainerID cmd

dir

curl localhost:5016/
```

10. run in browser

*http://localhost:5016*


