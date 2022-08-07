using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

namespace GuildManager;

public class UserDiscordService : IUserDiscordService
{
  private readonly HttpClient _httpClient;
  private readonly HttpContext _httpContext;

  public UserDiscordService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
  {
    _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
  }

  public async Task<DiscordGuildMember> GetUserAsGuildMemberAsync(string guildId)
  {
    var guildMember = await makeAuthenticatedRequest<DiscordGuildMember>($"guilds/{guildId}/member", HttpMethod.Get);
    return guildMember;
  }

  public async Task<IEnumerable<DiscordGuild>> GetUserGuildsAsync()
  {
    var guilds = await makeAuthenticatedRequest<IEnumerable<DiscordGuild>>("guilds", HttpMethod.Get);
    return guilds;
  }

  private async Task<T> makeAuthenticatedRequest<T>(string endpoint, HttpMethod method)
  {
    var uri = $"https://discord.com/api/users/@me/{endpoint}";
    var request = new HttpRequestMessage(method, uri);
    var token = await _httpContext.GetTokenAsync("access_token");
    if (token == null)
    {
      throw new NullReferenceException(nameof(token));
    }

    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var response = await _httpClient.SendAsync(request);
    response.EnsureSuccessStatusCode();

    var parsedContent = await response.Content.ReadFromJsonAsync<T>();
    if (parsedContent == null)
    {
      throw new NullReferenceException(nameof(parsedContent));
    }

    return parsedContent;
  }
}