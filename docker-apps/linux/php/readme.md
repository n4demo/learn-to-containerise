
# PHP
## This exercise shows how to containerise a very simple PHP Apache web application using VS Code terminal with Docker Desktop, then uploading to DockerHub.  

1. In VS Code File..Open Folder - navigate to docker-apps/linux/php folder, so that the DOCKER file is in the current directory. Open readme.md in Preview.
2. create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW and paste in the docker image build code and edit your name. 

- node4demo refers to container registry account or owner that already exists
- php-app refers to the application 
- my-name-here is a tag for this application. 
- . (dot) refers to the current directory (assuming the current directory has th app code and Docker file

```
docker image build . -t node4demo/php-app:my-name-here
```

3. add additional tags to the same image

```
docker image build . -t node4demo/php-app:liverpool -t node4demo/php-app:1.0.0
```

4. Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them.

```
docker scan node4demo/php-app:liverpool
```

5. how many vulnerabilities does it have? Is there a base image with no vulnerabilities?

6. run the local image with 200MB memory, 0.25 of CPU and map your laptops port 5002 to port 80 on the container, 

```
docker container run -m 200M  --cpus=0.25 -it --rm  --name php-app -p 5002:80 node4demo/php-app:liverpool
```

7. From a new VS BASH Terminal run the code:

```
docker container list

docker container logs php-app
```

8. run in browser

http://localhost:5002


9. login to DockerHub

```
docker login --username node4demo -p my-password
```

### Upload to Docker Container Registry

10. push the image to docker hub container registry

```
docker push node4demo/php-app:my-name-here
```
```
docker push node4demo/php-app:liverpool
```
11. Question: Why does it take so very little time to upload to DockerHub?

12. If available - login to GitHub container registry (GHCR) or just review code

```
docker login ghcr.io -u n4demo -p my-password

docker build . -t ghcr.io/n4demo/php-app:latest

docker container run -m 200M -it --rm  --name php -p 5003:80 ghcr.io/n4demo/php-app:latest

docker push ghcr.io/n4demo/php-app:latest
```

13. Delete all containers

```
docker rm $(docker ps -a -q)
```

14. Delete all images

```
docker rmi $(docker images -q)
```

### Congratulations.. now let's containerise our first python application.

15. In VS Code: File..Open Folder ..docker-apps\linux\python-basic

