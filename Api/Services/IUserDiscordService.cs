namespace GuildManager;

public interface IUserDiscordService
{
  public Task<IEnumerable<DiscordGuild>> GetUserGuildsAsync();
  public Task<DiscordGuildMember> GetUserAsGuildMemberAsync(string guildId);
}