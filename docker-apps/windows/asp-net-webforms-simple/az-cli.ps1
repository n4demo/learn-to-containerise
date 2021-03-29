
docker stop $(docker ps -aq)

docker rm $(docker ps -aq)

docker ps -aq

docker build --tag wardlen/pythonimage:v1.0.0 .

docker run -p 2222:8000 wardlen/pythonimage:v1.0.0


docker login --username wardlen

docker push wardlen/pythonimage:v1.0.0



az login

az group create --name ContainerDemoRg --location westeurope 

az appservice plan create --name ContainerDemoAppServicePlan --resource-group ContainerDemoRg --sku B1 --is-linux

az webapp create --resource-group ContainerDemoRg --plan ContainerDemoAppServicePlan --name CdwPythonDemo2 --deployment-container-image-name wardlen/pythonimage:v1.0.0