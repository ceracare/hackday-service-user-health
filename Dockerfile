FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["serviceUserHealth.csproj", "./"]
RUN dotnet restore "serviceUserHealth.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "serviceUserHealth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "serviceUserHealth.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5167
ENV ASPNETCORE_URLS=http://+:5167

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "serviceUserHealth.dll"]
