# .NET Version Upgrade — LegacyWebForms to .NET 10

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0

## Source Control
- **Source Branch**: copilot/modernize-to-dotnet-10
- **Working Branch**: copilot/modernize-to-dotnet-10
- **Commit Strategy**: Single Commit at End
- **Branch Sync**: Auto (Merge)

## Upgrade Options
**Source**: .github/upgrades/scenarios/dotnet-version-upgrade/upgrade-options.md

### Strategy
- Upgrade Strategy: All-at-Once

### Project Structure
- Project Approach: In-place rewrite (Web Projects)

### Compatibility
- Unsupported Packages: Defer Resolution (6 incompatible packages)

### Modernization
- Assembly Binding Redirects: Remove Binding Redirects
- Nullable Reference Types: Enable Nullable Reference Types

## Strategy
**Selected**: All-at-Once
**Rationale**: Single project solution — no dependency graph to manage. All-at-Once is the correct strategy for .NET Framework single-project solutions.

### Execution Constraints
- Single atomic upgrade — all changes applied together; validate full solution build after upgrade
- SDK-style conversion must occur before TFM upgrade (separate tasks per framework-migration planning rules)
- WebForms pages must be rewritten as Razor Pages for ASP.NET Core compatibility
- Incompatible WebForms packages removed and replaced with ASP.NET Core equivalents
- Binding redirects in web.config removed — not used in .NET Core
