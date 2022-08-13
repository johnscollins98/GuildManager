using GuildManager.Discord;

namespace GuildManager;

public static class AutoMapperExtension
{
  public static void AddMappings(this IServiceCollection services)
  {
    services.AddAutoMapper(o =>
    {
      o.CreateMap<Guild, GuildDto>();
      o.CreateMap<GuildMember, GuildMemberDto>();
      o.CreateMap<Discord.User, UserDto>();
    });
  }
}