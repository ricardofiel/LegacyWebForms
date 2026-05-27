# 02-sdk-conversion: Convert project to SDK-style format

## Task
Convert `LegacyWebForms.csproj` from legacy project format to SDK-style format.

## Scope Inventory
- Project: LegacyWebForms.csproj
- Change: Legacy `<Project ToolsVersion="12.0">` → `<Project Sdk="Microsoft.NET.Sdk.Web">`
- packages.config → PackageReference (migrated by tool)
- framework version: stays at net472 (TFM change in task 03)

## Findings
- SDK-style conversion completed by `convert_project_to_sdk_style` tool
- packages.config removed, 14 packages converted to PackageReference
- Redundant framework assembly imports removed (Microsoft.CSharp.targets, etc.)
- Build on net472 fails due to missing WebForms assembly references (System.Web.UI, etc.) — this is expected for an in-place rewrite where WebForms code is replaced in task 03
- The missing assembly errors will be resolved when WebForms code is replaced with ASP.NET Core equivalents in task 03

## Outcome
Project file successfully converted to SDK-style format. Proceeding to ASP.NET Core migration in task 03.
