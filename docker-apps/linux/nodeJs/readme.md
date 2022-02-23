
```
docker image build . -t node4demo/nodejs 
``

```
docker run -it --rm  --name nodejs -p 5013:8080 node4demo/nodejs
```

http://localhost:5013

```
docker login --username node4demo -p my-password

docker push node4demo/nodejs
```

