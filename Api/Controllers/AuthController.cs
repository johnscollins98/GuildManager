using System.Security.Claims;
using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class AuthController : ControllerBase
{
  [HttpGet("Login")]
  public IActionResult Login()
  {
    return Challenge(new AuthenticationProperties { RedirectUri = "/" },
      DiscordAuthenticationDefaults.AuthenticationScheme);
  }

  [HttpGet("Logout")]
  public async Task<IActionResult> Logout()
  {
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Redirect("/");
  }

  [HttpGet]
  [Authorize]
  public ActionResult<UserDto> GetCurrentUserInfo()
  {
    if (User == null)
    {
      return Unauthorized();
    }

    var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
    var name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

    if (id == null || name == null)
    {
      return Unauthorized();
    }

    return Ok(new UserDto
    {
      Id = id.Value,
      Name = name.Value
    });
  }
}