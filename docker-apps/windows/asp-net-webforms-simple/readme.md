#ASP.NET. .Net Framework (Windows)

1. Switch to run Windows Containers by right clicking Docker (Whale) icon in system tray - Switch to Windows containers 

### Containers feature is disabled. Enable it using the PowerShell script (in an administrative PowerShell) and restart your computer before using Docker Desktop: 

*Enable-WindowsOptionalFeature -Online -FeatureName $("Microsoft-Hyper-V", "Containers") -All*

1. Important - Set your VS Code folder so that the ASP-NET-WEBFORMS-SIMPLE is at the root.
2. create the local image by OPENING a NEW VS CODE BASH TERMINAL WINDOW and paste in the docker image build code below and edit your name. 
- node4demo refers to container registry account or owner that already exists
- webforms refers to the application 
- my-name-here is a tag for this application. 
- The . (dot) refers to the current directory (assuming the current directory has th app code and Docker file

3. open a new terminal and paste

*docker image build -t node4demo/webforms:my-name-here -f ./webformsbasic/Dockerfile . *

### If you receive this error: This error may indicate that the docker daemon is not running. - switch to Windows Containers

## Note the size of the Layers being downloaded.

4. Use 'docker scan' to run Snyk tests against images to find vulnerabilities.

*docker scan node4demo/webforms:my-name-here*

*docker run -it --rm -p 5014:80 --name aspnetapp node4demo/webforms:my-name-here*

*docker stop aspnetapp*

*docker ps*

5. run in browser

*http://localhost:5014*

6. login to docker hub
docker login --username node4demo -p <password>

7. push the image to docker hub
docker push node4demo/aspnetapp:v3

