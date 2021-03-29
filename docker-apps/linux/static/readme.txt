
# This exercise shows how to containerise a very simple stastic web application. 
# ******* Important - VS code folder on LHS must be set to static and set your name in the index.html file and image below!!! *****
# e.g docker build -t static .
#
# create the local image by OPENING a NEW TERMINAL WINDOW and paste in the docker image build code below. 
# Note: sixdegreesuk refers to the repository, static refers to the application and my-name-here is the tag for this application. 
# the dot refers to the current directory

docker image build -t sixdegreesuk/static .

# run the local image
docker run -it --rm  --name static -p 5012:80 sixdegreesuk/static

# run in browser
http://localhost:5012

#login to DockerHub using password: <password>
docker login --username sixdegreesuk

# push the image to docker hub
docker push sixdegreesuk/static

# Delete all containers
docker rm $(docker ps -a -q)

# Delete all images
docker rmi $(docker images -q)

