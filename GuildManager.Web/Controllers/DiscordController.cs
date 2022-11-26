using AutoMapper;
using GuildManager.Discord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager;

[ApiController]
[Authorize(Policy = "AdminPolicy")]
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

  [HttpGet("Guilds/{guildId}/Members")]
  public async Task<ActionResult<IEnumerable<GuildMemberDto>>> GetGuildMembers(string guildId)
  {
    var members = await discordService.GetGuildMembersAsync(guildId);
    if (members == null)
    {
      return NotFound();
    }

    return Ok(mapper.Map<IEnumerable<GuildMemberDto>>(members));
  }

  [HttpGet("Guilds/{guildId}/Roles")]
  public async Task<ActionResult<IEnumerable<RoleListDto>>> GetRoleList(string guildId)
  {
    var roles = await discordService.GetGuildRolesAsync(guildId);
    if (roles == null)
    {
      return NotFound();
    }
    
    var roleDtos = mapper.Map<IEnumerable<RoleListDto>>(roles);
    return Ok(roles);
  }

  [HttpGet("Guilds/{guildId}")]
  public async Task<ActionResult<GuildDto>> GetGuildDetails(string guildId)
  {
    var guild = await discordService.GetGuildDetailsAsync(guildId);
    if (guild == null)
    {
      return NotFound();
    }
    var guildDto = mapper.Map<GuildDto>(guild);
    return Ok(guildDto);
  }
}
