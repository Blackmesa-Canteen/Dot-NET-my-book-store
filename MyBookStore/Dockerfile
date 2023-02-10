FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyBookStore/MyBookStore.csproj", "MyBookStore/"]
RUN dotnet restore "MyBookStore/MyBookStore.csproj"
COPY . .
WORKDIR "/src/MyBookStore"
RUN dotnet build "MyBookStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBookStore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBookStore.dll"]
