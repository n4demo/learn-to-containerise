# Ubuntu

### This first exercise shows how to containerise a very simple bit of code that runs in Ubuntu Linux. 

## Important - Set your VS Code folder so that the DOCKER file is in the current directory. Set your name in the image below.

### create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW  
### Confirm the terminal current directory is in the root of the Ubuntu folder
### paste in the docker image build code below and hit enter key.
- node4demo refers to container registry account or owner that already exists
- ubuntu-test refers to the application 
- my-name-here is a tag for this application. 
- The . (dot) refers to the current directory (assuming the current directory has the app code and Docker file)

docker image build . -t node4demo/ubuntu-test:my-name-here -f Dockerfile

### How long does it take?

### Build the image again. How long does it take now - why?

### run the local image in a container hosted in a Linux VM hosted on your laptop

docker container run --env NAME=my-name-here --name ubuntu-container --rm  node4demo/ubuntu-test:my-name-here 

### have a look at the Dockerfile on LHS and try and understand what it is doing

### Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them
docker scan node4demo/ubuntu-test:my-name-here

### Edit the Docker file to use: FROM ubuntu:rolling 
### re-run the build
### re-run the image scan 

### show all containers running or not
docker ps -a

### see if the container is still running or not
docker stop ubuntu-container 

### login to DockerHub
docker login --username node4demo -p <password>

### push the image to docker hub
docker push node4demo/ubuntu-test:my-name-here

### now view in DockerHub in browser by signing in as: node4demo 
https://hub.docker.com

### drill into app to see the tags
