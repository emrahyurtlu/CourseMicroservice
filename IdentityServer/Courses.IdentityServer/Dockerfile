FROM mcr.microsoft.com/dotnet/sdk:3.1 as build

WORKDIR /app

EXPOSE 80

COPY Shared/Courses.Shared/*.csproj Shared/Courses.Shared/

COPY IdentityServer/Courses.IdentityServer/*.csproj IdentityServer/Courses.IdentityServer/ 

RUN dotnet restore  IdentityServer/Courses.IdentityServer/*.csproj

COPY . .

RUN dotnet publish IdentityServer/Courses.IdentityServer/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet","Courses.IdentityServer.dll" ]