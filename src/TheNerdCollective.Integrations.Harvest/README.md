# TheNerdCollective.Integrations.Harvest

A robust .NET integration service for the GetHarvest.com API v2, providing seamless access to timesheet entries, projects, and time tracking data.

## Overview

TheNerdCollective.Integrations.Harvest provides a type-safe, dependency-injection-friendly wrapper around the Harvest API, enabling easy integration of timesheet data into your .NET applications.

## Quick Start

### Installation

```bash
dotnet add package TheNerdCollective.Integrations.Harvest
```

### Setup

1. **Configure in `appsettings.json`:**

```json
{
  "Harvest": {
    "ApiToken": "your_api_token_here",
    "AccountId": "your_account_id_here",
    "ProjectIds": [123456, 789012]
  }
}
```

2. **Register in Program.cs:**

```csharp
using TheNerdCollective.Integrations.Harvest.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHarvestIntegration(builder.Configuration);

var app = builder.Build();
```

3. **Use in your services:**

```csharp
public class MyService
{
    private readonly HarvestService _harvestService;

    public MyService(HarvestService harvestService)
    {
        _harvestService = harvestService;
    }

    public async Task GetTimesheetsAsync()
    {
        var entries = await _harvestService.GetTimesheetEntriesAsync(
            startDate: new DateTime(2025, 12, 1),
            endDate: new DateTime(2025, 12, 31));
    }
}
```

## Features

- **Timesheet Entries** - Retrieve time entries for multiple projects and date ranges
- **Project Management** - Get all projects and manage tracked project IDs
- **Type-Safe Configuration** - Configuration via `HarvestOptions` class
- **Async/Await Support** - Modern async APIs throughout
- **Dependency Injection** - First-class support for .NET DI container
- **Error Handling** - Graceful handling of API failures

## API Methods

### `GetTimesheetEntriesAsync(startDate, endDate)`
Retrieves all timesheet entries for configured projects within the specified date range.

```csharp
var entries = await harvestService.GetTimesheetEntriesAsync(
    startDate: new DateTime(2025, 12, 1),
    endDate: new DateTime(2025, 12, 31));
```

### `GetProjectsAsync()`
Retrieves all available projects from Harvest.

```csharp
var projects = await harvestService.GetProjectsAsync();
```

### `AddProjectId(projectId)`
Adds a project ID to the list of tracked projects.

```csharp
harvestService.AddProjectId(123456);
```

### `RemoveProjectId(projectId)`
Removes a project ID from tracking.

```csharp
harvestService.RemoveProjectId(123456);
```

### `GetProjectIds()`
Returns the list of currently tracked project IDs.

```csharp
var projectIds = harvestService.GetProjectIds();
```

### `ClearProjectIds()`
Clears all tracked project IDs.

```csharp
harvestService.ClearProjectIds();
```

## Authentication

### Getting Your API Token and Account ID

1. Log in to your Harvest account
2. Navigate to [Account Settings → API & OAuth](https://help.getharvest.com/api-v2/authentication-api/authentication/authentication/)
3. Generate or copy your Personal Access Token
4. Your Account ID is also displayed on this page
5. Add both to your `appsettings.json`

## Configuration

### appsettings.json Example

```json
{
  "Harvest": {
    "ApiToken": "3488495.pt.Ak1avQxXKRtGcO4U5-QWYg9fu3y39-ntbF6_aw95in5nICz35ZLtyHT5fcIJGcuIZIwoe3NnGGAbXUihvZ6H_A",
    "AccountId": "1764854",
    "ProjectIds": [46478953, 46478934]
  }
}
```

### appsettings.Development.json (Local Testing)

Store secrets locally without committing to repository:

```json
{
  "Harvest": {
    "ApiToken": "your_test_token",
    "AccountId": "your_test_account_id",
    "ProjectIds": []
  }
}
```

## Models

### TimesheetEntry
Represents a timesheet entry with all relevant information.

```csharp
public class TimesheetEntry
{
    public long Id { get; set; }
    public long ProjectId { get; set; }
    public long TaskId { get; set; }
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string ProjectName { get; set; }
    public string TaskName { get; set; }
    public string Notes { get; set; }
    public decimal Hours { get; set; }
    public DateTime SpentDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```

## Dependencies

- **Microsoft.Extensions.Configuration** 10.0.0
- **Microsoft.Extensions.DependencyInjection** 10.0.0
- **Microsoft.Extensions.Http** 10.0.0
- **Microsoft.Extensions.Options.ConfigurationExtensions** 10.0.0
- **.NET** 10.0+

## License

Apache License 2.0 - See LICENSE file for details

## Repository

[TheNerdCollective.Components on GitHub](https://github.com/janhjordie/TheNerdCollective.Components)

---

Built with ❤️ by [The Nerd Collective Aps](https://www.thenerdcollective.dk/)
