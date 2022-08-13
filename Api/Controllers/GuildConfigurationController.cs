using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager;

[ApiController]
[Route("[controller]")]
public class GuildConfigurationController : ControllerBase
{
  private readonly IGuildConfigurationRepository guildConfigurationRepository;
  private readonly IMapper mapper;

  public GuildConfigurationController(IGuildConfigurationRepository guildConfigurationRepository, IMapper mapper)
  {
    this.guildConfigurationRepository = guildConfigurationRepository ?? throw new ArgumentNullException(nameof(guildConfigurationRepository));
    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  }

  [HttpGet("{guildId}", Name = "GetGuildConfiguration")]
  [Authorize(Policy = "OwnerPolicy")]
  public ActionResult<GuildConfigurationDetailsDto> GetGuildConfiguration(string guildId)
  {
    var guildConfiguration = guildConfigurationRepository.Get(guildId);
    if (guildConfiguration == null)
    {
      return NotFound();
    }

    return Ok(mapper.Map<GuildConfigurationDetailsDto>(guildConfiguration));
  }

  [HttpPut("{guildId}")]
  [Authorize(Policy = "OwnerPolicy")]
  public ActionResult<GuildConfigurationDetailsDto> CreateOrUpdateGuildConfiguration(string guildId, [FromBody] GuildConfigurationUpdateDto updateDto)
  {
    var alreadyExisted = guildConfigurationRepository.GuildConfigurationDoesExist(guildId);
    var guildConfiguration = guildConfigurationRepository.CreateOrUpdate(guildId, updateDto);

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
  [Authorize(Policy = "OwnerPolicy")]
  public IActionResult DeleteGuildConfiguration(string guildId)
  {
    var configExists = guildConfigurationRepository.GuildConfigurationDoesExist(guildId);
    if (!configExists)
    {
      return NotFound();
    }

    guildConfigurationRepository.Delete(guildId);
    
    return NoContent();
  }
}