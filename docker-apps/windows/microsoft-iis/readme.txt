# ************ Important!... requires Docker VM to be running Windows

# create the local image
docker image build -t n4demo/iis:v1.0.0 .

# run the local image
docker container run --name iis --rm -i -p 80:80 -t n4demo/iis:v1.0.0

# show all containers running or not
docker ps -a

## show logs for this container
docker logs -f n4demo/iis:v1.0.0 
