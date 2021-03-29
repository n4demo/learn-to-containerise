# This exercise shows how to containerise a very simple bit of code that runs in Ubuntu Linux. 

# ** Important - VS code folder on LHS must be set to UBUNTU and set your name in the image below!!! ******************

# create the local image. cdwuk refers to the repository, ubuntu-test refers to the application and my-name-here is the tag for this application
docker image build -t cdwuk/ubuntu-test:my-name-here .

# run the local image in a container hosted in a Linux VM hosted on your laptop
docker container run --name ubuntu-container --rm -i -t cdwuk/ubuntu-test:my-name-here

# have a look at the Dockerfile on LHS and try and understand what it is doing

# show all containers running or not
docker ps -a

# see if the container is still running or not
docker stop ubuntu-container 

#login to DockerHub using password: Qwerty===1
docker login --username cdwuk

# push the image to docker hub
docker push cdwuk/ubuntu-test:my-name-here

# now view in DockerHub in browser by signing in as: cdwuk  password: Qwerty===1
https://hub.docker.com

# drill into app to see the tags