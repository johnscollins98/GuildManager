using System.ComponentModel.DataAnnotations;

namespace GuildManager;

public class AdminRole
{
  [Key]
  public string RoleId { get; set; } = String.Empty;
}