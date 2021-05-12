#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY ["SensorWebApi/SensorWebApi.csproj", "SensorWebApi/"]
RUN dotnet restore "SensorWebApi/SensorWebApi.csproj"
COPY . .
WORKDIR "/src/SensorWebApi"
RUN dotnet build "SensorWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SensorWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensorWebApi.dll"]
