namespace GuildManager.Discord;

public class GuildMemberDto
{
  public string Nick { get; set; } = String.Empty;
  public Discord.UserDto User { get; set; } = new UserDto();
  public IEnumerable<string> Roles { get; set; } = new List<string>();
  public DateTime JoinedAt { get; set; }
}