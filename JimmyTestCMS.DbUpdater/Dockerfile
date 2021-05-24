FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["JimmyTestCMS.DbUpdater/JimmyTestCMS.DbUpdater.csproj", "JimmyTestCMS.DbUpdater/"]
RUN dotnet restore "JimmyTestCMS.DbUpdater/JimmyTestCMS.DbUpdater.csproj"
COPY . .
WORKDIR "/src/JimmyTestCMS.DbUpdater"
RUN dotnet build "JimmyTestCMS.DbUpdater.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JimmyTestCMS.DbUpdater.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JimmyTestCMS.DbUpdater.dll"]
