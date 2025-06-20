# Используем SDK для восстановления и сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Правильный путь:
COPY ["MathProject.Host.API.csproj", "."]
RUN dotnet restore "MathProject.Host.API.csproj"

COPY . .
WORKDIR "/src/MathProject.Host.API"
RUN dotnet build "MathProject.Host.API.csproj" -c Release -o /app/build
RUN dotnet publish "MathProject.Host.API.csproj" -c Release -o /app/publish

# Запуск
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MathProject.Host.API.dll"]