# LegacyWebForms - Deployment Guide

## Overview

This guide provides step-by-step instructions for deploying the LegacyWebForms application to various hosting environments.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Pre-Deployment Checklist](#pre-deployment-checklist)
3. [Deployment to IIS (Windows Server)](#deployment-to-iis-windows-server)
4. [Deployment to Azure App Service](#deployment-to-azure-app-service)
5. [Configuration Management](#configuration-management)
6. [Security Hardening](#security-hardening)
7. [Performance Optimization](#performance-optimization)
8. [Monitoring and Logging](#monitoring-and-logging)
9. [Backup and Recovery](#backup-and-recovery)
10. [Troubleshooting](#troubleshooting)

---

## Prerequisites

### Server Requirements

**Operating System:**
- Windows Server 2016 or later (recommended: Windows Server 2019/2022)
- Windows 10/11 (for testing only, not production)

**Software Requirements:**
- IIS 10.0 or later
- .NET Framework 4.7.2 or later
- ASP.NET 4.7.2 runtime
- URL Rewrite Module (optional, for advanced routing)

**Hardware Requirements:**
- **CPU:** 2+ cores (4+ recommended for production)
- **RAM:** 4GB minimum (8GB+ recommended)
- **Disk:** 10GB minimum free space
- **Network:** Reliable internet connection

### Development Tools

- Visual Studio 2017 or later
- Web Deploy 3.6 (for automated deployment)
- FTP client (alternative deployment method)

---

## Pre-Deployment Checklist

### 1. Code Preparation

- [ ] All code changes committed to version control
- [ ] Build successful in Release configuration
- [ ] All unit tests passing (if applicable)
- [ ] Code reviewed and approved
- [ ] Security vulnerabilities addressed

### 2. Configuration

- [ ] `Web.config` updated for production
- [ ] Connection strings configured (if database used)
- [ ] Custom errors enabled
- [ ] Debug mode disabled
- [ ] Compilation set to release mode
- [ ] machineKey configured (for web farms)

### 3. Testing

- [ ] Application tested in staging environment
- [ ] Performance tested under load
- [ ] Security testing completed
- [ ] Browser compatibility verified
- [ ] Mobile responsiveness tested

### 4. Documentation

- [ ] Deployment plan documented
- [ ] Rollback procedure prepared
- [ ] Configuration changes documented
- [ ] Known issues documented

---

## Deployment to IIS (Windows Server)

### Step 1: Prepare the Build

#### Build in Release Mode

**Using Visual Studio:**
1. Open solution in Visual Studio
2. Select **Release** configuration from dropdown
3. Right-click solution → **Clean Solution**
4. Right-click solution → **Rebuild Solution**
5. Verify build succeeded with 0 errors

**Using Command Line:**
```bash
# Clean previous builds
msbuild LegacyWebForms.sln /t:Clean /p:Configuration=Release

# Build in Release mode
msbuild LegacyWebForms.sln /p:Configuration=Release
```

#### Publish the Application

**Method 1: File System Publish (Recommended)**

1. Right-click project → **Publish**
2. Choose **Folder** as target
3. Select folder location (e.g., `C:\Publish\LegacyWebForms`)
4. Click **Publish**

**Method 2: Manual File Copy**

Copy these files/folders to deployment location:
```
├── bin/                    # All DLLs and compiled assemblies
├── Content/               # CSS files
├── Scripts/               # JavaScript files
├── *.aspx                 # All page files
├── *.Master               # Master pages
├── *.ascx                 # User controls
├── Global.asax
├── Web.config
└── favicon.ico
```

**Do NOT copy:**
- `obj/` directory
- `packages/` directory
- `.cs` code-behind files (compiled into DLL)
- `.csproj`, `.sln` files
- `packages.config`

### Step 2: Configure IIS

#### Install IIS and ASP.NET

1. **Open Server Manager**
2. **Add Roles and Features**
3. Select **Web Server (IIS)** role
4. Under **Application Development**, select:
   - ASP.NET 4.8 (or 4.7)
   - .NET Extensibility 4.8
   - ISAPI Extensions
   - ISAPI Filters

#### Create Application Pool

1. Open **IIS Manager**
2. Expand server node
3. Right-click **Application Pools** → **Add Application Pool**
4. Configure:
   - **Name:** `LegacyWebFormsAppPool`
   - **.NET CLR Version:** `.NET CLR Version v4.0.30319`
   - **Managed Pipeline Mode:** `Integrated`
   - **Start immediately:** `✓`
5. Click **OK**

#### Configure Application Pool Advanced Settings

1. Right-click created pool → **Advanced Settings**
2. Recommended settings:
   - **Enable 32-Bit Applications:** `False` (unless required)
   - **Identity:** `ApplicationPoolIdentity` (or custom account)
   - **Idle Time-out:** `20` minutes (adjust based on usage)
   - **Regular Time Interval:** `1740` minutes (29 hours)
   - **Queue Length:** `1000`

### Step 3: Create Website

#### Create New Website

1. Right-click **Sites** → **Add Website**
2. Configure:
   - **Site name:** `LegacyWebForms`
   - **Application pool:** Select `LegacyWebFormsAppPool`
   - **Physical path:** Point to published files location
   - **Binding:**
     - **Type:** `http` (or `https` if SSL configured)
     - **IP Address:** `All Unassigned` or specific IP
     - **Port:** `80` (or `443` for HTTPS)
     - **Host name:** Your domain (e.g., `www.example.com`)
3. Click **OK**

#### Set Permissions

1. Right-click website → **Edit Permissions**
2. **Security** tab → **Edit**
3. Add `IIS AppPool\LegacyWebFormsAppPool`:
   - Read & Execute
   - List Folder Contents
   - Read
4. Apply and OK

### Step 4: Configure SSL (HTTPS) - Recommended

#### Obtain SSL Certificate

- Purchase from Certificate Authority (CA)
- Use Let's Encrypt (free)
- Generate self-signed certificate (testing only)

#### Install Certificate

1. Open **IIS Manager**
2. Select server node
3. Double-click **Server Certificates**
4. **Actions** pane → **Import** (or **Create Certificate Request**)
5. Follow wizard to install certificate

#### Add HTTPS Binding

1. Right-click website → **Edit Bindings**
2. **Add** new binding:
   - **Type:** `https`
   - **IP Address:** `All Unassigned` or specific IP
   - **Port:** `443`
   - **SSL Certificate:** Select installed certificate
   - **Host name:** Your domain
3. Click **OK**

#### Force HTTPS Redirect (Optional)

Add to `Web.config`:
```xml
<system.webServer>
  <rewrite>
    <rules>
      <rule name="Redirect to HTTPS" stopProcessing="true">
        <match url="(.*)" />
        <conditions>
          <add input="{HTTPS}" pattern="^OFF$" />
        </conditions>
        <action type="Redirect" url="https://{HTTP_HOST}/{R:1}" redirectType="Permanent" />
      </rule>
    </rules>
  </rewrite>
</system.webServer>
```

*Requires URL Rewrite Module*

### Step 5: Verify Deployment

1. Browse to `http://yourdomain.com` or `https://yourdomain.com`
2. Verify homepage loads correctly
3. Test navigation to all pages
4. Check browser console for JavaScript errors
5. Test responsive behavior on different devices
6. Verify ViewSwitcher works for mobile view

---

## Deployment to Azure App Service

### Step 1: Create Azure App Service

#### Using Azure Portal

1. Sign in to [Azure Portal](https://portal.azure.com)
2. Click **Create a resource** → **Web App**
3. Configure:
   - **Subscription:** Select your subscription
   - **Resource Group:** Create new or use existing
   - **Name:** Unique app name (e.g., `legacywebforms`)
   - **Publish:** `Code`
   - **Runtime stack:** `.NET Framework 4.8`
   - **Operating System:** `Windows`
   - **Region:** Choose nearest region
   - **App Service Plan:** Select or create new
4. Click **Review + Create** → **Create**

### Step 2: Configure Application Settings

1. Navigate to App Service in Azure Portal
2. **Configuration** → **Application settings**
3. Add any required app settings
4. **General settings**:
   - **.NET Framework version:** `v4.8`
   - **Always On:** `On` (for production)
   - **ARR affinity:** `On` (if using sessions)

### Step 3: Deploy Application

#### Method 1: Visual Studio Publish

1. Right-click project → **Publish**
2. Choose **Azure** as target
3. Select **Azure App Service (Windows)**
4. Sign in to Azure account
5. Select your App Service
6. Click **Publish**

#### Method 2: Git Deployment

1. Configure Git deployment in Azure:
   - **Deployment Center** → **Git** → **Local Git**
2. Copy Git URL
3. Add remote in local repository:
   ```bash
   git remote add azure <Git-URL>
   ```
4. Push to Azure:
   ```bash
   git push azure main
   ```

#### Method 3: FTP Deployment

1. Get FTP credentials from **Deployment Center**
2. Connect with FTP client
3. Upload files to `/site/wwwroot/`

### Step 4: Configure Custom Domain (Optional)

1. **Custom domains** in App Service
2. Click **Add custom domain**
3. Follow wizard to configure DNS
4. Bind SSL certificate if using HTTPS

---

## Configuration Management

### Web.config Transformations

Use config transformations for different environments:

**Web.Debug.config** (Development):
```xml
<?xml version="1.0"?>
<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
  <system.web>
    <compilation xdt:Transform="RemoveAttributes(debug)" />
  </system.web>
</configuration>
```

**Web.Release.config** (Production):
```xml
<?xml version="1.0"?>
<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
  <system.web>
    <compilation xdt:Transform="RemoveAttributes(debug)" />
    <customErrors mode="On" xdt:Transform="Replace" />
  </system.web>
</configuration>
```

### Key Configuration Settings

#### Production Web.config

```xml
<configuration>
  <system.web>
    <!-- Disable debug mode -->
    <compilation debug="false" targetFramework="4.7.2" />
    
    <!-- Enable custom errors -->
    <customErrors mode="On" defaultRedirect="~/Error.aspx">
      <error statusCode="404" redirect="~/NotFound.aspx" />
      <error statusCode="500" redirect="~/Error.aspx" />
    </customErrors>
    
    <!-- Session configuration -->
    <sessionState mode="InProc" timeout="20" />
    
    <!-- Authentication (if needed) -->
    <authentication mode="Forms">
      <forms loginUrl="~/Login.aspx" timeout="30" />
    </authentication>
  </system.web>

  <system.webServer>
    <!-- Remove version header for security -->
    <httpProtocol>
      <customHeaders>
        <remove name="X-Powered-By" />
      </customHeaders>
    </httpProtocol>
    
    <!-- Compression -->
    <urlCompression doStaticCompression="true" doDynamicCompression="true" />
  </system.webServer>
</configuration>
```

### Connection Strings

```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Server=.;Database=LegacyWebForms;Integrated Security=true;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

For Azure, use connection string from SQL Database.

---

## Security Hardening

### 1. Disable Debug Mode

Ensure `debug="false"` in Web.config:
```xml
<compilation debug="false" targetFramework="4.7.2" />
```

### 2. Enable Custom Errors

```xml
<customErrors mode="On" />
```

### 3. Configure machineKey (Web Farms)

Generate unique machineKey for load-balanced environments:
```xml
<machineKey 
  validationKey="[Generate unique key]"
  decryptionKey="[Generate unique key]"
  validation="SHA1"
  decryption="AES" />
```

Use IIS or online tools to generate keys.

### 4. Remove Unnecessary HTTP Headers

```xml
<system.webServer>
  <httpProtocol>
    <customHeaders>
      <remove name="X-Powered-By" />
      <remove name="X-AspNet-Version" />
    </customHeaders>
  </httpProtocol>
</system.webServer>
```

```xml
<system.web>
  <httpRuntime enableVersionHeader="false" />
</system.web>
```

### 5. Implement HTTPS

- Use SSL/TLS certificates
- Force HTTPS redirect
- Use HSTS headers

### 6. Request Validation

Keep enabled (default) to prevent XSS:
```xml
<pages validateRequest="true" />
```

### 7. ViewState MAC

Keep enabled (default) to prevent tampering:
```xml
<pages enableViewStateMac="true" />
```

---

## Performance Optimization

### 1. Enable Output Caching

For static content pages:
```aspx
<%@ OutputCache Duration="3600" VaryByParam="none" %>
```

### 2. Enable Compression

Already configured in Web.config (see Configuration section).

### 3. CDN for Static Resources

Update BundleConfig to use CDN paths for jQuery and other libraries.

### 4. Optimize ViewState

Disable on controls that don't need it:
```aspx
<asp:GridView EnableViewState="false" ... />
```

### 5. Bundle and Minify

Ensure bundling is enabled in Release mode (already configured).

### 6. Application Pool Recycling

Configure appropriate recycling schedule to prevent memory leaks.

---

## Monitoring and Logging

### Windows Event Log

Monitor application events:
- Open **Event Viewer**
- Navigate to **Windows Logs** → **Application**
- Filter for ASP.NET events

### IIS Logs

Enable and review IIS logs:
- Location: `C:\inetpub\logs\LogFiles\`
- Configure in IIS → Site → **Logging**

### Application Insights (Azure)

For Azure App Service:
1. Enable Application Insights
2. Monitor performance metrics
3. Track exceptions and errors
4. Analyze user behavior

### Custom Logging

Implement logging framework:
- NLog
- log4net
- Serilog

---

## Backup and Recovery

### 1. File Backup

Regularly backup:
- Application files
- Web.config
- Static content
- Custom files

### 2. Database Backup (if applicable)

- Regular automated backups
- Test restore procedures
- Store backups offsite

### 3. IIS Configuration Backup

```bash
%windir%\system32\inetsrv\appcmd.exe add backup "BackupName"
```

### 4. Rollback Plan

1. Keep previous version ready
2. Document rollback steps
3. Test rollback procedure
4. Have rollback triggers defined

---

## Troubleshooting

### Common Issues

**"500 Internal Server Error"**
- Enable detailed errors temporarily:
  ```xml
  <customErrors mode="Off" />
  ```
- Check Windows Event Log
- Review IIS logs

**"404 Not Found"**
- Verify files exist in physical path
- Check URL routing configuration
- Verify MIME types for static files

**"Application Pool Crashes"**
- Check Event Viewer for crash details
- Review application code for unhandled exceptions
- Increase application pool memory limits

**Slow Performance**
- Enable Performance Monitor
- Check database query performance
- Review ViewState size
- Verify caching is enabled

### Diagnostic Tools

- **Failed Request Tracing** in IIS
- **Performance Monitor** (PerfMon)
- **Debug Diagnostic Tool** (DebugDiag)
- Browser Developer Tools

---

## Post-Deployment Tasks

### Verification

- [ ] Application accessible via URL
- [ ] All pages load correctly
- [ ] Navigation works properly
- [ ] Responsive design functions
- [ ] Forms submit successfully
- [ ] No JavaScript errors in console

### Monitoring Setup

- [ ] Configure error alerting
- [ ] Set up uptime monitoring
- [ ] Enable performance tracking
- [ ] Configure log retention

### Documentation

- [ ] Document deployment date
- [ ] Record configuration changes
- [ ] Update runbook
- [ ] Share knowledge with team

---

## Additional Resources

- [IIS Documentation](https://docs.microsoft.com/iis/)
- [Azure App Service Documentation](https://docs.microsoft.com/azure/app-service/)
- [ASP.NET Deployment Overview](https://docs.microsoft.com/aspnet/web-forms/overview/deployment/)

---

*Last Updated: 2025*
