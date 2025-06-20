# Stage 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Правильный путь:
COPY ["MathProject.Client.csproj", "."]
RUN dotnet restore "MathProject.Client.csproj"

COPY . .
RUN dotnet build "MathProject.Client.csproj" -c Release -o /app/build
RUN dotnet publish "MathProject.Client.csproj" -c Release -o /app/publish

# Stage 2: Serve with nginx
FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf