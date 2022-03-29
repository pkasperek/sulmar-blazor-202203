FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Shopper.BlazorWasm/Shopper.BlazorWasm.csproj", "Shopper.BlazorWasm/"]
RUN dotnet restore "Shopper.BlazorWasm/Shopper.BlazorWasm.csproj"
COPY . .
WORKDIR "/src/Shopper.BlazorWasm"
RUN dotnet build "Shopper.BlazorWasm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopper.BlazorWasm.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopper.BlazorWasm.dll"]
