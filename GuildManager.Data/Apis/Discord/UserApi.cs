using System.Net.Http.Json;

namespace GuildManager.Discord;

public class UserApi : IUserApi
{
  private readonly HttpClient client;

  public UserApi(HttpClient client)
  {
    this.client = client ?? throw new ArgumentNullException(nameof(client));
  }
  public async Task<IEnumerable<PartialGuild>> GetUserGuildsAsync()
  {
    var response = await client.GetFromJsonAsync<IEnumerable<PartialGuild>>("guilds");
    if (response == null)
    {
      throw new FormatException("User guilds returned null");
    }
    return response;
  }
}