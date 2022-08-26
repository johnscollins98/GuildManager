using GuildManager.Discord;

namespace GuildManager;

public static class AutoMapperExtension
{
  public static void AddGuildManagerMappings(this IServiceCollection services)
  {
    services.AddAutoMapper(o =>
    {
      o.CreateMap<Guild, GuildDto>();
      o.CreateMap<GuildMember, GuildMemberDto>();
      o.CreateMap<Discord.User, Discord.UserDto>();
      o.CreateMap<Discord.Role, Discord.RoleListDto>();
    });

    services.AddAutoMapper(typeof(GuildConfigurationProfile).Assembly);
  }
}