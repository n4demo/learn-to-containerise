### This exercise shows how to containerise a Python Django web app. 

### ******** Important - Set your terminal current directory so that the DOCKER file is in the current directory. Set your name in the image below!!! ******************

### create the local image
docker image build -t node4demo/python-django:my-name-here .

### run the local image
docker container run --name python_django -it --rm  -p 80:80 node4demo/python-django:my-name-here

docker ps

docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" node4demo/python-standard:v1.0.0

#login to docker hub
docker login --username node4demo -p <password>

### push the image to docker hub
docker push node4demo/python-django:my-name-here