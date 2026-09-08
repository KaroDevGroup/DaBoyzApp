using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace DaBoyzApp.Services
{
    public class UpdateService
    {
        private const string GitHubApiUrl =
            "https://api.github.com/repos/KaroDevGroup/DaBoyzApp/releases/latest";

        private const string InstallerFileName =
            "DaBoyzApp-Setup.exe";

        private static string CurrentVersion
        {
            get
            {
                Version? version =
                    Assembly.GetExecutingAssembly()
                        .GetName()
                        .Version;

                return version?.ToString(3) ?? "0.0.0";
            }
        }

        private readonly HttpClient _httpClient;

        public UpdateService()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue(
                    "DaBoyzApp",
                    CurrentVersion
                )
            );

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(
                    "application/vnd.github+json"
                )
            );
        }

        // ---------------------------------------------------------
        // GET LATEST GITHUB RELEASE
        // ---------------------------------------------------------

        public async Task<GitHubRelease?> GetLatestReleaseAsync()
        {
            try
            {
                using HttpResponseMessage response =
                    await _httpClient.GetAsync(GitHubApiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                string json =
                    await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<GitHubRelease>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            catch
            {
                return null;
            }
        }

        // ---------------------------------------------------------
        // CHECK IF UPDATE IS AVAILABLE
        // ---------------------------------------------------------

        public async Task<GitHubRelease?> GetAvailableUpdateAsync()
        {
            GitHubRelease? release =
                await GetLatestReleaseAsync();

            if (release == null ||
                string.IsNullOrWhiteSpace(release.Tag_Name))
            {
                return null;
            }

            string latestVersion =
                release.Tag_Name.TrimStart('v', 'V');

            if (!Version.TryParse(
                    CurrentVersion,
                    out Version? current))
            {
                return null;
            }

            if (!Version.TryParse(
                    latestVersion,
                    out Version? latest))
            {
                return null;
            }

            if (latest <= current)
            {
                return null;
            }

            return release;
        }

        // ---------------------------------------------------------
        // FIND INSTALLER
        // ---------------------------------------------------------

        public GitHubAsset? GetInstallerAsset(
            GitHubRelease release)
        {
            if (release.Assets == null)
            {
                return null;
            }

            foreach (GitHubAsset asset in release.Assets)
            {
                if (string.Equals(
                        asset.Name,
                        InstallerFileName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return asset;
                }
            }

            return null;
        }

        // ---------------------------------------------------------
        // DOWNLOAD INSTALLER
        // ---------------------------------------------------------

        public async Task<string?> DownloadInstallerAsync(
            GitHubRelease release,
            IProgress<double>? progress = null)
        {
            try
            {
                GitHubAsset? installer =
                    GetInstallerAsset(release);

                if (installer == null ||
                    string.IsNullOrWhiteSpace(
                        installer.Browser_Download_Url))
                {
                    return null;
                }

                string tempDirectory =
                    Path.Combine(
                        Path.GetTempPath(),
                        "DaBoyzApp"
                    );

                Directory.CreateDirectory(
                    tempDirectory
                );

                string installerPath =
                    Path.Combine(
                        tempDirectory,
                        InstallerFileName
                    );

                using HttpResponseMessage response =
                    await _httpClient.GetAsync(
                        installer.Browser_Download_Url,
                        HttpCompletionOption.ResponseHeadersRead
                    );

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                long? contentLength =
                    response.Content.Headers.ContentLength;

                await using Stream input =
                    await response.Content.ReadAsStreamAsync();

                await using FileStream output =
                    new FileStream(
                        installerPath,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None
                    );

                byte[] buffer =
                    new byte[81920];

                long totalBytesRead = 0;

                int bytesRead;

                while ((bytesRead =
                    await input.ReadAsync(buffer)) > 0)
                {
                    await output.WriteAsync(
                        buffer.AsMemory(
                            0,
                            bytesRead
                        )
                    );

                    totalBytesRead +=
                        bytesRead;

                    if (contentLength.HasValue &&
                        contentLength.Value > 0)
                    {
                        double percentage =
                            (double)totalBytesRead /
                            contentLength.Value *
                            100;

                        progress?.Report(
                            percentage
                        );
                    }
                }

                return installerPath;
            }
            catch
            {
                return null;
            }
        }
    }

    // =============================================================
    // GITHUB RELEASE
    // =============================================================

    public class GitHubRelease
    {
        public string? Tag_Name { get; set; }

        public string? Name { get; set; }

        public string? Body { get; set; }

        public bool Draft { get; set; }

        public bool Prerelease { get; set; }

        public GitHubAsset[]? Assets { get; set; }
    }

    // =============================================================
    // GITHUB RELEASE ASSET
    // =============================================================

    public class GitHubAsset
    {
        public string? Name { get; set; }

        public string? Browser_Download_Url { get; set; }

        public long Size { get; set; }
    }
}