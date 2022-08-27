using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager;

[ApiController]
[Authorize(Policy = "OwnerPolicy")]
[Route("[controller]")]
public class GuildConfigurationController : ControllerBase
{
  private readonly IGuildConfigurationService guildConfigurationService;
  private readonly IMapper mapper;

  public GuildConfigurationController(IGuildConfigurationService guildConfigurationService, IMapper mapper)
  {
    this.guildConfigurationService = guildConfigurationService ?? throw new ArgumentNullException(nameof(guildConfigurationService));
    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  [HttpGet("{guildId}", Name = "GetGuildConfiguration")]
  public ActionResult<GuildConfigurationDetailsDto> GetGuildConfiguration(string guildId)
  {
    var guildConfiguration = guildConfigurationService.GetGuildConfiguration(guildId);
    if (guildConfiguration == null)
    {
      return NotFound();
    }

    return Ok(mapper.Map<GuildConfigurationDetailsDto>(guildConfiguration));
  }

  [HttpPut("{guildId}")]
  public ActionResult<GuildConfigurationDetailsDto> CreateOrUpdateGuildConfiguration(string guildId, [FromBody] GuildConfigurationUpdateDto updateDto)
  {
    var alreadyExisted = guildConfigurationService.DoesGuildConfigurationExist(guildId);
    var guildConfigEntity = mapper.Map<GuildConfiguration>(updateDto);
    var guildConfiguration = guildConfigurationService.CreateOrUpdateGuildConfiguration(guildId, guildConfigEntity);
    var detailsDto = mapper.Map<GuildConfigurationDetailsDto>(guildConfiguration);

    if (alreadyExisted) 
    {
      return Ok(detailsDto);
    }
    else
    {
      return CreatedAtRoute("GetGuildConfiguration", new { guildId = guildId }, detailsDto);
    }
  }

  [HttpDelete("{guildId}")]
  public IActionResult DeleteGuildConfiguration(string guildId)
  {
    var result = guildConfigurationService.DeleteGuildConfiguration(guildId);
    return result ? NoContent() : NotFound();
  }
}