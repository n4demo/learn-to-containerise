# ASP.NET Core v3 (.NET Core)
### This exercise shows how to containerise a very simple .NET web application using VS Code and Docker Desktop and uploading to DockerHub.  

1. Important - Set your VS Code folder or terminal current directory so that the DOCKER file is in the current directory.
2. create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW and paste in the docker image build code below and edit your name. 
- run the 2 base images to download the images from MS imgage registry
- node4demo refers to container registry account or owner that already exists
- aspnetapp:my-name refers to the application 
- my-name-here is a tag for this application. 
- The . (dot) refers to the current directory (assuming the current directory has th app code and Docker file

```
docker run mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim dotnet --list-runtimes

docker run mcr.microsoft.com/dotnet/core/sdk:3.0-buster --list-runtimes

docker image build -t node4demo/aspnetapp:my-name -f ./aspnetapp/Dockerfile . 

docker image ls node4demo/aspnetapp:my-name
```

3. Use 'docker scan' to run Snyk tests against images to find any critical vulnerabilities and learn how to fix them.

```
docker scan node4demo/aspnetapp:my-name
```

8. run the local image with 500MB memory 

```
docker run -it -m 500M  --rm -p 85:8080 --name aspnetapp node4demo/aspnetapp:my-name
```

9. run in browser

```
http://localhost:85*
```

10. Review the logs

```
docker logs aspnetapp*
```

11. See what else is running a process

```
docker ps

docker stop aspnetapp*
```

## Review the Docker file. How many images does this file create along the way to finally build the required image?

12. login to DockerHub

```
docker login --username node4demo -p my-password
```

13. push the image to docker hub

```
docker push node4demo/aspnetapp:my-name
```

