# LegacyWebForms - API Documentation

## Overview

This document provides comprehensive documentation for all classes, methods, and objects in the LegacyWebForms application.

## Table of Contents

1. [Namespace: LegacyWebForms](#namespace-legacywebforms)
2. [Application Configuration Classes](#application-configuration-classes)
3. [Page Classes](#page-classes)
4. [Master Page Classes](#master-page-classes)
5. [User Control Classes](#user-control-classes)

---

## Namespace: LegacyWebForms

The `LegacyWebForms` namespace contains all the application code including configuration, pages, master pages, and user controls.

---

## Application Configuration Classes

### Global Class

**Namespace:** `LegacyWebForms`  
**Inherits:** `System.Web.HttpApplication`  
**Assembly:** LegacyWebForms.dll  

#### Description

Global application class that handles application-level events and configuration. This class is instantiated by ASP.NET once when the application starts and manages the application's lifetime.

#### Methods

##### Application_Start

```csharp
void Application_Start(object sender, EventArgs e)
```

**Description:** Handles the Application_Start event, which fires when the application starts. This method is called once during the application's lifetime to configure routing and bundling.

**Parameters:**
- `sender` (object): The source of the event.
- `e` (EventArgs): Event arguments.

**Functionality:**
- Registers URL routes via `RouteConfig.RegisterRoutes()`
- Registers script and style bundles via `BundleConfig.RegisterBundles()`

---

### BundleConfig Class

**Namespace:** `LegacyWebForms`  
**Assembly:** LegacyWebForms.dll  
**Location:** `/App_Start/BundleConfig.cs`

#### Description

Configuration class for script and style bundles. Handles bundling and minification of JavaScript and CSS resources to improve application performance and reduce load times.

#### Methods

##### RegisterBundles

```csharp
public static void RegisterBundles(BundleCollection bundles)
```

**Description:** Registers all script and style bundles for the application. This includes WebForms scripts, Microsoft Ajax scripts, and Modernizr.

**Parameters:**
- `bundles` (BundleCollection): The BundleCollection to which bundles will be added.

**Bundles Registered:**

1. **~/bundles/WebFormsJs** - Contains core WebForms client-side scripts:
   - WebForms.js
   - WebUIValidation.js
   - MenuStandards.js
   - Focus.js
   - GridView.js
   - DetailsView.js
   - TreeView.js
   - WebParts.js

2. **~/bundles/MsAjaxJs** - Contains Microsoft Ajax scripts (order-dependent):
   - MicrosoftAjax.js
   - MicrosoftAjaxApplicationServices.js
   - MicrosoftAjaxTimer.js
   - MicrosoftAjaxWebForms.js

3. **~/bundles/modernizr** - Contains Modernizr library for feature detection

##### RegisterJQueryScriptManager

```csharp
public static void RegisterJQueryScriptManager()
```

**Description:** Registers jQuery with the ScriptManager for use in WebForms pages. Configures both the regular and minified versions, as well as CDN paths.

**jQuery Version:** 3.7.0

**Configuration:**
- **Path:** `~/scripts/jquery-3.7.0.min.js` (minified for production)
- **DebugPath:** `~/scripts/jquery-3.7.0.js` (full version for debugging)
- **CdnPath:** Microsoft Ajax CDN for minified version
- **CdnDebugPath:** Microsoft Ajax CDN for debug version

---

### RouteConfig Class

**Namespace:** `LegacyWebForms`  
**Assembly:** LegacyWebForms.dll  
**Location:** `/App_Start/RouteConfig.cs`

#### Description

Configuration class for URL routing. Enables Friendly URLs for cleaner, more SEO-friendly URLs without file extensions.

#### Methods

##### RegisterRoutes

```csharp
public static void RegisterRoutes(RouteCollection routes)
```

**Description:** Registers URL routes for the application. Configures Friendly URLs with permanent redirect mode to automatically redirect requests with .aspx extensions to their friendly URL equivalents.

**Parameters:**
- `routes` (RouteCollection): The RouteCollection to which routes will be added.

**Configuration:**
- **AutoRedirectMode:** `RedirectMode.Permanent` - Uses HTTP 301 redirects for SEO benefits

**Example URL Transformations:**
- `/Default.aspx` → `/Default`
- `/About.aspx` → `/About`
- `/Contact.aspx` → `/Contact`

---

## Page Classes

### _Default Class (Home Page)

**Namespace:** `LegacyWebForms`  
**Inherits:** `System.Web.UI.Page`  
**Partial Class:** Yes  
**ASPX File:** `/Default.aspx`  
**Assembly:** LegacyWebForms.dll

#### Description

Code-behind class for the Default (Home) page. This is the main landing page of the application, displaying an introduction to ASP.NET Web Forms and featuring sections for getting started, libraries, and web hosting information.

#### Methods

##### Page_Load

```csharp
protected void Page_Load(object sender, EventArgs e)
```

**Description:** Handles the Page_Load event, which fires when the page is loaded.

**Parameters:**
- `sender` (object): The source of the event.
- `e` (EventArgs): Event arguments.

**Current Implementation:** Empty - can be extended for custom page initialization logic.

#### Page Structure

The Default page includes:
- Hero section with ASP.NET introduction
- Getting Started section
- Libraries section (NuGet information)
- Web Hosting section

---

### About Class

**Namespace:** `LegacyWebForms`  
**Inherits:** `System.Web.UI.Page`  
**Partial Class:** Yes  
**ASPX File:** `/About.aspx`  
**Assembly:** LegacyWebForms.dll

#### Description

Code-behind class for the About page. Provides information about the application.

#### Methods

##### Page_Load

```csharp
protected void Page_Load(object sender, EventArgs e)
```

**Description:** Handles the Page_Load event, which fires when the page is loaded.

**Parameters:**
- `sender` (object): The source of the event.
- `e` (EventArgs): Event arguments.

**Current Implementation:** Empty - can be extended for custom page initialization logic.

---

### Contact Class

**Namespace:** `LegacyWebForms`  
**Inherits:** `System.Web.UI.Page`  
**Partial Class:** Yes  
**ASPX File:** `/Contact.aspx`  
**Assembly:** LegacyWebForms.dll

#### Description

Code-behind class for the Contact page. Displays contact information for the organization.

#### Methods

##### Page_Load

```csharp
protected void Page_Load(object sender, EventArgs e)
```

**Description:** Handles the Page_Load event, which fires when the page is loaded.

**Parameters:**
- `sender` (object): The source of the event.
- `e` (EventArgs): Event arguments.

**Current Implementation:** Empty - can be extended for custom page initialization logic.

#### Page Content

The Contact page displays:
- Organization address (One Microsoft Way, Redmond, WA)
- Phone number
- Support email
- Marketing email

---

## Master Page Classes

### SiteMaster Class

**Namespace:** `LegacyWebForms`  
**Inherits:** `System.Web.UI.MasterPage`  
**Partial Class:** Yes  
**Master File:** `/Site.Master`  
**Assembly:** LegacyWebForms.dll

#### Description

Code-behind class for the Site Master page. Provides the main layout template for all pages in the application, including the navigation menu, header, and footer structure.

#### Methods

##### Page_Load

```csharp
protected void Page_Load(object sender, EventArgs e)
```

**Description:** Handles the Page_Load event, which fires when the master page is loaded.

**Parameters:**
- `sender` (object): The source of the event.
- `e` (EventArgs): Event arguments.

**Current Implementation:** Empty - can be extended for custom master page initialization logic.

#### Master Page Features

The Site.Master provides:
- Responsive navigation bar (Bootstrap-based)
- Application branding area
- Navigation links (Home, About, Contact)
- Content placeholder for page content
- Footer area
- ViewSwitcher control for mobile/desktop toggling

---

## User Control Classes

### ViewSwitcher Class

**Namespace:** `LegacyWebForms`  
**Inherits:** `System.Web.UI.UserControl`  
**Partial Class:** Yes  
**ASCX File:** `/ViewSwitcher.ascx`  
**Assembly:** LegacyWebForms.dll

#### Description

User control that provides a view switcher between Mobile and Desktop views. Allows users to toggle between different rendering modes based on device type. Works in conjunction with Microsoft ASP.NET FriendlyUrls to detect and switch between mobile and desktop views.

#### Properties

##### CurrentView

```csharp
protected string CurrentView { get; private set; }
```

**Description:** Gets the current view mode (either "Mobile" or "Desktop").

**Access:** Protected (read-only from outside the class)

##### AlternateView

```csharp
protected string AlternateView { get; private set; }
```

**Description:** Gets the alternate view mode that the user can switch to.

**Access:** Protected (read-only from outside the class)

##### SwitchUrl

```csharp
protected string SwitchUrl { get; private set; }
```

**Description:** Gets the URL for switching to the alternate view. Includes return URL to bring user back to current page after switching.

**Access:** Protected (read-only from outside the class)

#### Methods

##### Page_Load

```csharp
protected void Page_Load(object sender, EventArgs e)
```

**Description:** Handles the Page_Load event. Determines the current view mode, calculates the alternate view, and generates the switch URL.

**Parameters:**
- `sender` (object): The source of the event.
- `e` (EventArgs): Event arguments.

**Functionality:**
1. Detects if current request is from mobile device using `WebFormsFriendlyUrlResolver.IsMobileView()`
2. Sets `CurrentView` property to "Mobile" or "Desktop"
3. Sets `AlternateView` to the opposite of current view
4. Constructs switch URL using Friendly URLs routing
5. Appends return URL parameter for navigation back to current page
6. Hides control if Friendly URLs is not enabled

**Special Cases:**
- If the switch view route is not found (Friendly URLs disabled), the control hides itself by setting `this.Visible = false`

---

## Technology Stack

### .NET Framework
- **Version:** 4.7.2
- **Platform:** ASP.NET Web Forms

### Front-end Libraries
- **Bootstrap:** 5.2.3 - UI framework for responsive design
- **jQuery:** 3.7.0 - JavaScript library for DOM manipulation
- **Modernizr:** 2.8.3 - Feature detection library

### NuGet Packages
- **Microsoft.AspNet.FriendlyUrls:** 1.0.2 - SEO-friendly URL routing
- **Microsoft.AspNet.Web.Optimization:** 1.1.3 - Bundling and minification
- **Microsoft.AspNet.ScriptManager.MSAjax:** 5.0.0 - Ajax support
- **Microsoft.AspNet.ScriptManager.WebForms:** 5.0.0 - WebForms script management
- **Newtonsoft.Json:** 13.0.3 - JSON serialization
- **WebGrease:** 1.6.0 - CSS and JavaScript optimization
- **Antlr:** 3.5.0.2 - Parser for CSS/JavaScript optimization

---

## Assembly Information

**Assembly Name:** LegacyWebForms  
**Assembly Version:** 1.0.0.0  
**File Version:** 1.0.0.0  
**Copyright:** Copyright © 2025  
**Target Framework:** .NET Framework 4.7.2  

---

## See Also

- [Architecture Documentation](ARCHITECTURE.md)
- [Developer Guide](DEVELOPER_GUIDE.md)
- [Deployment Guide](DEPLOYMENT_GUIDE.md)
