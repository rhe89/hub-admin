FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY ./Admin.Web.Ui/Admin.Web.Ui.csproj ./Admin.Web.Ui/Admin.Web.Ui.csproj
COPY ./Admin.Integration/Admin.Integration.csproj ./Admin.Integration/Admin.Integration.csproj
COPY ./Admin.Services/Admin.Services.csproj ./Admin.Services/Admin.Services.csproj
COPY ./Admin.ViewModels/Admin.ViewModels.csproj ./Admin.ViewModels/Admin.ViewModels.csproj

COPY ./NuGet.Config ./NuGet.Config

RUN dotnet restore ./Admin.Web.Ui/Admin.Web.Ui.csproj --configfile NuGet.Config -p:HideWarningsAndErrors=true -p:EmitAssetsLogMessages=false

COPY /Admin.Web.Ui/ ./Admin.Web.Ui/
COPY /Admin.Integration/ ./Admin.Integration/
COPY /Admin.Services/ ./Admin.Services/
COPY /Admin.ViewModels/ ./Admin.ViewModels/

RUN dotnet publish ./Admin.Web.Ui/Admin.Web.Ui.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Admin.Web.Ui.dll"]
