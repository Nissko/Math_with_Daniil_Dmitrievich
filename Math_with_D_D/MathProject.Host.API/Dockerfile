FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем все зависимости
COPY MathProject.Host.API/ ./MathProject.Host.API/
COPY MathProject.Host.Application/ ./MathProject.Host.Application/
COPY MathProject.Host.Domain/ ./MathProject.Host.Domain/
COPY MathProject.Host.Infrastructure/ ./MathProject.Host.Infrastructure/

# Собираем API
WORKDIR /src/MathProject.Host.API
RUN dotnet restore MathProject.Host.API.csproj
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MathProject.Host.API.dll"]