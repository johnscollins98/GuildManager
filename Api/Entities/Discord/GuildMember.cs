using System.Text.Json.Serialization;

namespace GuildManager.Discord;

public class GuildMember
{
  public string Nick { get; set; } = String.Empty;
  public IEnumerable<string> Roles { get; set; } = new List<string>();

  [JsonPropertyName("joined_at")]
  public DateTime JoinedAt { get; set; }
  public Discord.User User { get; set; } = new Discord.User();
}