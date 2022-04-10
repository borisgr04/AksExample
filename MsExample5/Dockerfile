#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MsExample5/MsExample5.csproj", "MsExample5/"]
RUN dotnet restore "MsExample5/MsExample5.csproj"
COPY . .
WORKDIR "/src/MsExample5"
RUN dotnet build "MsExample5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MsExample5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MsExample5.dll"]