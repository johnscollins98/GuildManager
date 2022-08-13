namespace GuildManager;

public static class AutoMapperExtension
{
  public static void AddMappings(this IServiceCollection services)
  {
    services.AddAutoMapper(o =>
    {
      o.CreateMap<DiscordGuild, DiscordGuildDto>();
      o.CreateMap<DiscordGuildMember, DiscordGuildMemberDto>();
      o.CreateMap<DiscordUser, DiscordUserDto>();
    });
  }
}