using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GuildManager;

public static class GuildManagerAuthExtension
{
  public static void AddGuildManagerAuth(this IServiceCollection services, ConfigurationManager config)
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
        o.SaveTokens = true;
        o.Scope.Add("guilds");
        o.Scope.Add("guilds.members.read");
      });

    services.AddAuthorization(options =>
    {
      options.AddPolicy("OwnerPolicy",
        policy =>
        {
          policy.RequireAuthenticatedUser();
          policy.Requirements.Add(new OwnerRequirement());
        });
    });
  }
}