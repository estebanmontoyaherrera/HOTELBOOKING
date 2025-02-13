# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV DB_CONNECTION_STRING="Data Source=192.168.1.10,1433; Database=HOTELBOOKINGDB;User=sa;Password=12345;TrustServerCertificate=True;"

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/HOTELBOOKING.Api/HOTELBOOKING.Api.csproj", "src/HOTELBOOKING.Api/"]
COPY ["src/HOTELBOOKING.Application.UseCase/HOTELBOOKING.Application.UseCase.csproj", "src/HOTELBOOKING.Application.UseCase/"]
COPY ["src/HOTELBOOKING.Application.Dtos/HOTELBOOKING.Application.Dtos.csproj", "src/HOTELBOOKING.Application.Dtos/"]
COPY ["src/HOTELBOOKING.Application.Interface/HOTELBOOKING.Application.Interface.csproj", "src/HOTELBOOKING.Application.Interface/"]
COPY ["src/HOTELBOOKING.Domain/HOTELBOOKING.Domain.csproj", "src/HOTELBOOKING.Domain/"]
COPY ["src/HOTELBOOKING.Utilities/HOTELBOOKING.Utilities.csproj", "src/HOTELBOOKING.Utilities/"]
COPY ["src/HOTELBOOKING.Infrastructure/HOTELBOOKING.Infrastructure.csproj", "src/HOTELBOOKING.Infrastructure/"]
COPY ["src/HOTELBOOKING.Persistence/HOTELBOOKING.Persistence.csproj", "src/HOTELBOOKING.Persistence/"]
RUN dotnet restore "./src/HOTELBOOKING.Api/HOTELBOOKING.Api.csproj"
COPY . .
WORKDIR "/src/src/HOTELBOOKING.Api"
RUN dotnet build "./HOTELBOOKING.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HOTELBOOKING.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HOTELBOOKING.Api.dll"]