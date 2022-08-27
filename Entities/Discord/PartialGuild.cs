namespace GuildManager.Discord;

public class PartialGuild
{
  public string Id { get; set; } = String.Empty;
  public string Name { get; set; } = String.Empty;
  public string Icon { get; set; } = String.Empty;

  public bool Equals(PartialGuild? other)
  {
    if (other == null)
    {
      return false;
    }
    return other.Id == this.Id;
  }

  public override bool Equals(object? obj) => Equals(obj as PartialGuild);
  public override int GetHashCode() => (Id).GetHashCode();
}