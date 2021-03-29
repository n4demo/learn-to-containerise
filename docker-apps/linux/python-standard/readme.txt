
# ================PART 1: This exercise shows how to containerise a very simple Python web application. 

# ********** Important - VS code folder on LHS must be set to PYTHON-STANDARD and set your name in the app.py and image below!!! *******

# open the Dockerfile on LHS and try to work out what is does

# open app.py and overwrite you name - save file

# create the local image. sixdegreesuk refers to the repository, python-standard refers to the application and my-name-here is the tag for this application 
docker image build -t sixdegreesuk/python-standard:my-name-here .

# add 3 additional tags to the same image by rebuilding image. Note we add a version.
docker build -t sixdegreesuk/python-standard:v1.0.0 -t sixdegreesuk/python-standard -t sixdegreesuk/python-standard:latest .

# run the local image in a container hosted in a Linux VM hosted on your laptop
docker container run --name python-web-app --rm -i -t -p 5001:5000 sixdegreesuk/python-standard:my-name-here

# docker container run --name python-web-app --rm -i -t -p 5001:5000 sixdegreesuk/python-standard:latest

# view html returned from the web app in the command line window
curl localhost:5001

# run in browser
http://localhost:5001

# open a new terminal window and run docker ps
docker ps

# open a new terminal window AND list all running containers
docker container ls -aq

# use CTL -c to stop the container

# ============== PART 2 -- push image to Docker Hub =========================

#login to DockerHub using password: <password>
docker login --username sixdegreesuk

# push the image to DockerHub - make sure you have built this image with the tag specified below

docker push sixdegreesuk/python-standard:v1.0.0

docker push sixdegreesuk/python-standard:latest

# *****CONGRATULATIONS - you now know how to containerise a PYthon web app application. ****************






# =============== Part 3 Web Apps for Containers =======  you will need an Azure subscription to do this=================
# You will now see how to run containers in Azure App Services
#From the Azure portal create a new App Service Plan and select Linux as the OS. Set to a Premium performance level
#From the Azure portal create a new Web Apps for Containers resource and select to use Docker 
#From Overview -select the web address and load in browser - NGINX
# Select Container Settings - edit the image to sixdegreesuk/python-standard:v1.0.0 image in Docker Hub





# ================ PART 4 Kubernetes ======== you will need an Azure subscription to do this ===================
# You are now going to use the Azure 'az' command to perform tasks in Azure. So login to the portal and click on the > to open the CLI.

# create a new resource group in your Azure subscription 
az group create -l westeurope -n myrg

# create AKS cluster using your *** unique name **
az aks create -g myrg -n aks-zzz

# download credentials into local file
az aks get-credentials --name aks-zzz --resource-group myrg

#test that credentials work ok
kubectl get all

# deploy the nginx web server image from Docker Hub into your kubernetes cluster
kubectl run  –n nginx --image=nginx  
kubectl expose deployment nginx --name=nginx

# now determine IP address of nginx server
kubectl get all -o wide

# access web server in browser
http://<ip-address>

# now deploy the sixdegreesuk/python-standard:v1.0.0 web server image from Docker Hub into your kubernetes cluster

sixdegreesuk/python-standard:v1.0.0

# deploy python in a pod in kubernetes
kubectl run  python --image=sixdegreesuk/python-standard:latest  

# add a load balancer service on a public IP
kubectl expose deployment python --type=LoadBalancer --name=python --port=80 --target-port=5000

# now determine public IP address of python service
kubectl get all -o wide

# access python web server in browser
http://<ip-address>

# alternatively deploy python app to your kubernetes using the supplied YAML file
# in the Azure CLI - upload python-kube-manifest.yaml
kubectl apply -f python-kube-manifest.yaml

kubectl get all -o wide

# ==============   PART 5 Azure Container Registry ============
# create an Azure Container Registry
az acr create -n acr-my-name -g myrg --sku Standard

# login to azure and then to Azure Container Registry
az login
az acr login --name acr-my-name.azurecr.io

docker push acr-my-name.azurecr.io/samples/python-standard:v1.0.0

==========================

# Stop all containers
docker container stop $(docker container ls -aq)

# Delete all containers
docker rm $(docker ps -a -q)

# Delete all images
docker rmi $(docker images -q)


