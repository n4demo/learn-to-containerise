FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["aspnetapp/aspnetapp.csproj", "aspnetapp/"]
RUN dotnet restore "aspnetapp/aspnetapp.csproj"
COPY . .
WORKDIR "/src/aspnetapp"
RUN dotnet build "aspnetapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnetapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Make sure the app binds to port 8080
ENV ASPNETCORE_URLS http://*:8080

ENTRYPOINT ["dotnet", "aspnetapp.dll"]

