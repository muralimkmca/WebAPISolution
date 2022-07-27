#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 85

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Core6MongoDb/Core6MongoDb.csproj", "Core6MongoDb/"]
RUN dotnet restore "Core6MongoDb/Core6MongoDb.csproj"
COPY . .
WORKDIR "/src/Core6MongoDb"
RUN dotnet build "Core6MongoDb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Core6MongoDb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Core6MongoDb.dll"]