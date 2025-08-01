# Legacy Web Forms - Migrated to ASP.NET Core

This project has been migrated from ASP.NET Web Forms (.NET Framework 4.7.2) to ASP.NET Core (.NET 8/9) for modern deployment and Azure App Service compatibility.

## Migration Summary

### What Changed
- **Project Format**: Converted from legacy .csproj to modern SDK-style project
- **Framework**: Migrated from .NET Framework 4.7.2 to .NET 8 (ready for .NET 9)
- **Web Technology**: Converted from Web Forms to ASP.NET Core Razor Pages
- **Dependencies**: Removed packages.config, using modern PackageReference
- **Structure**: Modern ASP.NET Core folder structure with wwwroot for static files

### Pages Migrated
- `Default.aspx` → `Pages/Index.cshtml`
- `About.aspx` → `Pages/About.cshtml`  
- `Contact.aspx` → `Pages/Contact.cshtml`
- `Site.Master` → `Pages/Shared/_Layout.cshtml`

## Running the Application

### Prerequisites
- .NET 8 SDK or later
- For .NET 9: Update `TargetFramework` in `LegacyWebForms.csproj` to `net9.0`

### Local Development
```bash
dotnet restore
dotnet build
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## Azure App Service Deployment

### Method 1: Using Azure CLI
```bash
# Create a resource group
az group create --name myResourceGroup --location "East US"

# Create an App Service plan
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --sku B1 --is-linux

# Create a web app
az webapp create --resource-group myResourceGroup --plan myAppServicePlan --name myUniqueAppName --runtime "DOTNETCORE|8.0"

# Deploy from local Git
az webapp deployment source config-local-git --name myUniqueAppName --resource-group myResourceGroup
```

### Method 2: Using Visual Studio
1. Right-click on the project in Solution Explorer
2. Select "Publish"
3. Choose "Azure" as the target
4. Select "Azure App Service (Windows)" or "Azure App Service (Linux)"
5. Configure your subscription and create/select an App Service
6. Click "Publish"

### Method 3: Using GitHub Actions (Recommended)
Create `.github/workflows/deploy.yml`:

```yaml
name: Deploy to Azure App Service

on:
  push:
    branches: [ main ]

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v2
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 8.0.x
        
    - name: Restore dependencies
      run: dotnet restore
      
    - name: Build
      run: dotnet build --no-restore
      
    - name: Publish
      run: dotnet publish -c Release -o ./publish
      
    - name: Deploy to Azure App Service
      uses: azure/webapps-deploy@v2
      with:
        app-name: 'your-app-name'
        publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
        package: ./publish
```

## Configuration

### Environment Variables (Azure App Service)
- `ASPNETCORE_ENVIRONMENT`: Set to "Production"
- `ASPNETCORE_URLS`: Set to "http://+:80" for Azure

### Application Settings
Configure in Azure Portal → App Service → Configuration:
- Any custom app settings can be added here
- Connection strings if needed

## Features Maintained
- Original layout and styling (Bootstrap)
- Navigation structure
- All page content
- Responsive design
- Static file serving

## .NET 9 Upgrade Path
When .NET 9 becomes available:
1. Update `TargetFramework` in `LegacyWebForms.csproj` from `net8.0` to `net9.0`
2. Update any package references to .NET 9 compatible versions
3. Test and deploy

## Performance Benefits
- Faster startup times
- Reduced memory footprint
- Cross-platform compatibility
- Better Azure App Service integration
- Modern deployment options
