# ******** Important - Set your terminal current directory so that the DOCKER file is in the current directory. Set your name in the image below!!! ******************

# create the local image
docker image build . -t node4demo/go:latest

# run the local image
docker container run --name go --rm -i -t -p 8081:80 node4demo/go:latest

# run in cli
curl localhost:8081

# run in browser
http://localhost:8081

docker ps

docker stop go

#login to DockerHub
docker login --username node4demo -p <password>

# push the image to docker hub
docker push node4demo/go:latest

#login to azure container registry
docker login acrprduks.azurecr.io

docker push acrprduks.azurecr.io/node4demo/go:latest

kubectl apply -f go-kube-manifest.yaml

