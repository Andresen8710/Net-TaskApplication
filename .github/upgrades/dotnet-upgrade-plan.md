# .NET 9.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade App.Infraestructure\App.Infraestructure.csproj
4. Upgrade App.Web\App.Web.csproj

## Settings

This section contains settings and data used by execution steps.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                               | Current Version | New Version | Description                              |
|:-----------------------------------------------------------|:---------------:|:-----------:|:-----------------------------------------|
| Microsoft.EntityFrameworkCore                              | 8.0.12          | 9.0.0       | Recommended for .NET 9.0                 |
| Microsoft.EntityFrameworkCore.Design                       | 8.0.12          | 9.0.0       | Recommended for .NET 9.0                 |
| Microsoft.EntityFrameworkCore.SqlServer                    | 8.0.12          | 9.0.0       | Recommended for .NET 9.0                 |
| Microsoft.EntityFrameworkCore.Tools                        | 8.0.12          | 9.0.0       | Recommended for .NET 9.0                 |
| Microsoft.VisualStudio.Azure.Containers.Tools.Targets      | 1.19.6          | 1.19.6      | No compatible version found for .NET 9.0 |

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### App.Infraestructure\App.Infraestructure.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

NuGet packages changes:
  - Microsoft.EntityFrameworkCore should be updated from `8.0.12` to `9.0.0` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.Design should be updated from `8.0.12` to `9.0.0` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.SqlServer should be updated from `8.0.12` to `9.0.0` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.Tools should be updated from `8.0.12` to `9.0.0` (*recommended for .NET 9.0*)

#### App.Web\App.Web.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

NuGet packages changes:
  - Microsoft.EntityFrameworkCore.Design should be updated from `8.0.12` to `9.0.0` (*recommended for .NET 9.0*)

Other changes:
  - Microsoft.VisualStudio.Azure.Containers.Tools.Targets (1.19.6) - No se encontró versión compatible, mantener versión actual y verificar compatibilidad manualmente
