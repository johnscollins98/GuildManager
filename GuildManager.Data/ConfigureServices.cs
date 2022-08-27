using System.Net.Http.Headers;
using GuildManager.Discord;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager;

public static class ConfigureServices
{
  public static void ConfigureDataServices(this IServiceCollection services, ConfigurationManager config)
  {
    services.AddHttpClient<IUserApi, UserApi>(o =>
    {
      var botToken = config["Discord:BotToken"];
      o.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", botToken);
      o.BaseAddress = new Uri("https://discord.com/api/users/@me/");
    });

    services.AddHttpClient<IGuildApi, GuildApi>(o => 
    {
      var botToken = config["Discord:BotToken"];
      o.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", botToken);
      o.BaseAddress = new Uri("https://discord.com/api/guilds/");
    });

    services.AddDbContext<GuildManagerDbContext>();
    services.AddScoped<IGuildConfigurationRepository, GuildConfigurationDbRepository>();
  }
}