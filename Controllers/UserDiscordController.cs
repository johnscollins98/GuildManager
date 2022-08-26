using AutoMapper;
using GuildManager.Discord;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager;

[ApiController]
[Route("[controller]")]
public class UserDiscordController : ControllerBase
{
  private readonly IUserDiscordService discordHttpService;
  private readonly IMapper mapper;

  public UserDiscordController(IUserDiscordService userDiscordService, IMapper mapper)
  {
    this.discordHttpService = userDiscordService 
      ?? throw new ArgumentNullException(nameof(userDiscordService));
    
    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  [HttpGet("Guilds")]
  public async Task<ActionResult<IEnumerable<GuildDto>>> GetGuilds()
  {

    var guilds = await discordHttpService.GetUserGuildsAsync();
    return Ok(mapper.Map<IEnumerable<GuildDto>>(guilds));
  }

  [HttpGet("Guilds/{guildId}")]
  public async Task<ActionResult<GuildMemberDto>> GetUserAsGuildMember(string guildId)
  {
    var guildMember = await discordHttpService.GetUserAsGuildMemberAsync(guildId);
    return Ok(mapper.Map<GuildMemberDto>(guildMember));
  }
}
