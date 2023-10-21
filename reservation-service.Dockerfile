FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

EXPOSE 80 

COPY Lab2Publish/ReservationService .

ENTRYPOINT ["dotnet", "Rsoi.Lab2.ReservationService.HttpApi.dll"]