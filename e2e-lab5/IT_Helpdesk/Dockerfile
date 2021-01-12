#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["IT_Helpdesk/IT_Helpdesk.csproj", "IT_Helpdesk/"]
RUN dotnet restore "IT_Helpdesk/IT_Helpdesk.csproj"
COPY . .
WORKDIR "/src/IT_Helpdesk"
RUN dotnet build "IT_Helpdesk.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IT_Helpdesk.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IT_Helpdesk.dll"]
