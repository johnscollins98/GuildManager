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
    return fetchNullableValueAsync<Guild>($"{guildId}");
  }

  public Task<GuildMember?> GetGuildMemberAsync(string guildId, string userId)
  {
    return fetchNullableValueAsync<GuildMember>($"{guildId}/members/{userId}");
  }

  public Task<IEnumerable<GuildMember>?> GetGuildMemberListAsync(string guildId, int limit)
  {
    return fetchNullableValueAsync<IEnumerable<GuildMember>>($"{guildId}/members?limit={limit}");
  }

  public Task<IEnumerable<Role>?> GetGuildRoleListAsync(string guildId)
  {
    return fetchNullableValueAsync<IEnumerable<Role>>($"{guildId}/roles");
  }

  private async Task<T?> fetchNullableValueAsync<T>(string endpoint)
  {
    var response = await client.GetAsync(endpoint);
    if (response.StatusCode == HttpStatusCode.NotFound)
    {
      return default(T);
    }
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<T>();
  }
}