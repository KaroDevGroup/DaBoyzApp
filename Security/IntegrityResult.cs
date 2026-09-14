// KaroDevGroup
// Josh Karo

using System.Collections.Generic;

namespace DaBoyzApp.Security;

public enum IntegrityFileStatus
{
    Valid,
    Missing,
    Modified
}

public sealed class IntegrityFileResult
{
    public string Path { get; set; } = string.Empty;

    public IntegrityFileStatus Status { get; set; }

    public string ExpectedHash { get; set; } = string.Empty;

    public string ActualHash { get; set; } = string.Empty;
}

public sealed class IntegrityScanResult
{
    public bool Passed { get; set; }

    public List<IntegrityFileResult> Files { get; set; } = new();
}