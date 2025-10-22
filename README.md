# LegacyWebForms

ASP.NET Web Forms application built on .NET Framework 4.7.2 with Bootstrap 5.2.3 and jQuery 3.7.0.

## Overview

LegacyWebForms is a classic ASP.NET Web Forms application demonstrating the traditional three-tier architecture pattern with modern UI components. The application features responsive design, SEO-friendly URLs, and mobile/desktop view switching capabilities.

## Features

- **Responsive Design** - Bootstrap 5.2.3 for mobile-first responsive layout
- **SEO-Friendly URLs** - Microsoft ASP.NET Friendly URLs for cleaner URLs
- **Mobile Support** - Automatic mobile detection with view switcher
- **Script Bundling** - Optimized resource loading with bundling and minification
- **Modern JavaScript** - jQuery 3.7.0 and Modernizr 2.8.3
- **Master Pages** - Consistent layout across all pages
- **Event-Driven** - Traditional ASP.NET Web Forms event model

## Technology Stack

### Server-Side
- **.NET Framework** 4.7.2
- **ASP.NET Web Forms** 4.7.2
- **C#** 7.3

### Client-Side
- **Bootstrap** 5.2.3
- **jQuery** 3.7.0
- **Modernizr** 2.8.3
- **HTML5** & **CSS3**

### NuGet Packages
- Microsoft.AspNet.FriendlyUrls 1.0.2
- Microsoft.AspNet.Web.Optimization 1.1.3
- Microsoft.AspNet.ScriptManager.MSAjax 5.0.0
- Microsoft.AspNet.ScriptManager.WebForms 5.0.0
- Newtonsoft.Json 13.0.3
- WebGrease 1.6.0
- Antlr 3.5.0.2

## Quick Start

### Prerequisites

- Windows 10/11 or Windows Server 2016+
- Visual Studio 2017 or later
- .NET Framework 4.7.2 or later
- IIS or IIS Express

### Build and Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/mooncowboy/LegacyWebForms.git
   cd LegacyWebForms
   ```

2. **Restore NuGet packages**
   ```bash
   nuget restore LegacyWebForms.sln
   ```

3. **Build the solution**
   ```bash
   msbuild LegacyWebForms.sln /p:Configuration=Release
   ```

4. **Run in Visual Studio**
   - Open `LegacyWebForms.sln` in Visual Studio
   - Press F5 to run with debugging
   - Or Ctrl+F5 to run without debugging

## Project Structure

```
LegacyWebForms/
├── App_Start/              # Application configuration
│   ├── BundleConfig.cs    # Script and style bundling
│   └── RouteConfig.cs     # URL routing
├── Content/               # CSS stylesheets
├── Scripts/               # JavaScript files
├── Properties/            # Assembly information
├── docs/                  # Documentation
├── *.aspx                 # Web Forms pages
├── *.Master               # Master page layouts
├── *.ascx                 # User controls
├── Global.asax            # Application events
└── Web.config             # Configuration file
```

## Documentation

Comprehensive documentation is available in the `/docs` directory:

- **[API Documentation](docs/API_DOCUMENTATION.md)** - Detailed API reference for all classes, methods, and objects
- **[Architecture Documentation](docs/ARCHITECTURE.md)** - Application architecture, patterns, and design decisions
- **[Developer Guide](docs/DEVELOPER_GUIDE.md)** - Setup instructions, development workflow, and best practices
- **[Deployment Guide](docs/DEPLOYMENT_GUIDE.md)** - Step-by-step deployment instructions for IIS and Azure

## Pages

### Default.aspx (Home)
The main landing page featuring:
- Introduction to ASP.NET Web Forms
- Getting Started information
- Libraries section
- Web Hosting information

### About.aspx
Application information and description page.

### Contact.aspx
Contact information page with:
- Organization address
- Phone number
- Email contacts

## Key Components

### Global.asax
Application-level event handling and configuration initialization.

### BundleConfig
Configures script and style bundles for optimized resource loading:
- WebForms client scripts bundle
- Microsoft Ajax scripts bundle
- Modernizr bundle
- jQuery registration with CDN support

### RouteConfig
Configures Friendly URLs for SEO-friendly routing with automatic .aspx extension removal.

### ViewSwitcher
User control for switching between Mobile and Desktop views with automatic device detection.

## Building on Linux (Build Only)

While development and testing require Windows, you can build the project on Linux using Mono:

```bash
# Install Mono (takes ~2 minutes, do not cancel)
sudo apt update
sudo apt install -y gnupg ca-certificates
sudo apt install -y mono-complete mono-xbuild

# Download NuGet tool
cd /tmp
wget https://dist.nuget.org/win-x86-commandline/latest/nuget.exe

# Restore packages and build
cd /path/to/LegacyWebForms
mono /tmp/nuget.exe restore packages.config -PackagesDirectory packages
xbuild LegacyWebForms.sln
```

**Note:** Runtime testing requires Windows with IIS. Linux build is for compilation verification only.

## Contributing

Contributions are welcome! Please ensure:
- Code builds successfully
- Documentation is updated
- Changes are tested on Windows with IIS
- XML documentation comments are added to new code

## License

See [LICENSE](LICENSE) file for details.

## Support

For issues, questions, or contributions:
- Open an issue on GitHub
- Review documentation in `/docs` directory
- Check troubleshooting sections in guides

## Version History

**Version 1.0.0**
- Initial release
- ASP.NET Web Forms on .NET Framework 4.7.2
- Bootstrap 5.2.3 integration
- jQuery 3.7.0 support
- Friendly URLs enabled
- Mobile/Desktop view switching
- Comprehensive documentation

---

*Built with ASP.NET Web Forms • Copyright © 2025*
