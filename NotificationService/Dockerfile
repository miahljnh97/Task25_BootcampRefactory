FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-notif
WORKDIR /source

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out/notif


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-notif /source/out/notif ./
ENTRYPOINT ["dotnet", "NotificationService.dll"]