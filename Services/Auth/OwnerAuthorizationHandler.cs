using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GuildManager;

public class OwnerRequirement : IAuthorizationRequirement { }

public class OwnerAuthorizationHandler : AuthorizationHandler<OwnerRequirement>
{
  private readonly HttpContext httpContext;
  private readonly IDiscordService discordService;

  public OwnerAuthorizationHandler(IDiscordService discordService, IHttpContextAccessor httpContextAccessor)
  {
    this.httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    this.discordService = discordService ?? throw new ArgumentNullException(nameof(discordService));
  }

  protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement)
  {
    var guildId = (httpContext.GetRouteValue("guildId") ?? throw new MissingGuildIdException()).ToString();
    if (String.IsNullOrEmpty(guildId))
    {
      throw new MissingGuildIdException();
    }

    var userId = httpContext.User.GetUserId();
    if (userId == null)
    {
      context.Fail(new AuthorizationFailureReason(this, "No user ID"));
      return;
    }

    var isOwner = await discordService.IsUserGuildOwnerAsync(guildId, userId);

    if (isOwner)
    {
      context.Succeed(requirement);
    };
  }
}