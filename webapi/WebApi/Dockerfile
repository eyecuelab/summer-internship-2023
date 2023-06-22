# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /webapi
COPY *.csproj . 
RUN dotnet restore 
COPY webapi .
RUN dotnet publish -c Release -o /webapi

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /webapi
COPY --from=build-env /webapi .
EXPOSE 80
ENTRYPOINT ["dotnet", "webapi.dll"] 

# # Copy everything
# COPY . ./
# # Restore as distinct layers
# RUN dotnet restore
# # Build and publish a release
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:7.0
# WORKDIR /App
# COPY --from=build-env /App/out .
# ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]