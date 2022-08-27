namespace GuildManager;

public class GuildConfigurationService : IGuildConfigurationService
{
  private readonly IGuildConfigurationRepository guildConfigurationRepository;

  public GuildConfigurationService(IGuildConfigurationRepository guildConfigurationRepository)
  {
    this.guildConfigurationRepository = guildConfigurationRepository ?? throw new ArgumentNullException(nameof(guildConfigurationRepository));
  }

  public GuildConfiguration CreateOrUpdateGuildConfiguration(string guildId, GuildConfiguration guildConfiguration)
  {
    return guildConfigurationRepository.CreateOrUpdate(guildId, guildConfiguration);
  }

  public bool DeleteGuildConfiguration(string guildId)
  {
    return guildConfigurationRepository.Delete(guildId) != null;
  }

  public bool DoesGuildConfigurationExist(string guildId)
  {
    return guildConfigurationRepository.GuildConfigurationDoesExist(guildId);
  }

  public GuildConfiguration? GetGuildConfiguration(string guildId)
  {
    return guildConfigurationRepository.Get(guildId);
  }
}