namespace GuildManager.Discord;

public interface IGuildApi
{
  public Task<Guild?> GetGuildDetailsAsync(string guildId);
  public Task<GuildMember?> GetGuildMemberAsync(string guildId, string userId);
  public Task<IEnumerable<GuildMember>?> GetGuildMemberListAsync(string guildId, int limit);
  public Task<IEnumerable<Role>?> GetGuildRoleListAsync(string guildId);
}