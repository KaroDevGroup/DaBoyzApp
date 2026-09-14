// KaroDevGroup
// Josh Karo

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace DaBoyzApp.Services;

public static class ModerationService
{
    private const string GuildId =
        "908868924488171540";

    private static readonly HttpClient HttpClient =
        new HttpClient();

    public static async Task<ModerationResult> WarnMemberAsync(
        string targetUserId,
        string reason)
    {
        try
        {

            string? accessToken =
                SupabaseAuthService.AccessToken;

            string? moderatorId =
                SupabaseAuthService.DiscordUserId;


            if (string.IsNullOrWhiteSpace(
                    accessToken))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        "You are not signed in."
                };
            }

            if (string.IsNullOrWhiteSpace(
                    moderatorId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        "Your Discord account is not linked."
                };
            }

            if (string.IsNullOrWhiteSpace(
                    targetUserId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        "A member ID is required."
                };
            }

            if (!ulong.TryParse(
                    targetUserId,
                    out _))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        "The member ID is invalid."
                };
            }

            if (string.IsNullOrWhiteSpace(
                    reason))
            {
                reason =
                    "No reason provided";
            }

            var payload = new
            {
                action = "warn",

                guild_id =
                    GuildId,

                moderator_id =
                    moderatorId,

                target_user_id =
                    targetUserId,

                reason,

                bot_key =
                    "daboyz",

                status =
                    "pending"
            };

            string json =
                JsonSerializer.Serialize(
                    payload);


            string url =
                $"{SupabaseAuthService.ProjectUrl}" +
                "/rest/v1/moderation_requests";


            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

            request.Headers.Add(
                "apikey",
                SupabaseAuthService.PublicKey);

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    accessToken);

            request.Headers.Add(
                "Prefer",
                "return=minimal");

            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);


            string responseText =
                await response.Content
                    .ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        $"Unable to submit warning request. " +
                        $"HTTP {(int)response.StatusCode}: " +
                        responseText
                };
            }

            return new ModerationResult
            {
                Success = true,
                Message =
                    "Warning request submitted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ModerationResult
            {
                Success = false,
                Message =
                    $"Moderation request failed: {ex.Message}"
            };
        }
    }

    public static async Task<ModerationResult> TimeoutMemberAsync(
        string targetUserId,
        string duration,
        string reason)
    {
        try
        {
            string? accessToken =
                SupabaseAuthService.AccessToken;

            string? moderatorId =
                SupabaseAuthService.DiscordUserId;

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "You are not signed in."
                };
            }

            if (string.IsNullOrWhiteSpace(moderatorId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "Your Discord account is not linked."
                };
            }

            if (string.IsNullOrWhiteSpace(targetUserId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "A member ID is required."
                };
            }

            if (!ulong.TryParse(targetUserId, out _))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "The member ID is invalid."
                };
            }

            if (string.IsNullOrWhiteSpace(duration))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "A timeout duration is required."
                };
            }

            duration =
                duration.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(reason))
            {
                reason =
                    "No reason provided.";
            }

            var payload = new
            {
                action = "timeout",

                guild_id =
                    GuildId,
                
                moderator_id =
                    moderatorId,
                
                target_user_id =
                    targetUserId,
                
                reason,

                bot_key =
                    "daboyz",
                
                status = 
                    "pending",

                duration
            };

            string json =
                JsonSerializer.Serialize(
                    payload);

            string url =
                $"{SupabaseAuthService.ProjectUrl}" +
                "/rest/v1/moderation_requests";

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);
            
            request.Headers.Add(
                "apikey",
                SupabaseAuthService.PublicKey);
            
            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    accessToken);
            
            request.Headers.Add(
                "Prefer",
                "return=minimal");

            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);

            string responseText =
                await response.Content
                    .ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = 
                        $"Unable to submit timeout request. " +
                        $"HTTP {(int)response.StatusCode}: " +
                        responseText
                };
            }

            return new ModerationResult
            {
                Success = true,
                Message = 
                    "Timeout request submitted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ModerationResult
            {
                Success = false,
                Message =
                    $"Moderation request failed. {ex.Message}"
            };
        }
    }
    public static async Task<ModerationResult> KickMemberAsync(
        string targetUserId,
        string reason)
    {
        try
        {
            string? accessToken = 
                SupabaseAuthService.AccessToken;

            string? moderatorId =
                SupabaseAuthService.DiscordUserId;

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "You are not signed in."
                };
            }
            if (string.IsNullOrWhiteSpace(moderatorId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "Your discord account is not linked."
                };
            }
            if (string.IsNullOrWhiteSpace(targetUserId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "A member ID is required."
                };
            }
            if (!ulong.TryParse(targetUserId, out _))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "The member ID is invalid."
                };
            }
            if (string.IsNullOrWhiteSpace(reason))
            {
                reason =
                    "No reason provided.";
            }
            var payload = new
            {
                action = "kick",

                guild_id =
                    GuildId,
                
                moderator_id = 
                    moderatorId,

                target_user_id =
                    targetUserId,

                reason,

                bot_key =
                    "daboyz",

                status =
                    "pending"
            };
            string json =
                JsonSerializer.Serialize(
                    payload);

            string url =
                $"{SupabaseAuthService.ProjectUrl}" +
                "/rest/v1/moderation_requests";

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

            request.Headers.Add(
                "apikey",
                SupabaseAuthService.PublicKey);
            
            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    accessToken);
            
            request.Headers.Add(
                "Prefer",
                "return=minimal");
            
            request.Content = 
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");
            
            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);
            
            string responseText =
                await response.Content
                    .ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = 
                        $"Unable to submit kick request. " +
                        $"HTTP {(int)response.StatusCode}: " +
                        responseText
                };
            }
            return new ModerationResult
            {
                Success = true,
                Message = 
                    "Kick request submitted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ModerationResult
            {
                Success = false,
                Message = 
                    $"Moderation request failed: {ex.Message}"
            };
        }
    }

    public static async Task<ModerationResult> BanMemberAsync(
        string targetUserId,
        string reason)
    {
        try
        {
            string? accessToken = 
                SupabaseAuthService.AccessToken;
            
            string? moderatorId =
                SupabaseAuthService.DiscordUserId;

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "You are not signed in."
                };
            }
            if (string.IsNullOrWhiteSpace(moderatorId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "Your discord account is not linked."
                };
            }
            if (string.IsNullOrWhiteSpace(targetUserId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "A member ID is required."
                };
            }
            if (!ulong.TryParse(targetUserId, out _))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "The member ID is invalid."
                };
            }
            if (string.IsNullOrWhiteSpace(reason))
            {
                reason = 
                    "No reason provided";
            }
            var payload = new
            {
                action = "ban",

                guild_id = 
                    GuildId,

                moderator_id =
                    moderatorId,

                target_user_id =  
                    targetUserId,

                reason,

                bot_key =
                    "daboyz",
                
                status = 
                    "pending"
            };
            string json = 
                JsonSerializer.Serialize(
                    payload);

            string url = 
                $"{SupabaseAuthService.ProjectUrl}" +
                "/rest/v1/moderation_requests";

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);
            
            request.Headers.Add(
                "apikey",
                SupabaseAuthService.PublicKey);
            
            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    accessToken);
            
            request.Headers.Add(
                "Prefer",
                "return=minimal");
            
            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");
            
            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);
            
            string responseText =
                await response.Content
                    .ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = 
                        $"Unable to submit ban request. " +
                        $"HTTP {(int)response.StatusCode}: " +
                        responseText
                };
            }
            return new ModerationResult
            {
                Success = true,
                Message = 
                    "Ban request submitted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ModerationResult
            {
                Success = false,
                Message = 
                    $"Moderation request failed: {ex.Message}"
            };
        }
    }

    public static async Task<ModerationResult> UnbanMemberAsync(
        string targetUserId,
        string reason)
    {
        try
        {
            string? accessToken =
                SupabaseAuthService.AccessToken;

            string? moderatorId =
                SupabaseAuthService.DiscordUserId;


            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "You are not signed in."
                };
            }

            if (string.IsNullOrWhiteSpace(moderatorId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "Your Discord account is not linked."
                };
            }

            if (string.IsNullOrWhiteSpace(targetUserId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "A Discord user ID is required."
                };
            }

            if (!ulong.TryParse(targetUserId, out _))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "The Discord user ID is invalid."
                };
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                reason =
                    "No reason provided";
            }

            var payload = new
            {
                action = "unban",

                guild_id =
                    GuildId,

                moderator_id =
                    moderatorId,

                target_user_id =
                    targetUserId,

                reason,

                bot_key =
                    "daboyz",

                status =
                    "pending"
            };

            string json =
                JsonSerializer.Serialize(
                    payload);

            string url =
                $"{SupabaseAuthService.ProjectUrl}" +
                "/rest/v1/moderation_requests";

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

            request.Headers.Add(
                "apikey",
                SupabaseAuthService.PublicKey);

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    accessToken);

            request.Headers.Add(
                "Prefer",
                "return=minimal");

            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);

            string responseText =
                await response.Content
                    .ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        $"Unable to submit unban request. " +
                        $"HTTP {(int)response.StatusCode}: " +
                        responseText
                };
            }

            return new ModerationResult
            {
                Success = true,
                Message =
                    "Unban request submitted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ModerationResult
            {
                Success = false,
                Message =
                    $"Moderation request failed: {ex.Message}"
            };
        }
    }

    public static async Task<ModerationResult> ClearMessagesAsync(
        string channelId,
        int amount)
    {
        try
        {
            string? accessToken =
                SupabaseAuthService.AccessToken;

            string? moderatorId =
                SupabaseAuthService.DiscordUserId;

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "You are not signed in."
                };
            }

            if (string.IsNullOrWhiteSpace(moderatorId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "Your Discord account is not linked."
                };
            }

            if (string.IsNullOrWhiteSpace(channelId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "A Discord channel ID is required."
                };
            }

            if (!ulong.TryParse(channelId, out _))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "The Discord channel ID is invalid."
                };
            }

            if (amount < 1 || amount > 100)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "Message amount must be between 1 and 100."
                };
            }

            var payload = new
            {
                action = "clear",

                guild_id =
                    GuildId,

                moderator_id =
                    moderatorId,

                target_user_id =
                    "0",

                channel_id =
                    channelId,

                reason =
                    "Clear messages",

                bot_key =
                    "daboyz",

                status =
                    "pending",

                amount
            };

            string json =
                JsonSerializer.Serialize(
                    payload);

            string url =
                $"{SupabaseAuthService.ProjectUrl}" +
                "/rest/v1/moderation_requests";

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

            request.Headers.Add(
                "apikey",
                SupabaseAuthService.PublicKey);

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    accessToken);

            request.Headers.Add(
                "Prefer",
                "return=minimal");

            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);

            string responseText =
                await response.Content
                    .ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        $"Unable to submit clear request. " +
                        $"HTTP {(int)response.StatusCode}: " +
                        responseText
                };
            }

            return new ModerationResult
            {
                Success = true,
                Message =
                    "Clear request submitted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ModerationResult
            {
                Success = false,
                Message =
                    $"Moderation request failed: {ex.Message}"
            };
        }
    }

    public static async Task<ModerationResult> LockChannelAsync(
        string channelId)
    {
        try
        {
            string? accessToken =
                SupabaseAuthService.AccessToken;

            string? moderatorId =
                SupabaseAuthService.DiscordUserId;

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "You are not signed in."
                };
            }

            if (string.IsNullOrWhiteSpace(moderatorId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "Your Discord account is not linked."
                };
            }

            if (string.IsNullOrWhiteSpace(channelId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "A Discord channel ID is required."
                };
            }

            if (!ulong.TryParse(channelId, out _))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "The Discord channel ID is invalid."
                };
            }

            var payload = new
            {
                action = "lock",

                guild_id =
                    GuildId,

                moderator_id =
                    moderatorId,

                target_user_id =
                    "0",

                channel_id =
                    channelId,

                reason =
                    "Lock channel",

                bot_key =
                    "daboyz",

                status =
                    "pending"
            };

            string json =
                JsonSerializer.Serialize(
                    payload);

            string url =
                $"{SupabaseAuthService.ProjectUrl}" +
                "/rest/v1/moderation_requests";

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

            request.Headers.Add(
                "apikey",
                SupabaseAuthService.PublicKey);

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    accessToken);

            request.Headers.Add(
                "Prefer",
                "return=minimal");

            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);

            string responseText =
                await response.Content
                    .ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        $"Unable to submit lock request. " +
                        $"HTTP {(int)response.StatusCode}: " +
                        responseText
                };
            }

            return new ModerationResult
            {
                Success = true,
                Message =
                    "Lock request submitted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ModerationResult
            {
                Success = false,
                Message =
                    $"Moderation request failed: {ex.Message}"
            };
        }
    }

    public static async Task<ModerationResult> UnlockChannelAsync(
        string channelId)
    {
        try
        {
            string? accessToken =
                SupabaseAuthService.AccessToken;

            string? moderatorId =
                SupabaseAuthService.DiscordUserId;


            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "You are not signed in."
                };
            }

            if (string.IsNullOrWhiteSpace(moderatorId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "Your Discord account is not linked."
                };
            }

            if (string.IsNullOrWhiteSpace(channelId))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "A Discord channel ID is required."
                };
            }

            if (!ulong.TryParse(channelId, out _))
            {
                return new ModerationResult
                {
                    Success = false,
                    Message = "The Discord channel ID is invalid."
                };
            }

            var payload = new
            {
                action = "unlock",

                guild_id =
                    GuildId,

                moderator_id =
                    moderatorId,

                target_user_id =
                    "0",

                channel_id =
                    channelId,

                reason =
                    "Unlock channel",

                bot_key =
                    "daboyz",

                status =
                    "pending"
            };

            string json =
                JsonSerializer.Serialize(
                    payload);

            string url =
                $"{SupabaseAuthService.ProjectUrl}" +
                "/rest/v1/moderation_requests";

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

            request.Headers.Add(
                "apikey",
                SupabaseAuthService.PublicKey);

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    accessToken);

            request.Headers.Add(
                "Prefer",
                "return=minimal");

            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            using HttpResponseMessage response =
                await HttpClient.SendAsync(
                    request);

            string responseText =
                await response.Content
                    .ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ModerationResult
                {
                    Success = false,
                    Message =
                        $"Unable to submit unlock request. " +
                        $"HTTP {(int)response.StatusCode}: " +
                        responseText
                };
            }

            return new ModerationResult
            {
                Success = true,
                Message =
                    "Unlock request submitted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ModerationResult
            {
                Success = false,
                Message =
                    $"Moderation request failed: {ex.Message}"
            };
        }
    }
}

public sealed class ModerationResult
{
    public bool Success { get; set; }

    public string Message { get; set; } =
        string.Empty;
}