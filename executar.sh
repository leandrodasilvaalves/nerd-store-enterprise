#!/bin/bash

dotnet watch --project src/services/NSE.Identidade.API/NSE.Identidade.API.csproj run &
dotnet watch --project src/services/NSE.Catalogo.API/NSE.Catalogo.API.csproj run &
dotnet watch --project src/services/NSE.Cliente.API/NSE.Cliente.API.csproj run &
dotnet watch --project src/web/NSE.WebApp.MVC/NSE.WebApp.MVC.csproj run &

