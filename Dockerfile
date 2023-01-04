FROM mcr.microsoft.com/dotnet/runtime:6.0

LABEL version = "1.0"

WORKDIR /app

copy .\Projects\BusinessCardApp .

ENTRYPOINT ["dotnet", "BusinessCardApp.dll"]