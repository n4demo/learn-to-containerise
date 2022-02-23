
1. create the local image

```
docker image build . -t node4demo/go:latest
```

2. run the local image

```
docker container run --name go --rm -i -t -p 8081:80 node4demo/go:latest
```

3. run in cli

```
curl localhost:8081
```

4. run in browser

http://localhost:8081


```
docker ps

docker stop go

```

5. login to DockerHub

```
docker login --username node4demo -p my-password
```

6 push the image to docker hub

```
docker push node4demo/go:latest
```

