# .NET Version Upgrade Plan — LegacyWebForms

## Overview

**Target**: Upgrade LegacyWebForms from ASP.NET WebForms (net472) to ASP.NET Core Razor Pages (net10.0)
**Scope**: 1 project, ~510 LOC, 3 ASPX pages, legacy project format

### Selected Strategy
**All-At-Once** — Single project upgraded atomically.
**Rationale**: 1 project, small codebase (510 LOC, 3 pages), low API complexity. In-place rewrite to ASP.NET Core Razor Pages.

## Tasks

### 01-prerequisites: Verify upgrade prerequisites

Verify that the .NET 10 SDK is installed and the global.json (if present) does not pin to an incompatible SDK version. This task ensures the toolchain is ready before structural changes begin.

The assessment found the project uses legacy non-SDK-style format. Confirm the SDK supports SDK-style project conversion and net10.0 TFM before proceeding.

**Done when**: `dotnet --version` shows .NET 10 SDK installed; no global.json conflicts with net10.0 target.

---

### 02-sdk-conversion: Convert project to SDK-style format

Convert `LegacyWebForms.csproj` from legacy project format (ToolsVersion="12.0", Microsoft.CSharp.targets imports) to SDK-style format. This structural change stays on the current TFM (net472) to isolate the format change from the framework upgrade. The `packages.config` must be migrated to `PackageReference` format as part of this conversion.

The project currently references many assemblies explicitly via `<Reference>` items and uses an `EnsureNuGetPackageBuildImports` target — these will be removed as SDK-style projects handle framework references automatically. The 14 NuGet packages currently in `packages.config` will be converted to `PackageReference` elements.

**Done when**: Solution builds successfully in SDK-style format on net472; `packages.config` removed; `LegacyWebForms.csproj` uses `<Project Sdk="Microsoft.NET.Sdk.Web">`.

---

### 03-aspnetcore-migration: Migrate to ASP.NET Core Razor Pages on .NET 10

Migrate the project from ASP.NET WebForms to ASP.NET Core Razor Pages targeting net10.0. ASP.NET WebForms is not supported in .NET 5+ — all WebForms-specific constructs must be replaced with ASP.NET Core equivalents.

This task covers:
- Update `TargetFramework` from `net472` to `net10.0` in the project file
- Replace `Global.asax`/`Global.asax.cs` with `Program.cs` (minimal hosting model with `WebApplication.CreateBuilder`)
- Convert the 3 ASPX pages (Default.aspx, About.aspx, Contact.aspx) to Razor Pages (`.cshtml` + PageModel `.cshtml.cs`)
- Convert `Site.Master` to `_Layout.cshtml` in `Pages/Shared/`
- Migrate `Site.Mobile.Master` and `ViewSwitcher.ascx` or remove if mobile switching is handled by responsive design
- Remove all 6 incompatible WebForms-specific NuGet packages (Microsoft.AspNet.FriendlyUrls, Microsoft.AspNet.FriendlyUrls.Core, Microsoft.AspNet.ScriptManager.MSAjax, Microsoft.AspNet.ScriptManager.WebForms, Microsoft.AspNet.Web.Optimization, Microsoft.AspNet.Web.Optimization.WebForms)
- Remove Microsoft.CodeDom.Providers.DotNetCompilerPlatform and Microsoft.Web.Infrastructure (built into framework)
- Migrate `Web.config` to `appsettings.json` and `launchSettings.json`; remove assembly binding redirects (.NET Core does not use them)
- Replace `App_Start/BundleConfig.cs` and `App_Start/RouteConfig.cs` with ASP.NET Core middleware pipeline in `Program.cs`
- Migrate static assets (bootstrap, jquery, content) to `wwwroot/`
- Add `<Nullable>enable</Nullable>` to the project file and fix any resulting null-safety warnings in C# code
- Update `Newtonsoft.Json` from 13.0.3 to 13.0.4 (upgrade recommended by assessment)

The assessment found 0 binary/source API incompatibility issues, making this largely a structural migration. The code-behind files (About.aspx.cs, Contact.aspx.cs, Default.aspx.cs, Site.Master.cs, Site.Mobile.Master.cs, ViewSwitcher.ascx.cs) contain minimal logic that maps straightforwardly to Razor Page PageModel classes.

**Done when**: Solution builds on net10.0 with 0 errors and 0 warnings; all pages render in browser; no WebForms assemblies referenced; `<Nullable>enable</Nullable>` set; `Newtonsoft.Json` updated to 13.0.4.

---

### 04-final-validation: Final build and validation

Perform a clean build of the solution, verify the application runs correctly, and document any deferred items. Ensure there are no remaining references to WebForms types, `System.Web`, or incompatible packages.

**Done when**: `dotnet build` produces 0 errors and 0 warnings; application starts and serves all pages; no references to incompatible packages remain.
