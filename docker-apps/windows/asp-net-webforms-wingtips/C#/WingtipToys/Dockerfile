# escape=`
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS builder

WORKDIR C:\src
CMD mkdir wingtiptoys
COPY c#\wingtiptoys.sln .
COPY c#\wingtiptoys\wingtiptoys.csproj .\wingtiptoys\
RUN nuget restore c:\src\wingtiptoys\wingtiptoys.csproj -Force

COPY C# C:\src
RUN msbuild wingtiptoys\wingtiptoys.csproj /p:OutputPath=c:\out /p:Configuration=Release

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8
COPY --from=builder C:\out\_PublishedWebsites\wingtiptoys c:/inetpub/wwwroot

# SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop';"]
# ENV APP_ROOT=C:\web-app
# WORKDIR ${APP_ROOT}
# RUN New-WebApplication -Name 'app' -Site 'Default Web Site' -PhysicalPath $env:APP_ROOT
# COPY --from=builder C:\out\_PublishedWebsites\wingtiptoys ${APP_ROOT}



