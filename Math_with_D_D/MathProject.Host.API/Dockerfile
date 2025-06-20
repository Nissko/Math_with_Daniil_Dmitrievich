FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MathProject.Host.API/MathProject.Host.API.csproj", "MathProject.Host.API/"]
COPY ["MathProject.Host.Infrastructure/MathProject.Host.Infrastructure.csproj", "MathProject.Host.Infrastructure/"]
COPY ["MathProject.Host.Application/MathProject.Host.Application.csproj", "MathProject.Host.Application/"]
COPY ["MathProject.Host.Domain/MathProject.Host.Domain.csproj", "MathProject.Host.Domain/"]
RUN dotnet restore "MathProject.Host.API/MathProject.Host.API.csproj"
COPY . .
WORKDIR "/src/MathProject.Host.API"
RUN dotnet build "./MathProject.Host.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MathProject.Host.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MathProject.Host.API.dll"]
