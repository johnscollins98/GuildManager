using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace GuildManager;

public static class GuildManagerServicesExtension
{
  public static void AddGuildManagerServices(this IServiceCollection services, ConfigurationManager config)
  {
    services.AddHttpClient<IUserDiscordService, UserDiscordService>();
    services.AddHttpClient<IDiscordService, DiscordService>(o =>
    {
      var botToken = config["Discord:BotToken"];
      o.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", botToken);
      o.BaseAddress = new Uri("https://discord.com/api/");
    });

    services.AddTransient<IAuthorizationHandler, OwnerAuthorizationHandler>();
  }
}