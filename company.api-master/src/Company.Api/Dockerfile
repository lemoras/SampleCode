FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /

COPY ./src /src
RUN dotnet restore src/Company.Api/Company.Api.csproj

WORKDIR /src/Company.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /src/Company.Api/out
ENV ASPNETCORE_ENVIRONMENT master
COPY --from=build-env /src/Company.Api/out ./
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "Company.Api.dll"]