// KaroDevGroup
// Josh Karo

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DaBoyzApp.Services;

public static class SupabaseAuthService
{
    private const string SupabaseUrl =
        "https://awpiwexmgyvcqxjxqyjr.supabase.co";

    private const string SupabasePublicKey =
        "sb_publishable_AGV5jYxtDPactSQudssimQ_MbWzhBUO";

    internal static string ProjectUrl =>
        SupabaseUrl;

    internal static string PublicKey =>
        SupabasePublicKey;

    private static readonly HttpClient HttpClient =
        new HttpClient();

    public static string? AccessToken { get; private set; }

    public static string? UserId { get; private set; }

    public static string? DiscordUserId { get; private set; }

    public static string? DisplayName { get; private set; }

    public static string? RoleName { get; private set; }

    public static async Task<AuthResult> SignInAsync(
        string email,
        string password)
    {
        try
        {
            string url =
                $"{SupabaseUrl}/auth/v1/token?grant_type=password";

            var payload = new
            {
                email,
                password
            };

            string json =
                JsonSerializer.Serialize(
                    payload);

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

            request.Headers.Add(
                "apikey",
                SupabasePublicKey);

            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");


            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);

            string responseJson =
                await response.Content
                    .ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new AuthResult
                {
                    Success = false,
                    Message =
                        "Invalid email or password."
                };
            }

            using JsonDocument document =
                JsonDocument.Parse(
                    responseJson);

            JsonElement root =
                document.RootElement;

            if (!root.TryGetProperty(
                    "access_token",
                    out JsonElement accessTokenElement))
            {
                return new AuthResult
                {
                    Success = false,
                    Message =
                        "Supabase did not return an access token."
                };
            }

            string? accessToken =
                accessTokenElement.GetString();

            if (!root.TryGetProperty(
                    "user",
                    out JsonElement userElement))
            {
                return new AuthResult
                {
                    Success = false,
                    Message =
                        "Supabase did not return user information."
                };
            }

            if (!userElement.TryGetProperty(
                    "id",
                    out JsonElement idElement))
            {
                return new AuthResult
                {
                    Success = false,
                    Message =
                        "Unable to identify the signed-in user."
                };
            }

            string? userId =
                idElement.GetString();


            if (string.IsNullOrWhiteSpace(
                    accessToken) ||
                string.IsNullOrWhiteSpace(
                    userId))
            {
                return new AuthResult
                {
                    Success = false,
                    Message =
                        "Invalid authentication response."
                };
            }

            AdminProfile? profile =
                await GetAdminProfileAsync(
                    userId,
                    accessToken);

            if (profile == null)
            {
                ClearSession();

                return new AuthResult
                {
                    Success = false,
                    Message =
                        "This account is not authorized to access the Admin Portal."
                };
            }

            if (!profile.IsActive)
            {
                ClearSession();

                return new AuthResult
                {
                    Success = false,
                    Message =
                        "This administrator account is disabled."
                };
            }

            AccessToken =
                accessToken;

            UserId =
                userId;

            DiscordUserId =
                profile.DiscordUserId;

            DisplayName =
                profile.DisplayName;

            RoleName =
                profile.RoleName;


            return new AuthResult
            {
                Success = true,
                Message =
                    $"Welcome back, {profile.DisplayName}.",
                Profile =
                    profile
            };
        }
        catch (Exception ex)
        {
            ClearSession();

            return new AuthResult
            {
                Success = false,
                Message =
                    $"Unable to connect to the authentication server: {ex.Message}"
            };
        }
    }

    private static async Task<AdminProfile?>
        GetAdminProfileAsync(
            string userId,
            string accessToken)
    {
        string url =
            $"{SupabaseUrl}/rest/v1/admin_profiles" +
            $"?user_id=eq.{userId}" +
            "&select=user_id,discord_user_id,display_name,role_name,is_active" +
            "&limit=1";

        using HttpRequestMessage request =
            new HttpRequestMessage(
                HttpMethod.Get,
                url);

        request.Headers.Add(
            "apikey",
            SupabasePublicKey);

        request.Headers.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                accessToken);

        using HttpResponseMessage response =
            await HttpClient.SendAsync(
                request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        string json =
            await response.Content
                .ReadAsStringAsync();

        using JsonDocument document =
            JsonDocument.Parse(
                json);

        JsonElement root =
            document.RootElement;

        if (root.ValueKind !=
            JsonValueKind.Array)
        {
            return null;
        }

        JsonElement profileElement =
            root.EnumerateArray()
                .FirstOrDefault();

        if (profileElement.ValueKind ==
            JsonValueKind.Undefined)
        {
            return null;
        }

        return new AdminProfile
        {
            UserId =
                profileElement
                    .GetProperty("user_id")
                    .GetString() ?? "",

            DiscordUserId =
                profileElement
                    .GetProperty("discord_user_id")
                    .GetString() ?? "",

            DisplayName =
                profileElement
                    .GetProperty("display_name")
                    .GetString() ?? "",

            RoleName =
                profileElement
                    .GetProperty("role_name")
                    .GetString() ?? "",

            IsActive =
                profileElement
                    .GetProperty("is_active")
                    .GetBoolean()
        };
    }

    public static void ClearSession()
    {
        AccessToken = null;
        UserId = null;
        DiscordUserId = null;
        DisplayName = null;
        RoleName = null;
    }
}

public sealed class AuthResult
{
    public bool Success { get; set; }

    public string Message { get; set; } =
        string.Empty;

    public AdminProfile? Profile { get; set; }
}

public sealed class AdminProfile
{
    public string UserId { get; set; } =
        string.Empty;

    public string DiscordUserId { get; set; } =
        string.Empty;

    public string DisplayName { get; set; } =
        string.Empty;

    public string RoleName { get; set; } =
        string.Empty;

    public bool IsActive { get; set; }
}