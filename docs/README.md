# LegacyWebForms - Documentation Index

Welcome to the LegacyWebForms documentation! This index provides an overview of all available documentation and helps you find the information you need quickly.

## Documentation Structure

### For Users
If you're new to the project or want to understand what it does:
- Start with the [main README](../README.md) for a project overview
- Review the [Architecture Documentation](ARCHITECTURE.md) to understand how it's built

### For Developers
If you're developing or contributing to the project:
1. **Getting Started**
   - [Developer Guide](DEVELOPER_GUIDE.md) - Setup, build, and development workflow
   - [Architecture Documentation](ARCHITECTURE.md) - Understand the application structure

2. **Coding**
   - [API Documentation](API_DOCUMENTATION.md) - Reference for all classes and methods
   - [Developer Guide - Best Practices](DEVELOPER_GUIDE.md#best-practices)

3. **Testing**
   - [Developer Guide - Testing](DEVELOPER_GUIDE.md#testing)
   - [Developer Guide - Debugging](DEVELOPER_GUIDE.md#debugging)

### For DevOps/System Administrators
If you're deploying or maintaining the application:
- [Deployment Guide](DEPLOYMENT_GUIDE.md) - Complete deployment instructions
- [Architecture - Performance](ARCHITECTURE.md#performance-considerations)
- [Deployment - Monitoring](DEPLOYMENT_GUIDE.md#monitoring-and-logging)

## Quick Navigation

### Documentation Files

| Document | Description | Audience |
|----------|-------------|----------|
| [API Documentation](API_DOCUMENTATION.md) | Complete API reference for all classes, methods, properties, and objects | Developers |
| [Architecture Documentation](ARCHITECTURE.md) | Application architecture, design patterns, technology stack, and system design | Developers, Architects |
| [Developer Guide](DEVELOPER_GUIDE.md) | Development environment setup, workflows, and best practices | Developers |
| [Deployment Guide](DEPLOYMENT_GUIDE.md) | Deployment procedures for IIS, Azure, and configuration management | DevOps, SysAdmins |

### By Topic

#### Getting Started
- [Prerequisites](DEVELOPER_GUIDE.md#prerequisites)
- [Environment Setup](DEVELOPER_GUIDE.md#development-environment-setup)
- [Building the Project](DEVELOPER_GUIDE.md#building-the-project)
- [Running the Application](DEVELOPER_GUIDE.md#running-the-application)

#### Development
- [Project Structure](DEVELOPER_GUIDE.md#project-structure)
- [Creating New Pages](DEVELOPER_GUIDE.md#creating-a-new-page)
- [Adding User Controls](DEVELOPER_GUIDE.md#creating-user-controls)
- [Working with Master Pages](DEVELOPER_GUIDE.md#working-with-master-pages)
- [Debugging](DEVELOPER_GUIDE.md#debugging)
- [Best Practices](DEVELOPER_GUIDE.md#best-practices)

#### Architecture & Design
- [Architecture Pattern](ARCHITECTURE.md#architecture-pattern)
- [Application Structure](ARCHITECTURE.md#application-structure)
- [Technology Stack](ARCHITECTURE.md#technology-stack)
- [Application Lifecycle](ARCHITECTURE.md#application-lifecycle)
- [Data Flow](ARCHITECTURE.md#data-flow)
- [Routing & Navigation](ARCHITECTURE.md#routing-and-navigation)
- [Security Considerations](ARCHITECTURE.md#security-considerations)

#### API Reference
- [Global Application Class](API_DOCUMENTATION.md#global-class)
- [BundleConfig Class](API_DOCUMENTATION.md#bundleconfig-class)
- [RouteConfig Class](API_DOCUMENTATION.md#routeconfig-class)
- [Page Classes](API_DOCUMENTATION.md#page-classes)
- [Master Page Classes](API_DOCUMENTATION.md#master-page-classes)
- [User Control Classes](API_DOCUMENTATION.md#user-control-classes)

#### Deployment
- [Pre-Deployment Checklist](DEPLOYMENT_GUIDE.md#pre-deployment-checklist)
- [IIS Deployment](DEPLOYMENT_GUIDE.md#deployment-to-iis-windows-server)
- [Azure Deployment](DEPLOYMENT_GUIDE.md#deployment-to-azure-app-service)
- [Configuration Management](DEPLOYMENT_GUIDE.md#configuration-management)
- [Security Hardening](DEPLOYMENT_GUIDE.md#security-hardening)
- [Performance Optimization](DEPLOYMENT_GUIDE.md#performance-optimization)
- [Monitoring & Logging](DEPLOYMENT_GUIDE.md#monitoring-and-logging)

#### Troubleshooting
- [Build Errors](DEVELOPER_GUIDE.md#build-errors)
- [Runtime Errors](DEVELOPER_GUIDE.md#runtime-errors)
- [Linux Build Issues](DEVELOPER_GUIDE.md#linux-build-issues)
- [Deployment Issues](DEPLOYMENT_GUIDE.md#troubleshooting)

## Common Scenarios

### I want to...

**...understand what this application does**
- Read the [README](../README.md)
- Review [Architecture Documentation](ARCHITECTURE.md)

**...set up my development environment**
- Follow [Development Environment Setup](DEVELOPER_GUIDE.md#development-environment-setup)
- Build using [Building the Project](DEVELOPER_GUIDE.md#building-the-project)

**...add a new page to the application**
- Follow [Creating a New Page](DEVELOPER_GUIDE.md#creating-a-new-page)
- Reference [Page Classes](API_DOCUMENTATION.md#page-classes) for structure

**...understand how bundling works**
- Read [BundleConfig Class](API_DOCUMENTATION.md#bundleconfig-class)
- Review [Resource Management](ARCHITECTURE.md#resource-management)

**...deploy to IIS**
- Follow [IIS Deployment](DEPLOYMENT_GUIDE.md#deployment-to-iis-windows-server)
- Complete [Pre-Deployment Checklist](DEPLOYMENT_GUIDE.md#pre-deployment-checklist)

**...deploy to Azure**
- Follow [Azure Deployment](DEPLOYMENT_GUIDE.md#deployment-to-azure-app-service)
- Configure [Application Settings](DEPLOYMENT_GUIDE.md#step-2-configure-application-settings)

**...fix a build error**
- Check [Troubleshooting - Build Errors](DEVELOPER_GUIDE.md#build-errors)
- Review build output for specific error messages

**...optimize performance**
- Review [Performance Optimization](DEPLOYMENT_GUIDE.md#performance-optimization)
- Implement [Best Practices](DEVELOPER_GUIDE.md#best-practices)

**...secure the application**
- Follow [Security Hardening](DEPLOYMENT_GUIDE.md#security-hardening)
- Review [Security Considerations](ARCHITECTURE.md#security-considerations)

**...understand how routing works**
- Read [RouteConfig Class](API_DOCUMENTATION.md#routeconfig-class)
- Review [Routing and Navigation](ARCHITECTURE.md#routing-and-navigation)

**...add JavaScript or CSS**
- Follow [Adding JavaScript](DEVELOPER_GUIDE.md#adding-javascript)
- Follow [Adding CSS Styles](DEVELOPER_GUIDE.md#adding-css-styles)

**...understand the ViewSwitcher control**
- Read [ViewSwitcher Class](API_DOCUMENTATION.md#viewswitcher-class)
- See implementation in [Architecture - Mobile Detection](ARCHITECTURE.md#mobile-detection)

## Documentation Standards

All documentation in this project follows these standards:

- **Markdown Format** - Easy to read and maintain
- **Clear Structure** - Logical organization with table of contents
- **Code Examples** - Practical examples where applicable
- **Cross-References** - Links to related documentation
- **Version Control** - Tracked in Git with the source code

## Contributing to Documentation

When updating documentation:

1. **Keep it Current** - Update docs when code changes
2. **Be Clear** - Write for developers of all skill levels
3. **Use Examples** - Show, don't just tell
4. **Link Related Topics** - Help readers find related information
5. **Test Instructions** - Verify procedures work before documenting

## Document Update History

| Document | Last Updated | Version |
|----------|--------------|---------|
| API Documentation | 2025 | 1.0 |
| Architecture Documentation | 2025 | 1.0 |
| Developer Guide | 2025 | 1.0 |
| Deployment Guide | 2025 | 1.0 |
| Documentation Index | 2025 | 1.0 |

## Need Help?

If you can't find what you're looking for:

1. **Search** - Use Ctrl+F to search within documents
2. **Index** - Review this index for topic locations
3. **GitHub Issues** - Check existing issues or create a new one
4. **README** - Check the [main README](../README.md) for contact information

## External Resources

Additional resources outside this documentation:

- [ASP.NET Web Forms Official Documentation](https://docs.microsoft.com/aspnet/web-forms/)
- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.2/)
- [jQuery API Documentation](https://api.jquery.com/)
- [.NET Framework Documentation](https://docs.microsoft.com/dotnet/framework/)
- [IIS Documentation](https://docs.microsoft.com/iis/)
- [Azure App Service Documentation](https://docs.microsoft.com/azure/app-service/)

---

**Happy Coding!**

*This documentation is maintained as part of the LegacyWebForms project.*
