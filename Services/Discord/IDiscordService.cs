using GuildManager.Discord;

namespace GuildManager;

public interface IDiscordService
{
  public Task<IEnumerable<GuildMember>?> GetGuildMembersAsync(string guildId);
  public Task<IEnumerable<Guild>> GetBotGuilds();
  public Task<IEnumerable<Role>?> GetGuildRoles(string guildId);
}