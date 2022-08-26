using GuildManager.Discord;

namespace GuildManager;

public class DiscordService : IDiscordService
{
  private readonly HttpClient httpClient;

  public DiscordService(HttpClient httpClient)
  {
    this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
  }

  public async Task<IEnumerable<Guild>> GetBotGuilds()
  {
    var botGuilds = await httpClient.GetFromJsonAsync<IEnumerable<Guild>>("users/@me/guilds");
    if (botGuilds == null)
    {
      throw new FormatException("Received empty response for bot guilds");
    }
    return botGuilds;
  }

  public async Task<IEnumerable<GuildMember>?> GetGuildMembersAsync(string guildId)
  {
    return await httpClient.GetFromJsonAsync<IEnumerable<GuildMember>>(
      $"guilds/{guildId}/members?limit=1000");
  }

  public async Task<IEnumerable<Role>?> GetGuildRoles(string guildId)
  {
    return await httpClient.GetFromJsonAsync<IEnumerable<Role>>(
      $"guilds/{guildId}/roles");
  }
}