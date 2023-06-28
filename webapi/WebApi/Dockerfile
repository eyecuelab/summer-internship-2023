# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /WebApi
COPY *.csproj . 
RUN dotnet restore 
COPY . .
RUN dotnet publish -c Release -o /WebApi

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /WebApi
COPY --from=build-env /WebApi .
EXPOSE 80
ENTRYPOINT ["dotnet", "WebApi.dll"] 