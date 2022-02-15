### This exercise shows how to containerise a very simple bit of code that runs in Python on Alpine Linux (very compact Linux distribution). 

### ******** Important - Set your terminal current directory so that the DOCKER file is in the current directory. Set your name in the image below!!! ******************

### ***** build and store a local copy of image including a tag with my own name. The node4demo refers to the Docker Hub image repository that we will push this to.
### *****  -t refers to tag and the . (dot) tells Docker where to find the files to build (current directory)
docker image build -t node4demo/python-basic:my-name-here .

### to clear your screen type:     clear 

### add 2 additional tags to the same image. Note that we include the version as part of the tag
docker build -t node4demo/python-basic:v1.0.0 -t node4demo/python-basic:latest .

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