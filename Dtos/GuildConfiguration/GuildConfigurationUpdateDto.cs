namespace GuildManager;

public class GuildConfigurationUpdateDto
{
  public string GuildWarsGuildId { get; set; } = String.Empty;
  public string GuildWarsApiKey { get; set; } = String.Empty;
  public IEnumerable<string> AdminRoleIds { get; set; } = Enumerable.Empty<string>();
}