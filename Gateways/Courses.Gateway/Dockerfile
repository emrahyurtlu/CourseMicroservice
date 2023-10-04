FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.18 as build

WORKDIR /app

EXPOSE 80

COPY  Gateways/Courses.Gateway/*.csproj  Gateways/Courses.Gateway/

RUN dotnet restore Gateways/Courses.Gateway/*.csproj

COPY . .

RUN dotnet publish Gateways/Courses.Gateway/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine3.18 as runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet","Courses.Gateway.dll" ]