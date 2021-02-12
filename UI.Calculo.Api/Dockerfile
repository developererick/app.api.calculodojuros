#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["UI.Calculo.Api/UI.Calculo.Api.csproj", "UI.Calculo.Api/"]
RUN dotnet restore "UI.Calculo.Api/UI.Calculo.Api.csproj"
COPY . .
WORKDIR "/src/UI.Calculo.Api"
RUN dotnet build "UI.Calculo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UI.Calculo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UI.Calculo.Api.dll"]