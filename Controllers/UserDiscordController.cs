using AutoMapper;
using GuildManager.Discord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserDiscordController : ControllerBase
{
  private readonly IDiscordService discordService;
  private readonly IMapper mapper;

  public UserDiscordController(IDiscordService discordService, IMapper mapper)
  {
    this.discordService = discordService ?? throw new ArgumentNullException(nameof(discordService));
    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  [HttpGet("Guilds")]
  public async Task<ActionResult<IEnumerable<GuildDto>>> GetGuilds()
  {
    var userId = User.GetUserId();
    if (userId == null)
    {
      return Unauthorized();
    }

    var guilds = (await discordService.GetBotGuildsWithUserAsync(userId));

    return Ok(mapper.Map<IEnumerable<GuildDto>>(guilds));
  }
}
