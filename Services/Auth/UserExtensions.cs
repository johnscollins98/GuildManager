using System.Security.Claims;

namespace GuildManager;

public static class UserExtensions
{
  public static string? GetUserId(this ClaimsPrincipal? user)
  {
    return user.GetClaim(ClaimTypes.NameIdentifier);
  }

  public static string? GetName(this ClaimsPrincipal? user)
  {
    return user.GetClaim(ClaimTypes.Name);
  }

  private static string? GetClaim(this ClaimsPrincipal? user, string type)
  {
    if (user == null)
    {
      return null;
    }
    var claim = user.Claims.FirstOrDefault(c => c.Type == type);
    if (claim == null)
    {
      return null;
    }

    return claim.Value;
  }
}