
# This exercise shows how to containerise a very simple PHP Apache football web application. 
# ******* Important - VS code folder on LHS must be set to NodeJS *****
# create the local image by OPENING a NEW TERMINAL WINDOW and paste in the docker image build code below. 
# Note: cdwuk refers to the repository, nodejs refers to the application and my-name-here is the tag for this application. 
# the dot refers to the current directory

docker image build -t cdwuk/nodejs .

# run the local image
docker run -it --rm  --name nodejs -p 5013:8080 cdwuk/nodejs

# run in browser
http://localhost:5013

#login to docker hub
#login to DockerHub using password: Qwerty===1
docker login --username cdwuk

# push the image to docker hub
docker push cdwuk/nodejs

