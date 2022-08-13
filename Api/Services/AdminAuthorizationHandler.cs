using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GuildManager;

public class AdminRequirement : IAuthorizationRequirement { }

public class AdminAuthorizationHandler : AuthorizationHandler<AdminRequirement>
{
  private readonly IUserDiscordService userDiscordService;
  private readonly HttpContext httpContext;

  public AdminAuthorizationHandler(IUserDiscordService userDiscordService, IHttpContextAccessor httpContextAccessor)
  {
    this.userDiscordService = userDiscordService ?? throw new ArgumentNullException(nameof(userDiscordService));
    this.httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
  }

  protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
  {
    var guildId = (httpContext.GetRouteValue("guildId") ?? throw new MissingGuildIdException()).ToString();
    if (String.IsNullOrEmpty(guildId))
    {
      throw new MissingGuildIdException();
    }

    try
    {
      var userGuilds = await userDiscordService.GetUserGuildsAsync();
      var isAdmin = userGuilds.Any(userGuild =>
      {
        return userGuild.Id == guildId.ToString() && userGuild.Owner;
      });

      if (isAdmin)
      {
        context.Succeed(requirement);
      };
    }
    catch (MissingAccessTokenException)
    {
      context.Fail(new AuthorizationFailureReason(this, "Missing access token"));
    }
  }
}