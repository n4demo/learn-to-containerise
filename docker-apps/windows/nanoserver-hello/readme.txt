
# create the local image
docker image build -t n4demo/nanoserver-hello:v1.0.0 .

# run the local image
docker container run -it --rm n4demo/nanoserver-hello:v1.0.0

docker ps

docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" n4demo/python-standard:v1.0.0

#login to docker hub
docker login --username n4demo

# push the image to docker hub
docker push n4demo/nanoserver-hello:v1.0.0