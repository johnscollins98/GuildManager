using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace GuildManager;

public class GuildConfigurationDbRepository : IGuildConfigurationRepository
{
  private readonly GuildManagerDbContext dbContext;
  private readonly IMapper mapper;

  public GuildConfigurationDbRepository(GuildManagerDbContext dbContext, IMapper mapper)
  {
    this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }
  public GuildConfiguration CreateOrUpdate(string discordGuildId, GuildConfigurationUpdateDto updateDto)
  {
    var entityToBeCreated = mapper.Map<GuildConfiguration>(updateDto);
    entityToBeCreated.DiscordGuildId = discordGuildId;
    var guildConfiguration = Get(discordGuildId);

    if (guildConfiguration != null)
    {
      guildConfiguration.AdminRoles = entityToBeCreated.AdminRoles;
      guildConfiguration.GuildWarsApiKey = entityToBeCreated.GuildWarsApiKey;
      guildConfiguration.GuildWarsGuildId = entityToBeCreated.GuildWarsGuildId;
      dbContext.GuildConfigurations.Update(guildConfiguration);
    }
    else
    {
      dbContext.GuildConfigurations.Add(entityToBeCreated);
    }

    dbContext.SaveChanges();
    return entityToBeCreated;
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