using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager;

public static class ConfigureServices
{
  public static void ConfigureCoreServices(this IServiceCollection services, ConfigurationManager config)
  {
    services.AddScoped<IGuildConfigurationService, GuildConfigurationService>();
    services.AddTransient<IDiscordService, DiscordService>();
  }
}