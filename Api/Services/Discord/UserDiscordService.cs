using System.Net.Http.Headers;
using GuildManager.Discord;
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

  public async Task<GuildMember> GetUserAsGuildMemberAsync(string guildId)
  {
    var guildMember = await makeAuthenticatedRequest<GuildMember>($"guilds/{guildId}/member", HttpMethod.Get);
    return guildMember;
  }

  public async Task<IEnumerable<Guild>> GetUserGuildsAsync()
  {
    var guilds = await makeAuthenticatedRequest<IEnumerable<Guild>>("guilds", HttpMethod.Get);
    return guilds;
  }

  private async Task<T> makeAuthenticatedRequest<T>(string endpoint, HttpMethod method)
  {
    var uri = $"https://discord.com/api/users/@me/{endpoint}";
    var request = new HttpRequestMessage(method, uri);
    var token = await _httpContext.GetTokenAsync("access_token");
    if (token == null)
    {
      throw new MissingAccessTokenException();
    }

    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var response = await _httpClient.SendAsync(request);
    response.EnsureSuccessStatusCode();

    var parsedContent = await response.Content.ReadFromJsonAsync<T>();
    if (parsedContent == null)
    {
      throw new InvalidDataException(nameof(parsedContent));
    }

    return parsedContent;
  }
}