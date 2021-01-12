#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Helpdesk_Web/Helpdesk_Web.csproj", "Helpdesk_Web/"]
RUN dotnet restore "Helpdesk_Web/Helpdesk_Web.csproj"
COPY . .
WORKDIR "/src/Helpdesk_Web"
RUN dotnet build "Helpdesk_Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Helpdesk_Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helpdesk_Web.dll"]