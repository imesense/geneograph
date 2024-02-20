using System.Text.Json.Serialization;

namespace ImeSense.GeneoGraph.Models;

/// <summary>
/// Represents project fields for file serialization and deserialization
/// </summary>
public sealed class Project {
    /// <summary>
    /// Name of project
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Type of database
    /// </summary>
    [JsonPropertyName("database_type")]
    public DatabaseType DatabaseType { get; set; }

    /// <summary>
    /// Connection string or path to database file
    /// </summary>
    [JsonPropertyName("database")]
    public string? DatabasePath { get; set; }

    /// <summary>
    /// List of associated documents
    /// </summary>
    [JsonPropertyName("documents")]
    public string[]? Documents { get; set; }

    /// <summary>
    /// List of associated photos
    /// </summary>
    [JsonPropertyName("photos")]
    public string[]? Photos { get; set; }

    /// <summary>
    /// List of associated notes
    /// </summary>
    [JsonPropertyName("notes")]
    public string[]? Notes { get; set; }
}
