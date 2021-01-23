#!/bin/bash

dotnet run --project src/services/NSE.Identidade.API/NSE.Identidade.API.csproj &
dotnet run --project src/services/NSE.Catalogo.API/NSE.Catalogo.API.csproj &
dotnet run --project src/services/NSE.Cliente.API/NSE.Cliente.API.csproj &
dotnet run --project src/web/NSE.WebApp.MVC/NSE.WebApp.MVC.csproj &

