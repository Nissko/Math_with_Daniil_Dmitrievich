FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем нужные папки из контекста
COPY MathProject.Client/ ./MathProject.Client/
COPY MathProject.Client.Client/ ./MathProject.Client.Client/

# Переходим в нужную директорию
WORKDIR /src/MathProject.Client.Client

# Восстанавливаем и собираем проект
RUN dotnet restore MathProject.Client.Client.csproj
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Serve with nginx
FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY --from=build /app/publish /usr/share/nginx/html
COPY MathProject.Client/MathProject.Client/nginx.conf /etc/nginx/conf.d/default.conf