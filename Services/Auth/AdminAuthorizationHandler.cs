using Microsoft.AspNetCore.Authorization;

namespace GuildManager;

public class AdminRequirement : IAuthorizationRequirement { }

public class AdminAuthorizationHandler : AuthorizationHandler<AdminRequirement>
{
  private readonly HttpContext httpContext;
  private readonly IDiscordService discordService;
  private readonly IGuildConfigurationRepository guildConfigurationRepository;

  public AdminAuthorizationHandler(IDiscordService discordService, IHttpContextAccessor httpContextAccessor, IGuildConfigurationRepository guildConfigurationRepository)
  {
    this.httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    this.discordService = discordService ?? throw new ArgumentNullException(nameof(discordService));
    this.guildConfigurationRepository = guildConfigurationRepository ?? throw new ArgumentNullException(nameof(guildConfigurationRepository));
  }

  protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
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
      return;
    };

    var guildConfig = guildConfigurationRepository.Get(guildId);
    if (guildConfig == null)
    {
      context.Fail(new AuthorizationFailureReason(this, "No guild config present"));
      return;
    }

    var guildMember = await discordService.GetGuildMemberAsync(guildId, userId);
    if (guildMember == null)
    {
      context.Fail(new AuthorizationFailureReason(this, "User is not in guild"));
      return;
    }
    
    var isAdmin = guildConfig.AdminRoles.Any(adminRole => 
    {
      return guildMember.Roles.Contains(adminRole.RoleId);
    });

    if (isAdmin)
    {
      context.Succeed(requirement);
    }
  }
}