FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем нужный проект
COPY MathProject.Client/ MathProject.Client/

# Переходим в папку клиента
WORKDIR /src/MathProject.Client

# Восстанавливаем и собираем
RUN dotnet restore MathProject.Client/MathProject.Client.csproj
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Serve with nginx
FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY --from=build /app/publish /usr/share/nginx/html
COPY MathProject.Client/MathProject.Client/nginx.conf /etc/nginx/conf.d/default.conf