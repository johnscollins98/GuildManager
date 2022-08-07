using System.Text.Json.Serialization;

namespace GuildManager;

public class DiscordGuildMember
{
  public string Nick { get; set; } = String.Empty;
  public IEnumerable<string> Roles { get; set; } = new List<string>();

  [JsonPropertyName("joined_at")]
  public DateTime JoinedAt { get; set; }
}