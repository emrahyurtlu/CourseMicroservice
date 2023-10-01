FROM mcr.microsoft.com/dotnet/sdk:7.0 as build

WORKDIR /app

EXPOSE 80

COPY  Courses.Gateway/*.csproj  Courses.Gateway/

RUN dotnet restore Courses.Gateway/*.csproj

COPY . .

RUN dotnet publish Courses.Gateway/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet","Courses.Gateway.dll" ]