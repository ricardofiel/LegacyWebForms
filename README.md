# LegacyWebForms

ASP.NET Core 8 MVC Web Application (Migrated from ASP.NET Web Forms .NET Framework 4.7.2)

## Overview

This application has been successfully migrated from ASP.NET Web Forms (.NET Framework 4.7.2) to ASP.NET Core 8 MVC.

## Technology Stack

- **Framework**: .NET 8
- **Architecture**: ASP.NET Core MVC
- **UI Framework**: Bootstrap 5.2.3
- **JavaScript**: jQuery 3.7.0

## Project Structure

```
/
├── Controllers/          # MVC Controllers
│   └── HomeController.cs
├── Views/               # Razor Views
│   ├── Home/
│   │   ├── Index.cshtml
│   │   ├── About.cshtml
│   │   └── Contact.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── _ViewStart.cshtml
│   └── _ViewImports.cshtml
├── wwwroot/            # Static files
│   ├── css/
│   ├── js/
│   └── favicon.ico
├── Program.cs          # Application entry point
├── appsettings.json    # Configuration
└── LegacyWebForms.csproj
```

## Building and Running

### Prerequisites
- .NET 8 SDK or later

### Build
```bash
dotnet build
```

### Run
```bash
dotnet run
```

The application will be available at `http://localhost:5000` or `https://localhost:5001`.

## Pages

- **Home** (`/` or `/Home/Index`) - Landing page with ASP.NET information
- **About** (`/Home/About`) - About page
- **Contact** (`/Home/Contact`) - Contact information page

## Migration Notes

The original ASP.NET Web Forms application has been completely converted to ASP.NET Core 8 MVC:

- All `.aspx` pages converted to Razor views (`.cshtml`)
- Master pages converted to `_Layout.cshtml`
- Code-behind files replaced with MVC Controllers
- Static assets moved to `wwwroot/`
- Modern .NET 8 project structure with minimal hosting model

Old Web Forms files have been preserved in the `.old_webforms/` directory for reference.
