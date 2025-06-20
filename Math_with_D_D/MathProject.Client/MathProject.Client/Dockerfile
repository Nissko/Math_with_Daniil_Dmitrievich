FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем .sln и все проекты
COPY *.sln .
COPY MathProject.Client/ MathProject.Client/
COPY MathProject.Host.Application/ MathProject.Host.Application/
COPY MathProject.Host.Domain/ MathProject.Host.Domain/

# Восстановление решения
WORKDIR /src/MathProject.Client
RUN dotnet restore ../Math_with_D_D.sln

# Сборка и публикация
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Serve with nginx
FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY --from=build /app/publish /usr/share/nginx/html
COPY MathProject.Client/MathProject.Client/nginx.conf /etc/nginx/conf.d/default.conf