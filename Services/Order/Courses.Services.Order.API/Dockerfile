FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build

WORKDIR /app

EXPOSE 80

COPY Shared/Courses.Shared/*.csproj Shared/Courses.Shared/

COPY Services/Order/Courses.Services.Order.Application/*.csproj Services/Order/Courses.Services.Order.Application/

COPY Services/Order/Courses.Services.Order.Domain/*.csproj Services/Order/Courses.Services.Order.Domain/

COPY Services/Order/Courses.Services.Order.Domain.Core/*.csproj Services/Order/Courses.Services.Order.Domain.Core/

COPY Services/Order/Courses.Services.Order.Infrastructure/*.csproj Services/Order/Courses.Services.Order.Infrastructure/

COPY Services/Order/Courses.Services.Order.API/*.csproj Services/Order/Courses.Services.Order.API/

RUN dotnet restore Services/Order/Courses.Services.Order.API/*.csproj

COPY . .

RUN dotnet publish Services/Order/Courses.Services.Order.API/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet","Courses.Services.Order.API.dll" ]