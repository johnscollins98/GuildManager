using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildManager;

public class GuildConfiguration
{
  [Key]
  public string DiscordGuildId { get; set; } = String.Empty;
  public string GuildWarsGuildId { get; set; } = String.Empty;
  public string GuildWarsApiKey { get; set; } = String.Empty;
  public List<AdminRole> AdminRoles { get; set; } = new List<AdminRole>();
}