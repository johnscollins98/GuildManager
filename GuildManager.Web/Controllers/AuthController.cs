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
  public ActionResult<AuthUserDto> GetCurrentUserInfo()
  {
    var id = User.GetUserId();
    var name = User.GetName();

    if (id == null || name == null)
    {
      return Unauthorized();
    }

    return Ok(new AuthUserDto
    {
      Id = id,
      Name = name
    });
  }
}