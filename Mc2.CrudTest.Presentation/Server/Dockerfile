#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mc2.CrudTest.Presentation/Server/Mc2.CrudTest.Presentation.Server.csproj", "Mc2.CrudTest.Presentation/Server/"]
COPY ["Mc2.CrudTest.Presentation/Shared/Mc2.CrudTest.Shared.csproj", "Mc2.CrudTest.Presentation/Shared/"]
COPY ["Framework.Domain/Framework.Domain.csproj", "Framework.Domain/"]
COPY ["Framework.Core/Framework.Core.csproj", "Framework.Core/"]
COPY ["Mc2.CrudTest.Presentation.Contract/Mc2.CrudTest.Presentation.Contract.csproj", "Mc2.CrudTest.Presentation.Contract/"]
COPY ["Mc2.CrudTest.QueryService/Mc2.CrudTest.QueryService.csproj", "Mc2.CrudTest.QueryService/"]
COPY ["Mc2.CrudTest.Domain.Contract/Mc2.CrudTest.Domain.Contract.csproj", "Mc2.CrudTest.Domain.Contract/"]
COPY ["Mc2.CrudTest.QueryService.Contract/Mc2.CrudTest.QueryService.Contract.csproj", "Mc2.CrudTest.QueryService.Contract/"]
COPY ["Mc2.CrudTest.Persistence/Mc2.CrudTest.Persistence.csproj", "Mc2.CrudTest.Persistence/"]
COPY ["Mc2.CrudTest.Domain/Mc2.CrudTest.Domain.csproj", "Mc2.CrudTest.Domain/"]
COPY ["Mc2.CrudTest.Application/Mc2.CrudTest.Application.csproj", "Mc2.CrudTest.Application/"]
COPY ["Mc2.CrudTest.Application.Contract/Mc2.CrudTest.Application.Contract.csproj", "Mc2.CrudTest.Application.Contract/"]
COPY ["Mc2.CrudTest.Presentation/Front/Mc2.CrudTest.Presentation.Front.csproj", "Mc2.CrudTest.Presentation/Front/"]
COPY ["Framework.Configuration.Autofac/Framework.Configuration.Autofac.csproj", "Framework.Configuration.Autofac/"]
COPY ["Framework.Bus.MassTransit/Framework.Bus.MassTransit.csproj", "Framework.Bus.MassTransit/"]
COPY ["Framework.EventStore.Sql/Framework.EventStore.Sql.csproj", "Framework.EventStore.Sql/"]
RUN dotnet restore "Mc2.CrudTest.Presentation/Server/Mc2.CrudTest.Presentation.Server.csproj"
COPY . .
WORKDIR "/src/Mc2.CrudTest.Presentation/Server"
RUN dotnet build "Mc2.CrudTest.Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mc2.CrudTest.Presentation.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.Presentation.Server.dll"]