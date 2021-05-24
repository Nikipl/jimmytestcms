FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JimmyTestCMS.Api/JimmyTestCMS.Api.csproj", "JimmyTestCMS.Api/"]
COPY ["JimmyTestCMS.DbUpdater/JimmyTestCMS.DbUpdater.csproj", "JimmyTestCMS.DbUpdater/"]
RUN dotnet restore "JimmyTestCMS.Api/JimmyTestCMS.Api.csproj"
RUN dotnet restore "JimmyTestCMS.DbUpdater/JimmyTestCMS.DbUpdater.csproj"
COPY . .
WORKDIR "/src/JimmyTestCMS.Api"
RUN dotnet build "JimmyTestCMS.Api.csproj" -c Release -o /app/build
WORKDIR "/src/JimmyTestCMS.DbUpdater"
RUN dotnet build "JimmyTestCMS.DbUpdater.csproj" -c Release -o /app/updater/build


FROM build AS publish
WORKDIR "/src/JimmyTestCMS.Api"
RUN dotnet publish "JimmyTestCMS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /app/updater/build ./updater
ENTRYPOINT ["dotnet", "JimmyTestCMS.Api.dll"]
