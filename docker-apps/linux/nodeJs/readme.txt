
# This exercise shows how to containerise a very simple PHP Apache football web application. 

# ******** Important - Set your terminal current directory so that the DOCKER file is in the current directory. Set your name in the image below!!! ******************

# create the local image by OPENING a NEW TERMINAL WINDOW and paste in the docker image build code below. 
# Note: sixdegreesuk refers to the repository, nodejs refers to the application and my-name-here is the tag for this application. 
# the dot refers to the current directory

docker image build -t sixdegreesuk/nodejs .

# run the local image
docker run -it --rm  --name nodejs -p 5013:8080 sixdegreesuk/nodejs

# run in browser
http://localhost:5013

#login to docker hub
#login to DockerHub using password: <password>
docker login --username sixdegreesuk

# push the image to docker hub
docker push sixdegreesuk/nodejs

