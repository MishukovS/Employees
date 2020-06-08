FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Employees.Api/Employees.Api.csproj", "src/Employees.Api/"]
COPY ["src/Employees.DataAcсess.EF/Employees.DataAcсess.EF.csproj", "src/Employees.DataAcсess.EF/"]
COPY ["src/Employees.Core/Employees.Core.csproj", "src/Employees.Core/"]
COPY ["src/Employees.DataAccess.Dapper/Employees.DataAccess.Dapper.csproj", "src/Employees.DataAccess.Dapper/"]
RUN dotnet restore "src/Employees.Api/Employees.Api.csproj"
COPY . .
WORKDIR "/src/src/Employees.Api"
RUN dotnet build "Employees.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Employees.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Employees.Api.dll"]