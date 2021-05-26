FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY ./ ./
RUN dotnet publish -c release -o out


FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim
ENV ASPNETCORE_URLS=http://*:80
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "./service.dll"]
