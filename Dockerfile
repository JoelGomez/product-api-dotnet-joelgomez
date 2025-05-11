FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR webapi

EXPOSE 8080
EXPOSE 5024
#COPY PROJECT FILES
COPY ./api-restfull-net8.csproj ./
RUN dotnet restore

#COPY everything else
COPY . ./
RUN dotnet publish -c Release -o out

#BUILD image
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /webapi
COPY --from=build /webapi/out ./
ENTRYPOINT [ "dotnet", "api-restfull-net8.dll" ]



