FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8
WORKDIR /webformsbasic
COPY ./webformsbasic/bin/release/publish .
SHELL ["powershell", "-command", "$ErrorActionPreference = 'Stop';"]
RUN New-WebApplication -Name 'webforms' -Site 'Default Web Site' -PhysicalPath c:/webformsbasic
