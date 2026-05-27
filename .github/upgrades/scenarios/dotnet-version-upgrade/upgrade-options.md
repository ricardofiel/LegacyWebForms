# Upgrade Options — LegacyWebForms

Assessment: 1 project (net472, legacy WebForms WAP), 6 incompatible packages, 3 binding redirect issues, SDK-style = False

## Strategy

### Upgrade Strategy
Single project solution — no dependency graph to manage.

| Value | Description |
|-------|-------------|
| **All-at-Once** (selected) | Upgrade the single project in one atomic pass — fastest approach with no multi-targeting overhead |

## Project Structure

### Project Approach
LegacyWebForms.csproj is an ASP.NET WebForms project (WAP) targeting net472. WebForms is not supported in .NET 10 — migration to ASP.NET Core is required. Project is small (510 LOC, 3 pages) with low API complexity.

| Value | Description |
|-------|-------------|
| **In-place rewrite** (selected) | Replace the Framework web project entirely in one pass — appropriate for small projects (≤ 10 pages, 510 LOC) with low complexity |
| Side-by-side | Create a new ASP.NET Core project alongside the existing Framework project, migrate incrementally — better for large projects requiring continuous deployment |

## Compatibility

### Unsupported Packages
6 packages are incompatible with net10.0: Microsoft.AspNet.FriendlyUrls, Microsoft.AspNet.FriendlyUrls.Core, Microsoft.AspNet.ScriptManager.MSAjax, Microsoft.AspNet.ScriptManager.WebForms, Microsoft.AspNet.Web.Optimization, Microsoft.AspNet.Web.Optimization.WebForms. These are WebForms-specific packages with no direct ASP.NET Core replacements.

| Value | Description |
|-------|-------------|
| **Defer Resolution** (selected) | Make the project compile without the packages by generating minimal stubs, then resolve replacements per package. Best for 6+ incompatible packages with no known 1-to-1 replacements |
| Resolve Inline | Research and resolve each incompatible package within the same task — preferred for 1-3 packages |

## Modernization

### Assembly Binding Redirects
web.config contains 4 binding redirect entries (Antlr3.Runtime, Microsoft.Web.Infrastructure, Newtonsoft.Json, WebGrease). Assessment flagged 2 mandatory conflicts and 1 potential issue.

| Value | Description |
|-------|-------------|
| **Remove Binding Redirects** (selected) | Remove all redirects — .NET Core handles assembly resolution differently and does not use them |
| Document and Review Before Removing | Generate report of all redirects and their purposes before removal |

### Nullable Reference Types
Project is small (510 LOC, 1 project), low complexity, no nullable already enabled. Target is net10.0.

| Value | Description |
|-------|-------------|
| **Enable Nullable Reference Types** (selected) | Add `<Nullable>enable</Nullable>` to project files — small codebase with low complexity |
| Leave Disabled | Do not enable nullable — maintain existing null handling |
