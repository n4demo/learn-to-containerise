# This exercise shows how to containerise a very simple bit of code that runs in Ubuntu Linux. 

# ******** Important - Set your terminal current directory so that the DOCKER file is in the current directory. Set your name in the image below!!! ******************

# create the local image which is stored on your laptop 
docker image build -t n4demo/java-my-name-here .

# run the local image in a container hosted in a Linux VM hosted on your laptop
docker run -it --rm  --name java-hw n4demo/java-my-name-here

#login to DockerHub using password: <password>
docker login --username n4demo -p <password>

# push the image to docker hub
docker push n4demo/java-my-name-here
