namespace GuildManager;

public interface IGuildConfigurationService
{
  public GuildConfiguration? GetGuildConfiguration(string guildId);
  public GuildConfiguration CreateOrUpdateGuildConfiguration(string guildId, GuildConfiguration guildConfiguration);
  public bool DoesGuildConfigurationExist(string guildId);
  public bool DeleteGuildConfiguration(string guildId);
}