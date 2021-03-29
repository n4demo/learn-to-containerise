FROM microsoft/aspnet:4.7.2-windowsservercore-1803
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
