
# This exercise shows how to containerise a very simple PHP Apache football web application. 

# ******** Important - Set your terminal current directory so that the DOCKER file is in the current directory. Set your name in the image below!!! ******************

# e.g docker image build . -t node4demo/php-app:fred-bloggs 
#
# create the local image by OPENING a NEW TERMINAL WINDOW and paste in the docker image build code below. 
# Note: node4demo refers to the repository, php-app refers to the application and my-name-here is the tag for this application. 
# the dot refers to the current directory

docker image build . -t node4demo/php-app:my-name-here 

# add additional tags to the same image by rebuilding image
docker build . -t node4demo/php-app -t node4demo/php-app:liverpool -t node4demo/php-app:latest -t my-registry.azurecr.io/node4demo/php-app:latest

#Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them
docker scan node4demo/php-app:liverpool

# run the local image
docker run -it --rm  --name php-app -p 5002:80 node4demo/php-app:liverpool

# run in browser
http://localhost:5002

#login to docker hub
#login to DockerHub
docker login --username node4demo -p <password>

# push the image to docker hub
docker push node4demo/php-app:latest
docker push node4demo/php-app:my-name-here
docker push node4demo/php-app:liverpool

# why does it take so very little time to upload to DockerHub?

# ========== Container Registry and Kubernetes below ============

#login to azure container registry
docker login acrprduks.azurecr.io -u acrprduks -p q5=lugW3pRuE9ChSpyZTI7x=fKuHUHJw

docker push acrprduks.azurecr.io/node4demo/php-app:latest

# deploy to Kubernetes using YAML file
kubectl create -f php-k8s-manifest.yaml

# ============================================

# Delete all containers
docker rm $(docker ps -a -q)

# Delete all images
docker rmi $(docker images -q)

