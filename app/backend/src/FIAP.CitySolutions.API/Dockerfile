FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FIAP.CitySolutions.API/FIAP.CitySolutions.API.csproj", "FIAP.CitySolutions.API/"]
COPY ["FIAP.CitySolutions.Business/FIAP.CitySolutions.Business.csproj", "FIAP.CitySolutions.Business/"]
COPY ["FIAP.CitySolutions.Data/FIAP.CitySolutions.Data.csproj", "FIAP.CitySolutions.Data/"]
COPY ["FIAP.CitySolutions.Domain/FIAP.CitySolutions.Domain.csproj", "FIAP.CitySolutions.Domain/"]
RUN dotnet restore "FIAP.CitySolutions.API/FIAP.CitySolutions.API.csproj"
COPY . .
WORKDIR "/src/FIAP.CitySolutions.API"
RUN dotnet build "FIAP.CitySolutions.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FIAP.CitySolutions.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FIAP.CitySolutions.API.dll"]