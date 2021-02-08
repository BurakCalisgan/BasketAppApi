# Build sdk image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

#Restore each layers' packages by order regards to clean architecture
WORKDIR /app/src/Domain
COPY src/Domain/*.csproj ./
RUN dotnet restore

WORKDIR /app/src/Application
COPY src/Application/*.csproj ./
RUN dotnet restore

WORKDIR /app/src/Persistence
COPY src/Persistence/*.csproj ./
RUN dotnet restore

WORKDIR /app/src/WebApi
COPY src/WebApi/*.csproj ./
RUN dotnet restore

WORKDIR /app
COPY . ./
WORKDIR /app/src/WebApi
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app/src/WebApi
COPY --from=build-env /app/src/WebApi/out .
CMD ["cd", "src/WebApi/out"]
ENTRYPOINT ["dotnet", "WebApi.dll"]