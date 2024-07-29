FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

EXPOSE 5167

COPY ./src/Taxmaster.API/Taxmaster.API.csproj /src/Taxmaster.API/
COPY ./src/Taxmaster.Domain/Taxmaster.Domain.csproj /src/Taxmaster.Domain/
COPY ./src/Taxmaster.Infrastructure/Taxmaster.Infrastructure.csproj /src/Taxmaster.Infrastructure/

RUN dotnet restore /src/Taxmaster.API/Taxmaster.API.csproj

COPY . .

RUN dotnet build /src/Taxmaster.API/Taxmaster.API.csproj -c Debug -o /app

ENTRYPOINT ["dotnet", "/app/Taxmaster.API.dll"]