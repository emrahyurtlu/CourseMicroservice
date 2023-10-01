FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build

WORKDIR /app

EXPOSE 80

COPY Shared/Courses.Shared/*.csproj Shared/Courses.Shared/

COPY Services/FakePayment/Courses.Services.FakePayment/*.csproj Services/FakePayment/Courses.Services.FakePayment/

RUN dotnet restore Services/FakePayment/Courses.Services.FakePayment/*.csproj

COPY . .

RUN dotnet publish Services/FakePayment/Courses.Services.FakePayment/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet","Courses.Services.FakePayment.dll" ]