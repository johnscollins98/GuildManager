using GuildManager.Discord;

namespace GuildManager;

public interface IDiscordService
{
  public Task<IEnumerable<GuildMember>?> GetGuildMembersAsync(string guildId);
  public Task<GuildMember?> GetGuildMemberAsync(string guildId, string userId);
  public Task<IEnumerable<PartialGuild>> GetBotGuildsAsync();
  public Task<IEnumerable<PartialGuild>> GetBotGuildsWithUserAsync(string userId);
  public Task<IEnumerable<Role>?> GetGuildRolesAsync(string guildId);
  public Task<Guild?> GetGuildDetailsAsync(string guildId);
  public Task<bool> IsUserGuildOwnerAsync(string guildId, string userId);
}