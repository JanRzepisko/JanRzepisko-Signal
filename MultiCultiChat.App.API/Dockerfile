#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MultiCultiChat.App.API/MultiCultiChat.App.API.csproj", "MultiCultiChat.App.API/"]
COPY ["MultiCultiChat.App.Application/MultiCultiChat.App.Application.csproj", "MultiCultiChat.App.Application/"]
COPY ["MultiCultiChat.App.Domain/MultiCultiChat.App.Domain.csproj", "MultiCultiChat.App.Domain/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["MultiCultiChat.App.Infrastructure/MultiCultiChat.App.Infrastructure.csproj", "MultiCultiChat.App.Infrastructure/"]
RUN dotnet restore "MultiCultiChat.App.API/MultiCultiChat.App.API.csproj"
COPY . .
WORKDIR "/src/MultiCultiChat.App.API"
RUN dotnet build "MultiCultiChat.App.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MultiCultiChat.App.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultiCultiChat.App.API.dll"]