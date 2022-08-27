using GuildManager.Discord;

namespace GuildManager;

public class DiscordService : IDiscordService
{
  private readonly IGuildApi discordGuildApi;
  private readonly IUserApi discordUserApi;

  public DiscordService(IGuildApi discordGuildApi, IUserApi discordUserApi)
  {
    this.discordGuildApi = discordGuildApi ?? throw new ArgumentNullException(nameof(discordGuildApi));
    this.discordUserApi = discordUserApi ?? throw new ArgumentNullException(nameof(discordUserApi));
  }

  public async Task<IEnumerable<PartialGuild>> GetBotGuildsAsync()
  {
    return await discordUserApi.GetUserGuildsAsync();
  }

  public async Task<IEnumerable<PartialGuild>> GetBotGuildsWithUserAsync(string userId)
  {
    var allGuilds = await discordUserApi.GetUserGuildsAsync();
    var memberForGuildsTask = allGuilds
      .Select(async guild => (guild, await GetGuildMemberAsync(guild.Id, userId)));

    var memberForGuilds = await Task.WhenAll(memberForGuildsTask);

    return memberForGuilds
      .Where(tuple => tuple.Item2 != null)
      .Select(tuple => tuple.Item1);
  }

  public async Task<Guild?> GetGuildDetailsAsync(string guildId)
  {
    return await discordGuildApi.GetGuildDetailsAsync(guildId);
  }

  public async Task<GuildMember?> GetGuildMemberAsync(string guildId, string userId)
  {

    return await discordGuildApi.GetGuildMemberAsync(guildId, userId);
  }

  public async Task<IEnumerable<GuildMember>?> GetGuildMembersAsync(string guildId)
  {
    return await discordGuildApi.GetGuildMemberListAsync(guildId, 1000);
  }

  public async Task<IEnumerable<Role>?> GetGuildRolesAsync(string guildId)
  {
    return await discordGuildApi.GetGuildRoleListAsync(guildId);
  }

  public async Task<bool> IsUserGuildOwnerAsync(string guildId, string userId)
  {
    var guildDetails = await discordGuildApi.GetGuildDetailsAsync(guildId);
    if (guildDetails == null)
    {
      return false;
    }

    return guildDetails.OwnerId == userId;
  }
}