FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Proyecto_BackEnd.csproj", "."]
RUN dotnet restore "Proyecto_BackEnd.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Proyecto_BackEnd.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Proyecto_BackEnd.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["./https","."]
ENV ASPNETCORE_URLS=https://+:443
ENV ASPNETCORE_HTTPS_PORT=443
EXPOSE 443
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/backend.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password
ENTRYPOINT ["dotnet", "Proyecto_BackEnd.dll"]