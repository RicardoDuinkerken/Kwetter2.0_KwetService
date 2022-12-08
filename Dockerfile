# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore ./KwetService --disable-parallel
RUN dotnet publish ./KwetService -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
Copy --from=build /app ./

EXPOSE 5007-5008

ENTRYPOINT ["dotnet", "KwetService.Api.dll"]