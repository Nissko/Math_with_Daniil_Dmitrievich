FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем .sln и все проекты
COPY *.sln .
COPY MathProject.Host.API/ MathProject.Host.API/
COPY MathProject.Host.Application/ MathProject.Host.Application/
COPY MathProject.Host.Domain/ MathProject.Host.Domain/
COPY MathProject.Host.Infrastructure/ MathProject.Host.Infrastructure/

# Восстанавливаем всё решение
WORKDIR /src/MathProject.Host.API
RUN dotnet restore ../Math_with_D_D.sln

# Собираем
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MathProject.Host.API.dll"]