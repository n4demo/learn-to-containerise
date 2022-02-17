*az login*

*az group create --name WebApp4ContainersRg --location westeurope*

*az appservice plan create --name WebAppLinuxPlan --resource-group WebApp4ContainersRg --sku B1 --is-linux*

*az webapp create --resource-group WebApp4ContainersRg --plan WebAppLinuxPlan --name cdw-PhpDemo --deployment-container-image-name node4demo/php:v1.0.0*

*az webapp update -g WebApp4ContainersRg -n cdw-PhpDemo --deployment-container-image-name node4demo/php:v1.0.0*