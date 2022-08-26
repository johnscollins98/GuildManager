using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GuildManager;

public class OwnerRequirement : IAuthorizationRequirement { }

public class OwnerAuthorizationHandler : AuthorizationHandler<OwnerRequirement>
{
  private readonly IUserDiscordService userDiscordService;
  private readonly HttpContext httpContext;

  public OwnerAuthorizationHandler(IUserDiscordService userDiscordService, IHttpContextAccessor httpContextAccessor)
  {
    this.userDiscordService = userDiscordService ?? throw new ArgumentNullException(nameof(userDiscordService));
    this.httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
  }

  protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement)
  {
    var guildId = (httpContext.GetRouteValue("guildId") ?? throw new MissingGuildIdException()).ToString();
    if (String.IsNullOrEmpty(guildId))
    {
      throw new MissingGuildIdException();
    }

    try
    {
      var userGuilds = await userDiscordService.GetUserGuildsAsync();
      var isOwner = userGuilds.Any(userGuild =>
      {
        return userGuild.Id == guildId.ToString() && userGuild.Owner;
      });

      if (isOwner)
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