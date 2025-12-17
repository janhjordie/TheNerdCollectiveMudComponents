// Licensed under the Apache License, Version 2.0.
// See LICENSE file in the project root for full license information.

using System.Text.Json.Serialization;

namespace TheNerdCollective.Integrations.Harvest.Models;

/// <summary>
/// Represents a timesheet entry from Harvest API.
/// </summary>
public class TimesheetEntry
{
    public long Id { get; set; }
    public long ProjectId { get; set; }
    public long TaskId { get; set; }
    public long UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string ProjectName { get; set; } = string.Empty;
    public string TaskName { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public decimal Hours { get; set; }
    public DateTime SpentDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Harvest API time entry response model.
/// </summary>
public class HarvestTimeEntry
{
    public long Id { get; set; }
    public HarvestUser? User { get; set; }
    public HarvestProject? Project { get; set; }
    public HarvestTask? Task { get; set; }
    public string? Notes { get; set; }
    public decimal Hours { get; set; }

    [JsonPropertyName("spent_date")]
    public string? SpentDate { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Harvest user information.
/// </summary>
public class HarvestUser
{
    public long Id { get; set; }
    public string? Name { get; set; }
}

/// <summary>
/// Harvest project information.
/// </summary>
public class HarvestProject
{
    public long Id { get; set; }
    public string? Name { get; set; }
}

/// <summary>
/// Harvest task information.
/// </summary>
public class HarvestTask
{
    public long Id { get; set; }
    public string? Name { get; set; }
}

/// <summary>
/// Response wrapper for time entries.
/// </summary>
public class HarvestTimeEntriesResponse
{
    [JsonPropertyName("time_entries")]
    public List<HarvestTimeEntry>? TimeEntries { get; set; }
}

/// <summary>
/// Response wrapper for projects.
/// </summary>
public class HarvestProjectsResponse
{
    [JsonPropertyName("projects")]
    public List<HarvestProject>? Projects { get; set; }
}
