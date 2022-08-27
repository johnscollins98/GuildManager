using AspNet.Security.OAuth.Discord;
using GuildManager.Discord;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace GuildManager;

public static class ConfigureServices
{
  public static void ConfigureWebServices(this IServiceCollection services, ConfigurationManager config)
  {
    services
    .AddAuthentication(o =>
    {
      o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      o.DefaultAuthenticateScheme = DiscordAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(o =>
    {
      o.Events.OnRedirectToLogin = context =>
      {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
      };

      o.Events.OnRedirectToAccessDenied = context =>
      {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
      };
    })
    .AddDiscord(o =>
    {
      o.ClientId = config["Discord:ClientId"];
      o.ClientSecret = config["Discord:ClientSecret"];
      o.Scope.Add("guilds");
      o.Scope.Add("guilds.members.read");
    });

    services.AddAuthorization(options =>
    {
      options.AddPolicy("AdminPolicy",
        policy =>
        {
          policy.RequireAuthenticatedUser();
          policy.Requirements.Add(new AdminRequirement());
        });

      options.AddPolicy("OwnerPolicy",
        policy =>
        {
          policy.RequireAuthenticatedUser();
          policy.Requirements.Add(new OwnerRequirement());
        });
    });

    services.AddTransient<IAuthorizationHandler, OwnerAuthorizationHandler>();
    services.AddTransient<IAuthorizationHandler, AdminAuthorizationHandler>();

    services.AddScoped<AdminRoleResolver>();
    services.AddAutoMapper(o =>
      {
        o.CreateMap<PartialGuild, GuildDto>();
        o.CreateMap<GuildMember, GuildMemberDto>();
        o.CreateMap<User, UserDto>();
        o.CreateMap<Role, RoleListDto>();
        o.CreateMap<Guild, GuildDto>();
      });

    services.AddAutoMapper(typeof(GuildConfigurationProfile).Assembly);
  }
}