FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-user
WORKDIR /source

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c release -o out/user


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-user /source/out/user ./
ENTRYPOINT ["dotnet", "UserService.dll"]
