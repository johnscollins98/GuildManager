namespace GuildManager;

public interface IDiscordService
{
  public Task<IEnumerable<DiscordGuildMember>?> GetGuildMembersAsync(string guildId);
}