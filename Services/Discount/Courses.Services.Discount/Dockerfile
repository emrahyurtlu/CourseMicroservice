FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.18 as build

WORKDIR /app

EXPOSE 80

COPY Shared/Courses.Shared/*.csproj Shared/Courses.Shared/

COPY Services/Discount/Courses.Services.Discount/*.csproj Services/Discount/Courses.Services.Discount/

RUN dotnet restore Services/Discount/Courses.Services.Discount/*.csproj

COPY . .

RUN dotnet publish Services/Discount/Courses.Services.Discount/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine3.18 as runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet","Courses.Services.Discount.dll" ]