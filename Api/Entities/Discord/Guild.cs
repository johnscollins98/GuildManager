namespace GuildManager.Discord;

public class Guild
{
  public string Id { get; set; } = String.Empty;
  public string Name { get; set; } = String.Empty;
  public string Icon { get; set; } = String.Empty;
  public bool Owner { get; set; }
}