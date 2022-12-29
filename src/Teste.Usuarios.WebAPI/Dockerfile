#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Teste.Usuarios.WebAPI/Teste.Usuarios.WebAPI.csproj", "Teste.Usuarios.WebAPI/"]
RUN dotnet restore "Teste.Usuarios.WebAPI/Teste.Usuarios.WebAPI.csproj"
COPY . .
WORKDIR "/src/Teste.Usuarios.WebAPI"
RUN dotnet build "Teste.Usuarios.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teste.Usuarios.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teste.Usuarios.WebAPI.dll"]