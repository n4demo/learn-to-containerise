# This exercise shows how to containerise a very simple bit of code that runs in Python on Alpine Linux (very compact Linux distribution). 

# ** Important - VS code folder on LHS must be set to PYTHON-BASIC and set your name in the image below!!! ******************

# ***** build and store a local copy of image including a tag with my own name. The cdwuk refers to the Docker Hub image repository that we will push this to.
# *****  -t refers to tag and the . (dot) tells Docker where to find the files to build (current directory)
docker image build -t cdwuk/python-basic:my-name-here .

# to clear your screen type:     clear 

# add 2 additional tags to the same image. Note that we include the version as part of the tag
docker build -t cdwuk/python-basic:v1.0.0 -t cdwuk/python-basic:latest .

# run the local image in a Linux VM hosted on your laptop inside Docker desktop
docker container run --name python_basic --rm -i -t cdwuk/python-basic:my-name-here

# show all containers running or not. Is it still running?
docker ps -a

## show logs for this container - why did it fail?
docker logs -f cdwuk/python-basic:my-name-here

#login to DockerHub using password: Qwerty===1
docker login --username cdwuk

# push the image to docker hub
docker push cdwuk/python-basic:my-name-here

# now view in DockerHub in browser by signing in as: cdwuk  password: Qwerty===1
https://hub.docker.com

# drill into app to see the tags