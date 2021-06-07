FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Formula1.Core/Formula1.Core.csproj", "Formula1.Core/"]
COPY ["Formula1.CoreTest/Formula1.CoreTest.csproj", "Formula1.CoreTest/"]
COPY ["Utils/Utils.csproj", "Utils/"]
RUN dotnet restore "Formula1.Core/Formula1.Core.csproj"
COPY . .
RUN dotnet test --logger "trx;LogFileName=unittestResults.xml"