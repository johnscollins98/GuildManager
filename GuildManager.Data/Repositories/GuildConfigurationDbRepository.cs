using Microsoft.EntityFrameworkCore;

namespace GuildManager;

public class GuildConfigurationDbRepository : IGuildConfigurationRepository
{
  private readonly GuildManagerDbContext dbContext;

  public GuildConfigurationDbRepository(GuildManagerDbContext dbContext)
  {
    this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
  }
  public GuildConfiguration CreateOrUpdate(string discordGuildId, GuildConfiguration updateDto)
  {
    updateDto.DiscordGuildId = discordGuildId;
    var guildConfiguration = Get(discordGuildId);

    if (guildConfiguration != null)
    {
      guildConfiguration.AdminRoles = updateDto.AdminRoles;
      guildConfiguration.GuildWarsApiKey = updateDto.GuildWarsApiKey;
      guildConfiguration.GuildWarsGuildId = updateDto.GuildWarsGuildId;
      dbContext.GuildConfigurations.Update(guildConfiguration);
    }
    else
    {
      dbContext.GuildConfigurations.Add(updateDto);
    }

    dbContext.SaveChanges();
    return updateDto;
  }

  public GuildConfiguration? Delete(string discordGuildId)
  {
    var guildConfigEntity = Get(discordGuildId);
    if (guildConfigEntity == null)
    {
      return null;
    }

    dbContext.GuildConfigurations.Remove(guildConfigEntity);
    dbContext.SaveChanges();
    return guildConfigEntity;
  }

  public IEnumerable<GuildConfiguration> GetAll()
  {
    return dbContext.GuildConfigurations;
  }

  public GuildConfiguration? Get(string discordGuildId)
  {
    return dbContext.GuildConfigurations
      .Include(config => config.AdminRoles)
      .Where(entity => entity.DiscordGuildId == discordGuildId)
      .FirstOrDefault();
  }

  public bool GuildConfigurationDoesExist(string discordGuildId)
  {
    return dbContext.GuildConfigurations
      .Any(entity => entity.DiscordGuildId == discordGuildId);
  }
}