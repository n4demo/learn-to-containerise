# Ubuntu

### This first exercise shows how to containerise a very simple bit of code that runs in Ubuntu Linux. 

1. In VS Code File..Open Folder - navigate to docker-apps/linux/Ubuntu folder, so that the DOCKER file is in the current directory. 
2. Open a new VS Code BASH Terminal Window  
3. Confirm the terminal current directory is in the root of the Ubuntu folder
4. Paste in the docker image build code below into the Terminal window, edit to your actual name and then tap enter key.

- node4demo refers to container registry account or owner that already exists
- ubuntu-test refers to the application 
- my-name-here is a tag for this application. 
- . (dot) refers to the current directory (assuming the current directory has the app code and Docker file)

*docker image build . -t node4demo/ubuntu-test:my-name-here -f Dockerfile*

### How long does it take?

5. Build the image again. 

### How long does it take now - why?

6. run the local image in a container hosted in a Linux VM hosted on your laptop. Don't forget to edit your name.

*docker container run --env NAME=my-name-here --name ubuntu-container --rm  node4demo/ubuntu-test:my-name-here* 

7. Review the Dockerfile on LHS and try and understand what it is doing. What is the base image specified?

8. Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them.

*docker scan node4demo/ubuntu-test:my-name-here*

### how many vulnerabilities did it show?

9. Edit the Docker file to use a different base image: FROM ubuntu:rolling 
10. re-run the build
11. re-run the image scan 

### how many vulnerabilities did it show now. does it have any vulnerabilities?

### how often should we re-build an image that is in production?

12. show all containers running or not

*docker ps -a*

13. see if the container is still running or not

*docker stop ubuntu-container* 

14. login to DockerHub

*docker login --username node4demo -p <password>*

15. push the image to docker hub

*docker push node4demo/ubuntu-test:my-name-here*

16. now view in DockerHub in browser by signing in as: node4demo 

https://hub.docker.com

17. drill into app to see the tags

### Congratulations.. that was easy..now let's containerise our first web application (PHP).

18. In VS Code: File..Open Folder ..docker-apps\linux\php
19. go to https://github.com/n4demo/learn-to-containerise/blob/main/docker-apps/linux/php/readme.md