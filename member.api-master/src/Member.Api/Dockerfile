FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /

COPY ./src /src
RUN dotnet restore src/Member.Api/Member.Api.csproj

WORKDIR /src/Member.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /src/Member.Api/out
ENV ASPNETCORE_ENVIRONMENT master
COPY --from=build-env /src/Member.Api/out ./
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "Member.Api.dll"]