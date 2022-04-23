FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY converttimebyzone/bin/publish/ ./app
WORKDIR /app
ENTRYPOINT ["dotnet", "ConvertTimeByZone.Web.dll"]