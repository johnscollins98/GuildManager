using System.Net.Http.Json;

namespace GuildManager.Discord;

public class GuildApi : IGuildApi
{
  private readonly HttpClient client;

  public GuildApi(HttpClient client)
  {
    this.client = client ?? throw new ArgumentNullException(nameof(client));
  }

  public Task<Guild?> GetGuildDetailsAsync(string guildId)
  {
    return client.GetFromJsonAsync<Guild?>($"{guildId}");
  }

  public Task<GuildMember?> GetGuildMemberAsync(string guildId, string userId)
  {
    return client.GetFromJsonAsync<GuildMember?>($"{guildId}/members/{userId}");
  }

  public Task<IEnumerable<GuildMember>?> GetGuildMemberListAsync(string guildId, int limit)
  {
    return client.GetFromJsonAsync<IEnumerable<GuildMember>?>($"{guildId}/members?limit={limit}");
  }

  public Task<IEnumerable<Role>?> GetGuildRoleListAsync(string guildId)
  {
    return client.GetFromJsonAsync<IEnumerable<Role>?>($"{guildId}/roles");
  }
}