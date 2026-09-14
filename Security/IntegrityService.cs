// KaroDevGroup
// Josh Karo

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;

namespace DaBoyzApp.Security;

public sealed class IntegrityService
{
    private readonly string _baseDirectory;
    private readonly string _manifestPath;

    public IntegrityService()
    {
        _baseDirectory = AppContext.BaseDirectory;

        _manifestPath = Path.Combine(
            _baseDirectory,
            "integrity-manifest.json");
    }

    public async Task<IntegrityScanResult> ScanAsync(
        IProgress<(int current, int total, string file)>? progress = null)
    {
        var result = new IntegrityScanResult();

        if (!File.Exists(_manifestPath))
        {
            result.Passed = false;

            result.Files.Add(
                new IntegrityFileResult
                {
                    Path = "integrity-manifest.json",
                    Status = IntegrityFileStatus.Missing
                });

            return result;
        }

        string json = await File.ReadAllTextAsync(
            _manifestPath);

        IntegrityManifest? manifest =
            JsonSerializer.Deserialize<IntegrityManifest>(json);

        if (manifest == null)
        {
            result.Passed = false;

            return result;
        }

        int total = manifest.Files.Count;
        int current = 0;

        foreach (IntegrityManifestFile file in manifest.Files)
        {
            current++;

            progress?.Report(
                (current, total, file.Path));


            string normalizedRelativePath =
                file.Path.Replace(
                    '/',
                    Path.DirectorySeparatorChar);

            string fullPath =
                Path.Combine(
                    _baseDirectory,
                    normalizedRelativePath);

            if (!File.Exists(fullPath))
            {
                result.Files.Add(
                    new IntegrityFileResult
                    {
                        Path = file.Path,
                        Status = IntegrityFileStatus.Missing,
                        ExpectedHash = file.Sha256,
                        ActualHash = string.Empty
                    });

                continue;
            }

            string actualHash =
                await CalculateSha256Async(fullPath);

            bool matches =
                string.Equals(
                    actualHash,
                    file.Sha256,
                    StringComparison.OrdinalIgnoreCase);

            result.Files.Add(
                new IntegrityFileResult
                {
                    Path = file.Path,

                    Status = matches
                        ? IntegrityFileStatus.Valid
                        : IntegrityFileStatus.Modified,

                    ExpectedHash = file.Sha256,
                    ActualHash = actualHash
                });
        }

        result.Passed =
            result.Files.All(
                file =>
                    file.Status ==
                    IntegrityFileStatus.Valid);


        return result;
    }

    private static async Task<string> CalculateSha256Async(
        string filePath)
    {
        await using FileStream stream =
            new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 81920,
                useAsync: true);

        using SHA256 sha256 =
            SHA256.Create();

        byte[] hash =
            await sha256.ComputeHashAsync(stream);

        return Convert
            .ToHexString(hash)
            .ToLowerInvariant();
    }
}