namespace GuildManager;

public class GuildConfigurationDetailsDto
{
  public string DiscordGuildId { get; set; } = String.Empty;
  public string GuildWarsGuildId { get; set; } = String.Empty;
  public string GuildWarsApiKey { get; set; } = String.Empty;
  public IEnumerable<string> AdminRoleIds { get; set; } = Enumerable.Empty<string>();
}