
# PHP
## This exercise shows how to containerise a very simple PHP Apache web application using VS Code terminal with Docker Desktop, then uploading to DockerHub.  

1. In VS Code File..Open Folder - navigate to docker-apps/linux/php folder, so that the DOCKER file is in the current directory. 
2. create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW and paste in the docker image build code below and edit your name. 

- node4demo refers to container registry account or owner that already exists
- php-app refers to the application 
- my-name-here is a tag for this application. 
- . (dot) refers to the current directory (assuming the current directory has th app code and Docker file

*docker image build . -t node4demo/php-app:my-name-here* 

3. add additional tags to the same image by rebuilding image

*docker build . -t node4demo/php-app:liverpool -t node4demo/php-app:1.0.0*

4. Use 'docker scan' to run Snyk tests against images to find vulnerabilities and learn how to fix them.

*docker scan node4demo/php-app:liverpool*

5. how many vulnerabilities does it have? Is there a base image with no vulnerabilities?

6. run the local image with 200MB memory, 

*docker container run -m 200M -it --rm  --name php-app -p 5002:80 node4demo/php-app:liverpool*

7. run in browser
http://localhost:5002

8. login to DockerHub

*docker login --username node4demo -p my-password*

### upload to Container Registry

9. push the image to docker hub container registry
*docker push node4demo/php-app:latest*
*docker push node4demo/php-app:my-name-here*
*docker push node4demo/php-app:liverpool*

10. Question: Why does it take so very little time to upload to DockerHub?

11. login to GitHub container registry (GHCR)

*docker login ghcr.io -u n4demo -p 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*

*docker build . -t ghcr.io/n4demo/php-app:latest*

*docker container run -m 200M -it --rm  --name php -p 5003:80 ghcr.io/n4demo/php-app:latest*

*docker push ghcr.io/n4demo/php-app:latest*

12. Delete all containers
docker rm $(docker ps -a -q)

13. Delete all images
docker rmi $(docker images -q)

### Congratulations.. now let's containerise our first python application.

### Optionally build and upload to GitHub container registry

14. optional - build ready to deploy to GitHub container registry

*docker build . -t ghcr.io/n4demo/php-app:latest*

*docker container run -m 200M -it --rm  --name php-app2 -p 5003:80 ghcr.io/n4demo/php-app:latest*

15. Question: Why are we now using n4demo instead of node4demo as the owner? 

16. In VS Code: File..Open Folder ..docker-apps\linux\python-basic
