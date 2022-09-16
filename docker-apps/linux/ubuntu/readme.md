# Ubuntu

### This first exercise shows how to containerise a very simple bit of command line code that runs in an Ubuntu Linux container.
### 

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

### Here is the Docker code that you have used to build a container image:

```
FROM ubuntu
CMD while sleep 5; do echo ":-) Hi " $NAME ". My name is: "$(hostname) ". I am a running container! The time is: " $(date); done
```

#### How long does it take?

5. Build the image again. 

#### How long does it take now - why?

6. Now run the local image in a container hosted in a Linux VM hosted on your laptop, limiting the memory to 200MB and CPU to 1/4. Don't forget to edit your name. Note: env means pass in an external environmental variable into the container (your name). 
```
docker container run --env NAME=my-name-here --name ubuntu --rm -m 200M  --cpus=0.25  node4demo/ubuntu-test:my-name-here
```

#### if you receive error: The container name "/ubuntu" is already in use by container "0b2.. then run 

```
docker ps 

docker stop ubuntu
```

7. This time, run the local image again - in the background, continue as root (admin) user, adding a networking capability. 

```
docker container run --detach --tty --user=0 --cap-add MAC_ADMIN --env NAME=my-name-here --name ubuntu --rm  node4demo/ubuntu-test:my-name-here sleep 3600
```

7b. Now run docker ps in another terminal to see if the container is still running. View the ContainerID

```
docker ps
```

8. Use the ContainerID to access and run a shell (command) prompt in the container. With a few Linux commands: navigate the file structure, determine the running account. Try and install Curl command into the container - will this work as non root user? If not run again as root user. What happens to the upgrade and Curl after the container is stopped - where are they? 

```
docker exec -it <CONTAINERID> sh

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

docker history node4demo/ubuntu-test:my-name-here
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

### Congratulations....now let's containerise our first web application (PHP).

21. In VS Code: File..Open Folder ..docker-apps\linux\php
