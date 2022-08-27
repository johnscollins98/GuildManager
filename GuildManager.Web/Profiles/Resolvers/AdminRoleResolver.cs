using AutoMapper;

namespace GuildManager;

public class AdminRoleResolver : IValueResolver<GuildConfigurationUpdateDto, GuildConfiguration, List<AdminRole>>
{
  private readonly GuildManagerDbContext dbContext;

  public AdminRoleResolver(GuildManagerDbContext dbContext)
  {
    this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
  }

  public List<AdminRole> Resolve(GuildConfigurationUpdateDto source, GuildConfiguration destination, List<AdminRole> destMember, ResolutionContext context)
  {
    return source.AdminRoleIds.Select(id => 
    {
      return dbContext.AdminRoles.FirstOrDefault(dbRole => dbRole.RoleId == id) ?? new AdminRole { RoleId = id };
    }).ToList();
  }
}