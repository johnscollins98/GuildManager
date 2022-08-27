using System.Net;
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

  public async Task<GuildMember?> GetGuildMemberAsync(string guildId, string userId)
  {
    var response = await client.GetAsync($"{guildId}/members/{userId}");
    if (response.StatusCode == HttpStatusCode.NotFound)
    {
      return null;
    }
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<GuildMember>();
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