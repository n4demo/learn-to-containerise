
# PHP
## This exercise shows how to containerise a very simple PHP Apache web application using VS Code and Docker Desktop and uploading to DockerHub. 

## Important - Set your VS Code folder or terminal current directory so that the DOCKER file is in the current directory. Set your name in the image below.
### e.g docker image build . -t node4demo/php-app:fred-bloggs 

###
### create the local image by OPENING a NEW VS CODE TERMINAL WINDOW and paste in the docker image build code below. 
- node4demo refers to a DockerHub account that already exists
- php-app refers to the application and my-name-here is a tag for this application. 
- The dot refers to the current directory (assuming the current directory has th app code and Docker file

*docker image build . -t node4demo/php-app:my-name-here* 

### add additional tags to the same image by rebuilding image
*docker build . -t node4demo/php-app -t node4demo/php-app:liverpool -t node4demo/php-app:latest*

### Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them
*docker scan node4demo/php-app:liverpool*

### how many vulnerabilities does it have? Is there a base image with no vulnerabilities?

### run the local image with 200MB memory, 
*docker container run -m 200M -it --rm  --name php-app -p 5002:80 node4demo/php-app:liverpool*

### run in browser
http://localhost:5002

#login to DockerHub
*docker login --username node4demo -p <password>*

### push the image to docker hub
*docker push node4demo/php-app:latest*
*docker push node4demo/php-app:my-name-here*
*docker push node4demo/php-app:liverpool*

## Question: Why does it take so very little time to upload to DockerHub?

# Container Registry and Kubernetes

#login to Azure container registry
*docker login n4demo.azurecr.io -u n4demo -p xxxx*

*docker push n4demo.azurecr.io/node4demo/php-app:latest*

### Delete all containers
docker rm $(docker ps -a -q)

### Delete all images
docker rmi $(docker images -q)
