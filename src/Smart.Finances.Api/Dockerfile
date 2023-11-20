#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Smart.Finances/Smart.Finances.csproj", "Smart.Finances/"]
RUN dotnet restore "Smart.Finances/Smart.Finances.csproj"
COPY . .
WORKDIR "/src/Smart.Finances"
RUN dotnet build "Smart.Finances.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smart.Finances.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smart.Finances.dll"]