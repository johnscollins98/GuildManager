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
  public IActionResult Logout()
  {
    return SignOut(new AuthenticationProperties { RedirectUri = "/" },
      CookieAuthenticationDefaults.AuthenticationScheme);
  }
}