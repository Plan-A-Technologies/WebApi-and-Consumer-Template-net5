#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Template.Consumer/Template.Consumer.csproj", "Template.Consumer/"]
RUN dotnet restore "Template.Consumer/Template.Consumer.csproj"
COPY . .
WORKDIR "/src/Template.Worker"
RUN dotnet build "Template.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Worker.dll"]