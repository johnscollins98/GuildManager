namespace GuildManager;

public class DiscordGuildMemberDto
{
  public string Nick { get; set; } = String.Empty;
  public IEnumerable<string> Roles { get; set; } = new List<string>();
  public DateTime JoinedAt { get; set; }
}