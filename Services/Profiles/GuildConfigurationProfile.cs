using AutoMapper;

namespace GuildManager;

public class GuildConfigurationProfile : Profile
{
  public GuildConfigurationProfile()
  {
    CreateMap<GuildConfiguration, GuildConfigurationDetailsDto>()
      .ForMember(dest => dest.AdminRoleIds, opt =>
      {
        opt.MapFrom(src => src.AdminRoles.Select(role => role.RoleId));
      });

    CreateMap<GuildConfigurationUpdateDto, GuildConfiguration>()
      .ForMember(dest => dest.AdminRoles, map => map.MapFrom<AdminRoleResolver>());
  }
}