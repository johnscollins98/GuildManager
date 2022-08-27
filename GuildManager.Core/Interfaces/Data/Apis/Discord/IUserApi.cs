namespace GuildManager.Discord;

public interface IUserApi
{
  public Task<IEnumerable<PartialGuild>> GetUserGuildsAsync();
}