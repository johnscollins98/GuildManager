using GuildManager.Discord;

namespace GuildManager;

public interface IUserDiscordService
{
  public Task<IEnumerable<Guild>> GetUserGuildsAsync();
  public Task<GuildMember> GetUserAsGuildMemberAsync(string guildId);
}