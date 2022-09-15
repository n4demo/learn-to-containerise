# Python Web App (Flask)

## This exercise shows how to containerise a very simple Python web application using VS Code and Docker Desktop and uploading to DockerHub. 

1. In VS Code File..Open Folder - navigate to docker-apps/linux/python-standard folder, so that the DOCKER file is in the current directory. 
2. create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW and paste in the docker image build code and edit your name.

- node4demo refers to container registry account or owner that already exists
- php refers to the application 
- my-name-here is a tag for this application. 
- . (dot) refers to the current directory (assuming the current directory has th app code and Docker file

```
docker image build -t node4demo/python-flask:my-name-here .
```

3. Add 3 additional tags to the same image by rebuilding image. Note we add a version.

```
docker build -t node4demo/python-flask:v1.0.0 -t node4demo/python-flask -t node4demo/python-flask:latest .
```

4. Run the local image in a container hosted in a Linux VM hosted on your laptop, limiting the resources to the container

```
docker container run --name python-web-app -m 200M  --cpus=0.25 --rm -i -t -p 5001:5000 node4demo/python-flask:my-name-here
```

### What port on the CONTAINER hads been opened to receive traffic?

### What port on your laptop has has been set to forward to the open port on the container?

### How much CPU and RAM has been allocated to the container?

5. Open a new BASH terminal to view HTML code returned from the web app by entering the command:

```
curl localhost:5001
```

6. Open Chrome or Edge and paste in the address below

```
http://localhost:5001
```

7. Open a new BASH terminal window and run docker ps

```
docker ps
```

8. From the 2nd BASH terminal window, list all running containers

```
docker container ls -aq
```

9. From the keyboard to shut down the container (from first terminal): CTL C 

10. Login to DockerHub from the terminal

```
docker login --username node4demo -p my-password
```

11. Push (upload) the image to DockerHub - make sure you have built this image with the tag specified below

```
docker push node4demo/python-flask:v1.0.0
```

12. (Optionally). Edit the python file so that the python web app is listening on port 5500 and the container can expose this port. Hint edit the app.py file. Now try and re-run the app so that in you browser it work at 

```
http://localhost:5501
```

### Congratulations.. now let's containerise our first MS ASP.NET Core web application.

13. In VS Code: File..Open Folder ..docker-apps\linux\asp-net-core