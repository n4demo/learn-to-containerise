
# create the local image
docker image build -t node4demo/nanoserver-hello:v1.0.0 .

# run the local image
docker container run -it --rm node4demo/nanoserver-hello:v1.0.0

docker ps

docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" node4demo/python-standard:v1.0.0

#login to docker hub
docker login --username node4demo

# push the image to docker hub
docker push node4demo/nanoserver-hello:v1.0.0