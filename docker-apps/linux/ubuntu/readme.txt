# This first exercise shows how to containerise a very simple bit of code that runs in Ubuntu Linux. 

# ******** Important - Set your terminal current directory so that the DOCKER file is in the current directory. Set your name in the image below!!! ******************

# create the local image. sixdegreesuk refers to the repository, ubuntu-test refers to the application and my-name-here is the tag for this application
docker image build -t sixdegreesuk/ubuntu-test:my-name-here .

# run the local image in a container hosted in a Linux VM hosted on your laptop

docker container run --env NAME=my-name-here --name ubuntu-container --rm -i -t sixdegreesuk/ubuntu-test:my-name-here 

# have a look at the Dockerfile on LHS and try and understand what it is doing

# show all containers running or not
docker ps -a

# see if the container is still running or not
docker stop ubuntu-container 

#login to DockerHub using password: <password>
docker login --username sixdegreesuk

# push the image to docker hub
docker push sixdegreesuk/ubuntu-test:my-name-here

# now view in DockerHub in browser by signing in as: sixdegreesuk  password: <password>
https://hub.docker.com

# drill into app to see the tags