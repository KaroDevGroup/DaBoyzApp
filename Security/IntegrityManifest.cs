// KaroDevGroup
// Josh Karo

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DaBoyzApp.Security;

public sealed class IntegrityManifest
{
    [JsonPropertyName("manifestVersion")]
    public int ManifestVersion { get; set; }

    [JsonPropertyName("generatedUtc")]
    public string GeneratedUtc { get; set; } = string.Empty;

    [JsonPropertyName("algorithm")]
    public string Algorithm { get; set; } = string.Empty;

    [JsonPropertyName("fileCount")]
    public int FileCount { get; set; }

    [JsonPropertyName("files")]
    public List<IntegrityManifestFile> Files { get; set; } = new();
}

public sealed class IntegrityManifestFile
{
    [JsonPropertyName("path")]
    public string Path { get; set; } = string.Empty;

    [JsonPropertyName("sha256")]
    public string Sha256 { get; set; } = string.Empty;
}