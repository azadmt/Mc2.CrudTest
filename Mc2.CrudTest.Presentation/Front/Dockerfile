#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mc2.CrudTest.Presentation/Front/Mc2.CrudTest.Presentation.Front.csproj", "Mc2.CrudTest.Presentation/Front/"]
COPY ["Mc2.CrudTest.Presentation/Shared/Mc2.CrudTest.Shared.csproj", "Mc2.CrudTest.Presentation/Shared/"]
COPY ["Framework.Domain/Framework.Domain.csproj", "Framework.Domain/"]
COPY ["Framework.Core/Framework.Core.csproj", "Framework.Core/"]
COPY ["Mc2.CrudTest.Presentation.Contract/Mc2.CrudTest.Presentation.Contract.csproj", "Mc2.CrudTest.Presentation.Contract/"]
RUN dotnet restore "Mc2.CrudTest.Presentation/Front/Mc2.CrudTest.Presentation.Front.csproj"
COPY . .
WORKDIR "/src/Mc2.CrudTest.Presentation/Front"
RUN dotnet build "Mc2.CrudTest.Presentation.Front.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mc2.CrudTest.Presentation.Front.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.Presentation.Front.dll"]