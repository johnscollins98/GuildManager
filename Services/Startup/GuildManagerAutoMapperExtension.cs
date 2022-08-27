using GuildManager.Discord;

namespace GuildManager;

public static class AutoMapperExtension
{
  public static void AddGuildManagerMappings(this IServiceCollection services)
  {
    services.AddAutoMapper(o =>
    {
      o.CreateMap<PartialGuild, GuildDto>();
      o.CreateMap<GuildMember, GuildMemberDto>();
      o.CreateMap<Discord.User, Discord.UserDto>();
      o.CreateMap<Discord.Role, Discord.RoleListDto>();
      o.CreateMap<Discord.Guild, GuildDto>();
    });

    services.AddAutoMapper(typeof(GuildConfigurationProfile).Assembly);
  }
}