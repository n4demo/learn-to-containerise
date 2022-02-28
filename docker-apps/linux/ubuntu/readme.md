# Ubuntu

### This first exercise shows how to containerise a very simple bit of code that runs in Ubuntu Linux. 

1. In VS Code File..Open Folder - navigate to docker-apps/linux/Ubuntu folder, so that the DOCKER file is in the current directory.
2. Right click on the readme.md file from VS Exploer (LHS) and click Open Preview
3. Open a new VS Code BASH Terminal Window and maximize size 
4. Confirm the terminal current directory is in the root of the Ubuntu folder
5. Paste in the 'docker image build' code into the Terminal window, edit to your actual name and then tap enter key.

- node4demo refers to container registry account or owner that already exists
- ubuntu-test refers to the application 
- my-name-here is a tag for this application. 
- . (dot) refers to the current directory (assuming the current directory has the app code and Docker file)

```
docker image build . -t node4demo/ubuntu-test:my-name-here -f Dockerfile
```

#### If you receive: docker: image operating system "linux" cannot be used on this platform. Switch Docker to use Linux containers

### Here is the Docker code that you have just built

```
FROM ubuntu
CMD echo "hi "$NAME", you have been succesful in containerising and running this simple Ubuntu application.\n" 
```

#### How long does it take?

5. Build the image again. 

#### How long does it take now - why?

6. run the local image in a container hosted in a Linux VM hosted on your laptop. Don't forget to edit your name.

```
docker container run --env NAME=my-name-here --name ubuntu-container --rm  node4demo/ubuntu-test:my-name-here
```

#### if you receive error: The container name "/ubuntu-container" is already in use by container "0b2.. then run 

```
docker ps

docker stop ubuntu-container
```

7. run the local image again - and keep it running. 

```
docker container run --detach --tty --env NAME=my-name-here --name ubuntu-container --rm  node4demo/ubuntu-test:my-name-here sleep infinity
```

7b. Now run docker ps again to see if the container is still running. View the ContainerID

```
docker ps
```

8. Use the ContainerID to access and run a shell prompt in the container. With a few Linux commands, see how easy (and insecure) it is to navigate. Determine the running account. Install utilities into the container. What happens to the utilities after the container is stopped - where are they?

```
docker exec --interactive -t ContainerID sh

ls

whoami

apt update && apt upgrade && apt install curl

curl --version

curl localhost

curl google.com

exit
```

9. Stop the container

```
docker stop ubuntu-container
```
10. Review the Dockerfile on LHS and try and understand what it is doing. What is the base image specified?

11. Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them.

```
docker scan node4demo/ubuntu-test:my-name-here
```
#### how many vulnerabilities did it show?

12. Edit the Docker file to use a different base image: FROM ubuntu:rolling 
13. re-run the build
14. re-run the image scan 

#### how many vulnerabilities did it show now. does it have any vulnerabilities?

#### how often should we re-build an image that is in production?

15. show all containers running or not

```
docker ps -a
```

16. see if the container is still running or not

```
docker stop ubuntu-container
```

17. login to DockerHub

```
docker login --username node4demo -p my-password
```

18. push the image to docker hub

```
docker push node4demo/ubuntu-test:my-name-here
```

19. now view in DockerHub in browser by signing in as: node4demo 

https://hub.docker.com


20. drill into app to see the tags

### Congratulations.. that was easy..now let's containerise our first web application (PHP).

21. In VS Code: File..Open Folder ..docker-apps\linux\php
