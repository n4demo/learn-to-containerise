
# create the local image
docker image build -t sixdegreesuk/nanoserver-hello:v1.0.0 .

# run the local image
docker container run -it --rm sixdegreesuk/nanoserver-hello:v1.0.0

docker ps

docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" sixdegreesuk/python-standard:v1.0.0

#login to docker hub
docker login --username sixdegreesuk

# push the image to docker hub
docker push sixdegreesuk/nanoserver-hello:v1.0.0