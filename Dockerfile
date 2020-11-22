FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BankingSystem/BankingSystem.csproj", "BankingSystem/"]
COPY ["BankingSystem.Infrastructure.DependencyBuilder/BankingSystem.Infrastructure.DependencyBuilder.csproj", "BankingSystem.Infrastructure.DependencyBuilder/"]
COPY ["BankingSystem.Infrastructure.HostedServices/BankingSystem.Infrastructure.HostedServices.csproj", "BankingSystem.Infrastructure.HostedServices/"]
COPY ["BankingSystem.Data/BankingSystem.Data.csproj", "BankingSystem.Data/"]
COPY ["BankingSystem.Core/BankingSystem.Core.csproj", "BankingSystem.Core/"]
RUN dotnet restore "BankingSystem/BankingSystem.csproj"
COPY . .
WORKDIR "/src/BankingSystem"
RUN dotnet build "BankingSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankingSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankingSystem.dll"]