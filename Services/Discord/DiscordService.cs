using System.Net;
using GuildManager.Discord;

namespace GuildManager;

public class DiscordService : IDiscordService
{
  private readonly HttpClient httpClient;

  public DiscordService(HttpClient httpClient)
  {
    this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
  }

  public async Task<IEnumerable<PartialGuild>> GetBotGuildsAsync()
  {
    var botGuilds = await httpClient.GetFromJsonAsync<IEnumerable<PartialGuild>>("users/@me/guilds");
    if (botGuilds == null)
    {
      throw new FormatException("Received empty response for bot guilds");
    }
    return botGuilds;
  }

  public async Task<IEnumerable<PartialGuild>> GetBotGuildsWithUserAsync(string userId)
  {
    var allGuilds = await GetBotGuildsAsync();
    var memberForGuildsTask = allGuilds
      .Select(async guild => (guild, await GetGuildMemberAsync(guild.Id, userId)));

    var memberForGuilds = await Task.WhenAll(memberForGuildsTask);

    return memberForGuilds
      .Where(tuple => tuple.Item2 != null)
      .Select(tuple => tuple.Item1);
  }

  public async Task<Guild?> GetGuildDetailsAsync(string guildId)
  {
    var response = await httpClient.GetAsync($"guilds/{guildId}");
    if (response.StatusCode == HttpStatusCode.NotFound)
    {
      return null;
    };
    response.EnsureSuccessStatusCode();

    return await response.Content.ReadFromJsonAsync<Guild>();
  }

  public async Task<GuildMember?> GetGuildMemberAsync(string guildId, string userId)
  {
    var response = await httpClient.GetAsync($"guilds/{guildId}/members/{userId}");
    if (response.StatusCode == HttpStatusCode.NotFound) 
    {
      return null;
    }
    response.EnsureSuccessStatusCode();

    return await response.Content.ReadFromJsonAsync<GuildMember>();
  }

  public async Task<IEnumerable<GuildMember>?> GetGuildMembersAsync(string guildId)
  {
    return await httpClient.GetFromJsonAsync<IEnumerable<GuildMember>>(
      $"guilds/{guildId}/members?limit=1000");
  }

  public async Task<IEnumerable<Role>?> GetGuildRolesAsync(string guildId)
  {
    return await httpClient.GetFromJsonAsync<IEnumerable<Role>>(
      $"guilds/{guildId}/roles");
  }

  public async Task<bool> IsUserGuildOwnerAsync(string guildId, string userId)
  {
    var guildDetails = await GetGuildDetailsAsync(guildId);
    if (guildDetails == null)
    {
      return false;
    }
    return guildDetails.OwnerId == userId;
  }
}