FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.18 as build

WORKDIR /app

EXPOSE 80

COPY Shared/Courses.Shared/*.csproj Shared/Courses.Shared/

COPY Services/Catalog/Courses.Services.Catalog/*.csproj Services/Catalog/Courses.Services.Catalog/

RUN dotnet restore Services/Catalog/Courses.Services.Catalog/*.csproj

COPY . .

RUN dotnet publish Services/Catalog/Courses.Services.Catalog/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine3.18 as runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet","Courses.Services.Catalog.dll" ]