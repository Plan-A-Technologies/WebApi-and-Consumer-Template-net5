FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PlayerSoft.Template.Api/PlayerSoft.Template.Api.csproj", "PlayerSoft.Template.Api/"]
RUN dotnet restore "PlayerSoft.Template.Api/PlayerSoft.Template.Api.csproj"
COPY . .
WORKDIR "/src/PlayerSoft.Template.Api"
RUN dotnet build "PlayerSoft.Template.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlayerSoft.Template.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlayerSoft.Template.Api.dll"]