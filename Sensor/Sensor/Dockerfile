#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sensor/Sensor.csproj", "Sensor/"]
COPY ["Sensor.Domaine.Impl/Sensor.Domain.Impl.csproj", "Sensor.Domaine.Impl/"]
COPY ["Sensor.Domain/Sensor.Domain.csproj", "Sensor.Domain/"]
COPY ["Sensor.Infrastructure/Sensor.Infrastructure.csproj", "Sensor.Infrastructure/"]
COPY ["Sensor.Infrastructure.Impl/Sensor.Infrastructure.Impl.csproj", "Sensor.Infrastructure.Impl/"]
COPY ["Sensor.CrossCutting/Sensor.CrossCutting.csproj", "Sensor.CrossCutting/"]
COPY ["Sensor.Presentation.Mom.Services/Sensor.Presentation.Mom.Services.csproj", "Sensor.Presentation.Mom.Services/"]
COPY ["Sensor.Presentation.Rest.Services/Sensor.Presentation.Rest.Services.csproj", "Sensor.Presentation.Rest.Services/"]
RUN dotnet restore "Sensor/Sensor.csproj"
COPY . .
WORKDIR "/src/Sensor"
RUN dotnet build "Sensor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sensor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sensor.dll"]