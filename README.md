# LegacyWebForms

**Successfully migrated from ASP.NET Web Forms (.NET Framework 4.7.2) to Blazor Server (.NET 8)**

## Migration Summary

This project has been migrated from the legacy ASP.NET Web Forms framework to modern .NET 8 using Blazor Server technology.

### What Changed

- **Framework**: Migrated from .NET Framework 4.7.2 to .NET 8
- **Technology**: Converted from ASP.NET Web Forms to Blazor Server
- **Project Structure**: Updated from legacy .csproj format to modern SDK-style project
- **Package Management**: Migrated from packages.config to PackageReference

### Features Preserved

- ✅ Home page content (Default.aspx → Home.razor)
- ✅ About page (About.aspx → About.razor)
- ✅ Contact page (Contact.aspx → Contact.razor)
- ✅ Master page layout (Site.Master → MainLayout.razor)
- ✅ Bootstrap styling and responsive design
- ✅ Navigation structure

### Technical Benefits

- **Performance**: Significantly faster build times and runtime performance
- **Modern Development**: Access to latest .NET features and C# language versions
- **Cross-Platform**: Can now run on Linux, macOS, and Windows
- **Container Support**: Ready for Docker and Kubernetes deployment
- **Security**: Latest security updates and patches from .NET 8

## Running the Application

```bash
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`

## Building the Application

```bash
dotnet build
```

## Technology Stack

- .NET 8
- Blazor Server
- Bootstrap 5.2.3
- jQuery 3.7.0
