# .NET 8.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 8.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 8.0 upgrade.
3. Upgrade LegacyWebForms.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

No projects are excluded from this upgrade.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                      | Current Version | New Version | Description                                    |
|:--------------------------------------------------|:---------------:|:-----------:|:-----------------------------------------------|
| Antlr                                             | 3.5.0.2         | 4.6.6       | Recommended for .NET 8.0 (upgrade to Antlr4)   |
| Microsoft.AspNet.FriendlyUrls                     | 1.0.2           | Remove      | No supported version available for .NET 8.0    |
| Microsoft.AspNet.FriendlyUrls.Core                | 1.0.2           | Remove      | No supported version available for .NET 8.0    |
| Microsoft.AspNet.ScriptManager.MSAjax             | 5.0.0           | Remove      | No supported version available for .NET 8.0    |
| Microsoft.AspNet.ScriptManager.WebForms           | 5.0.0           | Remove      | No supported version available for .NET 8.0    |
| Microsoft.AspNet.Web.Optimization                 | 1.1.3           | Remove      | No supported version available for .NET 8.0    |
| Microsoft.AspNet.Web.Optimization.WebForms        | 1.1.3           | Remove      | No supported version available for .NET 8.0    |
| Microsoft.CodeDom.Providers.DotNetCompilerPlatform| 2.0.1           | Remove      | Functionality included with .NET 8.0           |
| Microsoft.Web.Infrastructure                      | 2.0.0           | Remove      | Functionality included with .NET 8.0           |
| Newtonsoft.Json                                   | 13.0.3          | 13.0.4      | Recommended for .NET 8.0                       |

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### LegacyWebForms.csproj modifications

Project properties changes:
  - Target framework should be changed from `net472` to `net8.0`
  - Project file needs to be converted to SDK-style format

NuGet packages changes:
  - Antlr should be updated from `3.5.0.2` to `Antlr4 4.6.6` (*recommended for .NET 8.0*)
  - Microsoft.AspNet.FriendlyUrls should be removed (*no supported version available*)
  - Microsoft.AspNet.FriendlyUrls.Core should be removed (*no supported version available*)
  - Microsoft.AspNet.ScriptManager.MSAjax should be removed (*no supported version available*)
  - Microsoft.AspNet.ScriptManager.WebForms should be removed (*no supported version available*)
  - Microsoft.AspNet.Web.Optimization should be removed (*no supported version available*)
  - Microsoft.AspNet.Web.Optimization.WebForms should be removed (*no supported version available*)
  - Microsoft.CodeDom.Providers.DotNetCompilerPlatform should be removed (*functionality included with .NET 8.0*)
  - Microsoft.Web.Infrastructure should be removed (*functionality included with .NET 8.0*)
  - Newtonsoft.Json should be updated from `13.0.3` to `13.0.4` (*recommended for .NET 8.0*)

Feature upgrades:
  - System.Web.Optimization bundling and minification is not supported in .NET Core and should be replaced with actual HTML tags pointing to content files
  - Routes registration via RouteCollection is not supported in .NET Core and needs to be converted to route mappings on the application object
  - Convert application initialization code from Global.asax.cs to .NET Core and clean up Global.asax.cs

Other changes:
  - None
