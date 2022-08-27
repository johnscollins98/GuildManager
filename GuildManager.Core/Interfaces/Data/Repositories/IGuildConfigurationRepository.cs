namespace GuildManager;

public interface IGuildConfigurationRepository
{
  public IEnumerable<GuildConfiguration> GetAll();
  public bool GuildConfigurationDoesExist(string discordGuildId);
  public GuildConfiguration? Get(string discordGuildId);
  public GuildConfiguration CreateOrUpdate(string discordGuildId, GuildConfiguration updateDto);
  public GuildConfiguration? Delete(string discordGuildId);
}