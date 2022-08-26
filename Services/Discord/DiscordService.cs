using GuildManager.Discord;

namespace GuildManager;

public class DiscordService : IDiscordService
{
  private readonly HttpClient httpClient;

  public DiscordService(HttpClient httpClient)
  {
    this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
  }

  public async Task<IEnumerable<GuildMember>?> GetGuildMembersAsync(string guildId)
  {
    return await httpClient.GetFromJsonAsync<IEnumerable<GuildMember>>(
      $"guilds/{guildId}/members?limit=1000");
  }
}