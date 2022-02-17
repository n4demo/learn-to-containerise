# Python Command Line App
### This exercise shows how to containerise a very simple bit of code that runs in Python on Alpine Linux (very compact Linux distribution). 

1. Important - Set your VS Code folder or terminal current directory so that the DOCKER file is in the current directory.
### e.g docker image build . -t node4demo/python-basic:fred-bloggs 

### create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW and paste in the docker image build code below and edit your name. 
- node4demo refers to container registry account or owner that already exists
- php refers to the application 
- my-name-here is a tag for this application. 
- The . (dot) refers to the current directory (assuming the current directory has th app code and Docker file

*docker image build . -t node4demo/python-basic:my-name-here*

### to clear your screen type:     clear 

### add 2 additional tags to the same image. Note that we include the version as part of the tag
*docker build -t node4demo/python-basic:v1.0.0 -t node4demo/python-basic:latest .*

### run the local image in a Linux VM hosted on your laptop inside Docker desktop
docker container run --name python_basic --rm -i -t node4demo/python-basic:my-name-here

### show all containers running or not. Is it still running?
docker ps -a

### show logs for this container - why did it fail?
docker logs -f node4demo/python-basic:my-name-here

### login to DockerHub
docker login --username node4demo -p <password>

### push the image to docker hub
docker push node4demo/python-basic:my-name-here

### now view in DockerHub in browser by signing in as: node4demo  password: <password>
https://hub.docker.com

### drill into app to see the tags