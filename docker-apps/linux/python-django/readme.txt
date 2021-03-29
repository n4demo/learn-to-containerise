# This exercise shows how to containerise a Python Django web app. 

# ** Important - VS code folder on LHS must be set to PYTHON-DJANGO and set your name in the image below!!! ******************

# create the local image
docker image build -t sixdegreesuk/python-django:my-name-here .

# run the local image
docker container run --name python_django -it --rm  -p 80:80 sixdegreesuk/python-django:my-name-here

docker ps

docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" sixdegreesuk/python-standard:v1.0.0

#login to docker hub
docker login --username sixdegreesuk

# push the image to docker hub
docker push sixdegreesuk/python-django:my-name-here