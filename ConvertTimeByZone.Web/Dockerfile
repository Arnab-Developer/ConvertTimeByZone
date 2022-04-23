FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ConvertTimeByZone.Web/bin/publish/ ./app
WORKDIR /app
ENTRYPOINT ["dotnet", "ConvertTimeByZone.Web.dll"]