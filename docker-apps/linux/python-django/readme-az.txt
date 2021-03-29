
az login

az group create --name ContainerDemoRg --location westeurope 

az appservice plan create --name ContainerDemoAppServicePlan --resource-group ContainerDemoRg --sku B1 --is-linux

az webapp create --resource-group ContainerDemoRg --plan ContainerDemoAppServicePlan --name CdwPythonDemo2 --deployment-container-image-name wardlen/pythonimage:v1.0.0