using AutoMapper;
using GuildManager.Discord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager;

[ApiController]
[Route("[controller]")]
public class DiscordController : ControllerBase
{
  private readonly IDiscordService discordService;
  private readonly IMapper mapper;

  public DiscordController(IDiscordService discordService, IMapper mapper)
  {
    this.discordService = discordService ?? throw new ArgumentNullException(nameof(discordService));
    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  [Authorize(Policy = "AdminPolicy")]
  [HttpGet("Guilds/{guildId}/Members")]
  public async Task<ActionResult<IEnumerable<GuildMemberDto>>> GetGuilds(string guildId)
  {
    var members = await discordService.GetGuildMembersAsync(guildId);
    if (members == null)
    {
      return NotFound();
    }

    return Ok(mapper.Map<IEnumerable<GuildMemberDto>>(members));
  }
}
