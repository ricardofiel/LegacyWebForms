# LegacyWebForms

ASP.NET Web Forms application targeting .NET Framework 4.7.2 with Bootstrap 5.2.3, jQuery 3.7.0, and standard ASP.NET WebForms libraries. This is a classic three-tier web application with master pages, WebForms pages (.aspx), and code-behind files (.aspx.cs).

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

## Working Effectively

### Environment Setup and Build Process
- **CRITICAL**: This project requires Mono on Linux since .NET Framework projects cannot be built with .NET Core SDK.
- Install Mono development environment:
  - `sudo apt update && sudo apt install -y gnupg ca-certificates`
  - `sudo apt install -y mono-complete mono-xbuild` -- takes 1 minute 37 seconds. NEVER CANCEL. Set timeout to 180+ seconds.
- Install NuGet tool:
  - `cd /tmp && wget https://dist.nuget.org/win-x86-commandline/latest/nuget.exe`
- Restore NuGet packages:
  - `mono /tmp/nuget.exe restore packages.config -PackagesDirectory packages` -- takes 5.5 seconds. Set timeout to 60+ seconds.
- Build the project:
  - `xbuild LegacyWebForms.sln` -- takes 1.6 seconds with expected warnings but successful build. Set timeout to 60+ seconds.

### Build Expectations and Warnings
- **NEVER CANCEL** any of the above build commands. Mono installation may take longer on slower systems.
- Build will show warnings about:
  - "TargetFrameworkVersion 'v4.7.2' not supported by this toolset (ToolsVersion: 14.0)" - EXPECTED
  - "Reference 'System.Web.Entity' not resolved" - EXPECTED  
  - "Target 'PipelineCollectFilesPhase', not found" - EXPECTED
- These warnings are normal and do not prevent successful compilation.
- Build artifacts are created in `bin/` directory including `LegacyWebForms.dll` and all dependencies.

## Validation

### Build Validation
- Always run the complete build sequence after any code changes:
  1. `mono /tmp/nuget.exe restore packages.config -PackagesDirectory packages` 
  2. `xbuild LegacyWebForms.sln`
- Check that `bin/LegacyWebForms.dll` is created with recent timestamp.
- Build succeeds with warnings but no errors.

### Runtime Limitations
- **IMPORTANT**: Web application testing is limited. XSP4 web server (included with Mono) has compatibility issues and cannot successfully run the application.
- Do NOT attempt to use `xsp4` for testing - it fails with TypeLoadException.
- Static content validation can be done by examining generated files in `bin/` directory.
- For functional testing, deployment to a Windows IIS environment or Windows with Visual Studio is required.

### Code Quality
- No linting tools are available in this environment for ASP.NET WebForms.
- Use Mono C# compiler directly for syntax validation: `mcs --version` (version 6.8.0.105)
- Always validate code compiles successfully with `xbuild` before committing.

## Common Tasks

### Repository Structure
```
/home/runner/work/LegacyWebForms/LegacyWebForms/
├── About.aspx (About page)
├── Contact.aspx (Contact page) 
├── Default.aspx (Home page)
├── Site.Master (Master page layout)
├── Site.Mobile.Master (Mobile master page)
├── App_Start/ (Configuration classes)
│   ├── BundleConfig.cs (Asset bundling)
│   └── RouteConfig.cs (URL routing)
├── Content/ (CSS files, Bootstrap 5.2.3)
├── Scripts/ (JavaScript files, jQuery 3.7.0)
├── Web.config (Application configuration)
├── packages.config (NuGet package references)
├── LegacyWebForms.csproj (Project file)
└── bin/ (Build output - created during build)
```

### Key Technologies Used
- **ASP.NET Web Forms**: .NET Framework 4.7.2
- **UI Framework**: Bootstrap 5.2.3 
- **JavaScript**: jQuery 3.7.0, Modernizr 2.8.3
- **Bundling**: Microsoft.AspNet.Web.Optimization 1.1.3
- **JSON**: Newtonsoft.Json 13.0.3
- **Friendly URLs**: Microsoft.AspNet.FriendlyUrls 1.0.2

### Working with Code Changes
- **Page Development**: Edit `.aspx` files for markup, `.aspx.cs` for code-behind
- **Master Pages**: Modify `Site.Master` for layout changes
- **Styling**: Update files in `Content/` directory (Bootstrap-based)
- **Configuration**: Modify `Web.config` for app settings, `BundleConfig.cs` for assets
- Always rebuild after changes: `xbuild LegacyWebForms.sln`

### Troubleshooting Build Issues
- If NuGet restore fails: Check internet connectivity, retry the restore command
- If build fails with new errors: Verify all required packages are restored in `packages/` directory
- Missing assemblies: Check `packages.config` matches actual package versions in `packages/` directory
- Clean build: Delete `bin/` and `obj/` directories, then rebuild

## Environment Constraints

### What Works
- Full compilation and build process via Mono
- NuGet package management
- Code syntax validation
- Static file generation
- Development on Linux environments

### What Does NOT Work
- **Web server execution**: XSP4 fails with runtime errors
- **Interactive testing**: Cannot run and browse the web application locally
- **Debugging**: No interactive debugging capabilities available
- **Package updates**: Limited to packages compatible with .NET Framework 4.7.2

### Development Workflow
1. Make code changes to `.aspx`, `.aspx.cs`, or configuration files
2. Run NuGet restore: `mono /tmp/nuget.exe restore packages.config -PackagesDirectory packages`
3. Build project: `xbuild LegacyWebForms.sln`  
4. Verify successful compilation (warnings are expected, errors are not)
5. For runtime testing, deploy to Windows/IIS environment

Always ensure build succeeds before committing changes. The build process is your primary validation tool in this environment.