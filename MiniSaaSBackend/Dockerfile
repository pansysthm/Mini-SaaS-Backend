FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["MiniSaaSBackend/MiniSaaSBackend.csproj", "MiniSaaSBackend/"]
RUN dotnet restore "MiniSaaSBackend/MiniSaaSBackend.csproj"
COPY . .
WORKDIR "/src/MiniSaaSBackend"
RUN dotnet build "MiniSaaSBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniSaaSBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniSaaSBackend.dll"]
