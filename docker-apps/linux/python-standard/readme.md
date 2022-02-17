# Python Web App
## This exercise shows how to containerise a very simple Python web application using VS Code and Docker Desktop and uploading to DockerHub. 

1. Important - Set your VS Code folder or terminal current directory so that the DOCKER file is in the current directory.
2. create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW and paste in the docker image build code below and edit your name. 
- node4demo refers to container registry account or owner that already exists
- php refers to the application 
- my-name-here is a tag for this application. 
- The . (dot) refers to the current directory (assuming the current directory has th app code and Docker file

*docker image build -t node4demo/python-standard:my-name-here .*

3. add 3 additional tags to the same image by rebuilding image. Note we add a version.

*docker build -t node4demo/python-standard:v1.0.0 -t node4demo/python-standard -t node4demo/python-standard:latest .*

4. run the local image in a container hosted in a Linux VM hosted on your laptop

*docker container run --name python-web-app --rm -i -t -p 5001:5000 node4demo/python-standard:my-name-here*

### What port on the CONTAINER hads been opened to receive traffic?
### What port on your laptop has has been set to forward to the open port on the container?

5. view html returned from the web app in the command line window

*curl localhost:5001*

6. Open Chrome or Edge and paste in the address below

*http://localhost:5001*

7. open a new BASH terminal window and run docker ps

*docker ps*

8. from 2nd BASH terminal window, list all running containers

* docker container ls -aq*

9. From the keyboard to shut down the container (from first terminal): CTL C 

10. login to DockerHub
docker login --username node4demo -p my-password

11. push the image to DockerHub - make sure you have built this image with the tag specified below

docker push node4demo/python-standard:v1.0.0

docker push node4demo/python-standard:latest

# CONGRATULATIONS - you now know how to containerise a simple Python web app application.





### =============== Part 3 Web Apps for Containers =======  you will need an Azure subscription to do this=================
### You will now see how to run containers in Azure App Services
#From the Azure portal create a new App Service Plan and select Linux as the OS. Set to a Premium performance level
#From the Azure portal create a new Web Apps for Containers resource and select to use Docker 
#From Overview -select the web address and load in browser - NGINX
### Select Container Settings - edit the image to node4demo/python-standard:v1.0.0 image in Docker Hub


### ================ PART 4 Kubernetes ======== you will need an Azure subscription to do this ===================
### You are now going to use the Azure 'az' command to perform tasks in Azure. So login to the portal and click on the > to open the CLI.

### create a new resource group in your Azure subscription 
az group create -l westeurope -n myrg

### create AKS cluster using your *** unique name **
az aks create -g myrg -n aks-zzz

### download credentials into local file
az aks get-credentials --name aks-zzz --resource-group myrg

#test that credentials work ok
kubectl get all

### deploy the nginx web server image from Docker Hub into your kubernetes cluster
kubectl run  –n nginx --image=nginx  
kubectl expose deployment nginx --name=nginx

### now determine IP address of nginx server
kubectl get all -o wide

### access web server in browser
http://<ip-address>

### now deploy the node4demo/python-standard:v1.0.0 web server image from Docker Hub into your kubernetes cluster

node4demo/python-standard:v1.0.0

### deploy python in a pod in kubernetes
kubectl run  python --image=node4demo/python-standard:latest  

### add a load balancer service on a public IP
kubectl expose deployment python --type=LoadBalancer --name=python --port=80 --target-port=5000

### now determine public IP address of python service
kubectl get all -o wide

### access python web server in browser
http://<ip-address>

### alternatively deploy python app to your kubernetes using the supplied YAML file
### in the Azure CLI - upload python-kube-manifest.yaml
kubectl apply -f python-kube-manifest.yaml

kubectl get all -o wide

### ==============   PART 5 Azure Container Registry ============
### create an Azure Container Registry
az acr create -n acr-my-name -g myrg --sku Standard

### login to azure and then to Azure Container Registry
az login
az acr login --name acr-my-name.azurecr.io

docker push acr-my-name.azurecr.io/samples/python-standard:v1.0.0

==========================

### Stop all containers
docker container stop $(docker container ls -aq)

### Delete all containers
docker rm $(docker ps -a -q)

### Delete all images
docker rmi $(docker images -q)


