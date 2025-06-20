FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MathProject.Client/MathProject.Client/MathProject.Client.csproj", "MathProject.Client/MathProject.Client/"]
COPY ["MathProject.Client/MathProject.Client.Client/MathProject.Client.Client.csproj", "MathProject.Client/MathProject.Client.Client/"]
RUN dotnet restore "MathProject.Client/MathProject.Client/MathProject.Client.csproj"
COPY . .
WORKDIR "/src/MathProject.Client/MathProject.Client"
RUN dotnet build "./MathProject.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MathProject.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MathProject.Client.dll"]
