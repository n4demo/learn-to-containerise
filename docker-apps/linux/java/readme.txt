# This exercise shows how to containerise a very simple bit of code that runs in Ubuntu Linux. 

# ** Important - VS code folder on LHS must be set to JAVA and set your name in the image below!!! ******************

# create the local image which is stored on your laptop 
docker image build -t cdwuk/java-my-name-here .

# run the local image in a container hosted in a Linux VM hosted on your laptop
docker run -it --rm  --name java-hw cdwuk/java-my-name-here

#login to DockerHub using password: Qwerty===1
docker login --username cdwuk

# push the image to docker hub
docker push cdwuk/java-my-name-here
