# Python Command Line App
### This exercise shows how to containerise a very simple bit of code that runs in Python on Alpine Linux (very compact Linux distribution). 

1. Important - Set your VS Code folder so that the DOCKER file is in the current directory.
2. create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW and paste in the docker image build code from browser and edit your name. 

- node4demo refers to container registry account or owner that already exists
- php-basic refers to the application 
- my-name-here is a tag for this application. 
- The . (dot) refers to the current directory (assuming the current directory has the app code and Docker file

```
docker image build . -t node4demo/python-basic:my-name-here
```

3. to clear your Terminal screen type:  clear 

4. add 2 additional tags to the same image. Note that we include the version as part of the tag

```
docker build -t node4demo/python-basic:v1.0.0 -t node4demo/python-basic:latest .
```

5. run the local image in a Linux VM hosted on your laptop inside Docker desktop

```
docker container run --name python_basic --rm -i -t node4demo/python-basic:my-name-here
```

6. show all containers running or not. Is it still running?

```
docker ps -a
```

7. show logs for this container

```
docker logs -f node4demo/python-basic:my-name-here
```

8. login to DockerHub

```
docker login --username node4demo -p my-password
```

9. push the image to docker hub

```
docker push node4demo/python-basic:my-name-here
```

### Congratulations.. now let's containerise our first python web (Flask) application.

10. In VS Code: File..Open Folder ..docker-apps\linux\python-flask

https://github.com/n4demo/learn-to-containerise/tree/main/docker-apps/linux/python-flask



