# LegacyWebForms - Developer Guide

## Overview

This guide provides instructions for developers to set up, build, and work with the LegacyWebForms application.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Development Environment Setup](#development-environment-setup)
3. [Building the Project](#building-the-project)
4. [Project Structure](#project-structure)
5. [Development Workflow](#development-workflow)
6. [Common Development Tasks](#common-development-tasks)
7. [Debugging](#debugging)
8. [Testing](#testing)
9. [Best Practices](#best-practices)
10. [Troubleshooting](#troubleshooting)

---

## Prerequisites

### Windows Development Environment

**Required:**
- Windows 10/11 or Windows Server 2016+
- Visual Studio 2017 or later (Community, Professional, or Enterprise)
- .NET Framework 4.7.2 Developer Pack
- IIS Express (included with Visual Studio) or IIS

**Recommended:**
- Visual Studio 2022 (latest version)
- SQL Server (for future database integration)
- Git for version control

### Linux Development Environment (Build Only)

**Note:** While you can build the project on Linux using Mono, full development and testing capabilities are limited. Production deployment should be on Windows with IIS.

**Required:**
- Ubuntu 20.04+ or similar distribution
- Mono 6.8.0+ with development tools
- NuGet command-line tool

---

## Development Environment Setup

### Windows Setup

#### 1. Install Visual Studio

1. Download Visual Studio from https://visualstudio.microsoft.com/
2. During installation, select:
   - **ASP.NET and web development** workload
   - **.NET Framework 4.7.2 targeting pack**
   - **NuGet package manager**

#### 2. Clone the Repository

```bash
git clone https://github.com/mooncowboy/LegacyWebForms.git
cd LegacyWebForms
```

#### 3. Restore NuGet Packages

Visual Studio will automatically restore packages when you open the solution, or manually:

```bash
# Using NuGet CLI
nuget restore LegacyWebForms.sln

# Using Visual Studio
# Right-click solution → Restore NuGet Packages
```

#### 4. Build the Solution

```bash
# Using MSBuild
msbuild LegacyWebForms.sln /p:Configuration=Debug

# Using Visual Studio
# Press F6 or Build → Build Solution
```

### Linux Setup (Build Only)

#### 1. Install Mono

```bash
# Update package list
sudo apt update

# Install prerequisites
sudo apt install -y gnupg ca-certificates

# Install Mono complete package (takes ~2 minutes)
sudo apt install -y mono-complete mono-xbuild
```

**Important:** Do not cancel the Mono installation. It may take 1-2 minutes on slower systems.

#### 2. Install NuGet Tool

```bash
cd /tmp
wget https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
```

#### 3. Clone and Build

```bash
# Clone repository
git clone https://github.com/mooncowboy/LegacyWebForms.git
cd LegacyWebForms

# Restore packages (takes ~5-10 seconds)
mono /tmp/nuget.exe restore packages.config -PackagesDirectory packages

# Build project (takes ~2 seconds)
xbuild LegacyWebForms.sln
```

**Expected Build Output:**
- Warnings about TargetFrameworkVersion - EXPECTED
- Warning about Reference 'System.Web.Entity' - EXPECTED
- Warning about Target 'PipelineCollectFilesPhase' - EXPECTED
- Build should complete with **0 Errors**

---

## Building the Project

### Build Configurations

The project supports two build configurations:

#### Debug Configuration
- Unminified JavaScript and CSS
- Debug symbols included
- Verbose error messages
- ViewState not encrypted
- Ideal for development

#### Release Configuration
- Minified and bundled resources
- Optimized code
- Generic error messages
- ViewState encrypted
- Production-ready

### Building from Visual Studio

1. Select configuration from dropdown (Debug/Release)
2. Press **F6** or **Ctrl+Shift+B**
3. Check Output window for build results
4. Verify `bin/` directory contains `LegacyWebForms.dll`

### Building from Command Line (Windows)

```bash
# Debug build
msbuild LegacyWebForms.sln /p:Configuration=Debug

# Release build
msbuild LegacyWebForms.sln /p:Configuration=Release

# Clean before build
msbuild LegacyWebForms.sln /t:Clean,Build /p:Configuration=Release

# Verbose output
msbuild LegacyWebForms.sln /p:Configuration=Debug /v:detailed
```

### Building from Command Line (Linux)

```bash
# Restore packages first
mono /tmp/nuget.exe restore packages.config -PackagesDirectory packages

# Build with xbuild
xbuild LegacyWebForms.sln

# Clean build
xbuild LegacyWebForms.sln /t:Clean
xbuild LegacyWebForms.sln
```

---

## Project Structure

### Core Files

```
LegacyWebForms/
│
├── Global.asax / Global.asax.cs
│   Application-level events and configuration
│   Registers routes and bundles on startup
│
├── Web.config
│   Application configuration file
│   Connection strings, app settings, system.web settings
│
├── packages.config
│   NuGet package references
│   Version information for dependencies
│
├── LegacyWebForms.csproj
│   MSBuild project file
│   Defines compilation settings and file references
│
└── LegacyWebForms.sln
    Solution file for Visual Studio
```

### Source Code Organization

```
├── App_Start/
│   ├── BundleConfig.cs      # Script/style bundling
│   └── RouteConfig.cs       # URL routing
│
├── Properties/
│   └── AssemblyInfo.cs      # Assembly metadata
│
├── *.aspx files             # Page markup
├── *.aspx.cs files          # Page code-behind
├── *.Master files           # Layout templates
└── *.ascx files             # Reusable controls
```

### Static Resources

```
├── Content/                 # Stylesheets
│   ├── bootstrap.css
│   ├── bootstrap.min.css
│   └── Site.css
│
└── Scripts/                 # JavaScript
    ├── jquery-3.7.0.js
    ├── modernizr-2.8.3.js
    └── WebForms/
```

---

## Development Workflow

### Creating a New Page

1. **Add ASPX File**
   ```aspx
   <%@ Page Title="My Page" Language="C#" 
            MasterPageFile="~/Site.Master" 
            AutoEventWireup="true" 
            CodeBehind="MyPage.aspx.cs" 
            Inherits="LegacyWebForms.MyPage" %>

   <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h2><%: Title %></h2>
       <!-- Your content here -->
   </asp:Content>
   ```

2. **Add Code-Behind File (MyPage.aspx.cs)**
   ```csharp
   using System;
   using System.Web.UI;

   namespace LegacyWebForms
   {
       /// <summary>
       /// Code-behind for MyPage.
       /// </summary>
       public partial class MyPage : Page
       {
           protected void Page_Load(object sender, EventArgs e)
           {
               if (!IsPostBack)
               {
                   // First time page load
                   InitializePage();
               }
           }

           private void InitializePage()
           {
               // Initialize page controls and data
           }
       }
   }
   ```

3. **Add Navigation Link (Site.Master)**
   ```aspx
   <li><a runat="server" href="~/MyPage">My Page</a></li>
   ```

### Running the Application

#### From Visual Studio
1. Press **F5** (Debug) or **Ctrl+F5** (Run without debugging)
2. IIS Express starts automatically
3. Browser opens to default page
4. Application runs at `http://localhost:[port]/`

#### From IIS
1. Build the project in Release mode
2. Copy files to IIS website directory
3. Configure IIS website pointing to the directory
4. Navigate to website URL in browser

---

## Common Development Tasks

### Adding a New NuGet Package

```bash
# Visual Studio Package Manager Console
Install-Package PackageName -Version x.x.x

# NuGet CLI
nuget install PackageName -Version x.x.x -OutputDirectory packages
```

After adding, update references in `.csproj` file.

### Adding CSS Styles

1. Add styles to `/Content/Site.css`:
   ```css
   .my-custom-class {
       color: #333;
       font-size: 16px;
   }
   ```

2. Or create new CSS file and add to bundle:
   ```csharp
   // In BundleConfig.cs
   bundles.Add(new StyleBundle("~/Content/css").Include(
       "~/Content/bootstrap.min.css",
       "~/Content/Site.css",
       "~/Content/MyStyles.css"));
   ```

### Adding JavaScript

1. Add script to `/Scripts/` directory

2. Add to bundle in `BundleConfig.cs`:
   ```csharp
   bundles.Add(new ScriptBundle("~/bundles/myScripts").Include(
       "~/Scripts/myScript.js"));
   ```

3. Reference in page:
   ```aspx
   <%: Scripts.Render("~/bundles/myScripts") %>
   ```

### Working with Master Pages

All pages should use a master page for consistent layout:

```aspx
<%@ Page MasterPageFile="~/Site.Master" ... %>
```

Access master page from code-behind:
```csharp
var master = this.Master as SiteMaster;
if (master != null)
{
    // Interact with master page
}
```

### Creating User Controls

1. **Create ASCX file (MyControl.ascx)**
   ```aspx
   <%@ Control Language="C#" 
               AutoEventWireup="true" 
               CodeBehind="MyControl.ascx.cs" 
               Inherits="LegacyWebForms.MyControl" %>
   
   <div class="my-control">
       <asp:Label ID="lblMessage" runat="server" />
   </div>
   ```

2. **Create Code-Behind (MyControl.ascx.cs)**
   ```csharp
   public partial class MyControl : System.Web.UI.UserControl
   {
       public string Message
       {
           get { return lblMessage.Text; }
           set { lblMessage.Text = value; }
       }

       protected void Page_Load(object sender, EventArgs e)
       {
           // Control initialization
       }
   }
   ```

3. **Use in Page**
   ```aspx
   <%@ Register Src="~/MyControl.ascx" 
                TagPrefix="uc" 
                TagName="MyControl" %>
   
   <uc:MyControl runat="server" Message="Hello!" />
   ```

---

## Debugging

### Visual Studio Debugging

#### Set Breakpoints
1. Click in left margin of code editor (red dot appears)
2. Press F5 to start debugging
3. Execution pauses at breakpoint
4. Use Debug toolbar to step through code

#### Debug Windows
- **Locals** - View local variables
- **Watch** - Monitor specific expressions
- **Call Stack** - View method call hierarchy
- **Immediate Window** - Execute code during debugging

#### Useful Shortcuts
- **F5** - Start/Continue debugging
- **F10** - Step Over
- **F11** - Step Into
- **Shift+F11** - Step Out
- **Shift+F5** - Stop debugging
- **F9** - Toggle breakpoint

### Client-Side Debugging

Use browser developer tools:
- **Chrome**: F12 or Ctrl+Shift+I
- **Edge**: F12
- **Firefox**: F12 or Ctrl+Shift+I

Debug JavaScript in Sources tab, inspect DOM in Elements tab.

### Tracing

Enable tracing in `Web.config`:

```xml
<system.web>
  <trace enabled="true" 
         requestLimit="10" 
         pageOutput="true" 
         traceMode="SortByTime" 
         localOnly="true" />
</system.web>
```

View trace output at `/trace.axd`

---

## Testing

### Manual Testing

1. Build project in Debug mode
2. Run application (F5)
3. Navigate through pages
4. Test functionality
5. Verify responsive behavior on different screen sizes

### Testing Responsive Design

Test with browser developer tools:
1. Open developer tools (F12)
2. Click device toolbar icon
3. Select device presets or enter custom dimensions
4. Verify layout at different breakpoints

### Testing Mobile View

1. Use ViewSwitcher control to switch to mobile view
2. Or test with actual mobile devices
3. Verify Site.Mobile.Master rendering

---

## Best Practices

### Code Organization

1. **Use XML Documentation Comments**
   ```csharp
   /// <summary>
   /// Describes what the method does.
   /// </summary>
   /// <param name="parameter">Parameter description</param>
   /// <returns>Return value description</returns>
   public string MyMethod(string parameter)
   {
       // Implementation
   }
   ```

2. **Separate Concerns**
   - Keep page logic in code-behind
   - Move business logic to separate classes
   - Use data access layer for database operations

3. **Naming Conventions**
   - PascalCase for classes, methods, properties
   - camelCase for local variables, parameters
   - Prefix controls: `btn`, `txt`, `lbl`, `ddl`, etc.

### Performance

1. **Disable ViewState When Not Needed**
   ```aspx
   <asp:GridView ID="gv" runat="server" EnableViewState="false" />
   ```

2. **Use Output Caching**
   ```aspx
   <%@ OutputCache Duration="60" VaryByParam="none" %>
   ```

3. **Minimize Postbacks**
   - Use JavaScript for client-side validation
   - Batch operations when possible

### Security

1. **Validate Input**
   ```csharp
   if (String.IsNullOrWhiteSpace(txtInput.Text))
   {
       // Handle invalid input
   }
   ```

2. **Encode Output**
   ```aspx
   <%: Model.UserInput %>  <!-- Auto-encoded -->
   ```

3. **Use HTTPS**
   - Configure SSL in IIS
   - Redirect HTTP to HTTPS

### Version Control

1. **Don't commit:**
   - `bin/` directory
   - `obj/` directory
   - `packages/` directory
   - User-specific files (`.suo`, `.user`)

2. **Do commit:**
   - Source code files
   - `packages.config`
   - Documentation
   - Configuration templates

---

## Troubleshooting

### Build Errors

**"Could not resolve reference"**
- Solution: Restore NuGet packages
- Command: `nuget restore` or Visual Studio → Restore NuGet Packages

**"Target framework not found"**
- Solution: Install .NET Framework 4.7.2 Developer Pack
- Download from Microsoft

**"IIS Express couldn't start"**
- Solution: Delete `.vs` folder in solution directory
- Restart Visual Studio

### Runtime Errors

**"Configuration Error"**
- Check Web.config syntax
- Verify all closing tags
- Check connection strings

**"ViewState validation error"**
- Check machineKey in Web.config
- Ensure forms authentication is configured correctly

**"The resource cannot be found (404)"**
- Verify file exists in project
- Check URL routing configuration
- Ensure file is included in project

### Linux Build Issues

**"Mono installation timeout"**
- Increase timeout value (180+ seconds)
- Installation may take longer on slower systems
- Never cancel during package installation

**"Reference not resolved"**
- Expected warning for System.Web.Entity
- Does not prevent successful build
- Can be ignored

**"Cannot run application with XSP4"**
- Expected limitation on Linux
- Use Windows with IIS for runtime testing
- Build validation only on Linux

---

## Additional Resources

### Documentation
- [API Documentation](API_DOCUMENTATION.md)
- [Architecture Documentation](ARCHITECTURE.md)
- [Deployment Guide](DEPLOYMENT_GUIDE.md)

### External Resources
- [ASP.NET Web Forms Documentation](https://docs.microsoft.com/aspnet/web-forms/)
- [Bootstrap Documentation](https://getbootstrap.com/docs/5.2/)
- [jQuery Documentation](https://api.jquery.com/)
- [.NET Framework Documentation](https://docs.microsoft.com/dotnet/framework/)

### Community
- [Stack Overflow - ASP.NET](https://stackoverflow.com/questions/tagged/asp.net)
- [ASP.NET Forums](https://forums.asp.net/)

---

## Getting Help

If you encounter issues:

1. Check this troubleshooting guide
2. Review build output for specific errors
3. Search online for error messages
4. Check project GitHub Issues
5. Contact project maintainers

---

*Last Updated: 2025*
