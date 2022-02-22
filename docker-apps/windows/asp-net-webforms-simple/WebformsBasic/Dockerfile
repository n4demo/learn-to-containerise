FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8
WORKDIR /webforms
COPY . .
SHELL ["powershell", "-command", "$ErrorActionPreference = 'Stop';"]
RUN New-WebApplication -Name 'webforms' -Site 'Default Web Site' -PhysicalPath c:/webforms
