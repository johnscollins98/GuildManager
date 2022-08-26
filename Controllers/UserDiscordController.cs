using AutoMapper;
using GuildManager.Discord;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager;

[ApiController]
[Route("[controller]")]
public class UserDiscordController : ControllerBase
{
  private readonly IUserDiscordService userDiscordService;
  private readonly IDiscordService discordService;
  private readonly IMapper mapper;

  public UserDiscordController(IUserDiscordService userDiscordService, IDiscordService discordService, IMapper mapper)
  {
    this.userDiscordService = userDiscordService 
      ?? throw new ArgumentNullException(nameof(userDiscordService));
    this.discordService = discordService ?? throw new ArgumentNullException(nameof(discordService));
    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  [HttpGet("Guilds")]
  public async Task<ActionResult<IEnumerable<GuildDto>>> GetGuilds()
  {

    var guilds = (await userDiscordService.GetUserGuildsAsync())
      .Where(g => g.Owner); // TODO - this should be filtering to Admins not owners. Owner is fine for now.
    var botGuilds = await discordService.GetBotGuilds();

    var intersectingGuilds = guilds.Intersect(botGuilds);

    return Ok(mapper.Map<IEnumerable<GuildDto>>(intersectingGuilds));
  }

  [HttpGet("Guilds/{guildId}")]
  public async Task<ActionResult<GuildMemberDto>> GetUserAsGuildMember(string guildId)
  {
    var guildMember = await userDiscordService.GetUserAsGuildMemberAsync(guildId);
    return Ok(mapper.Map<GuildMemberDto>(guildMember));
  }
}
