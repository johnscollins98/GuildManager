namespace GuildManager.Discord;

public class Guild
{
  public string Id { get; set; } = String.Empty;
  public string Name { get; set; } = String.Empty;
  public string Icon { get; set; } = String.Empty;
  public bool Owner { get; set; }

  public bool Equals(Guild? other)
  {
    if (other == null)
    {
      return false;
    }
    return other.Id == this.Id;
  }

  public override bool Equals(object? obj) => Equals(obj as Guild);
  public override int GetHashCode() => (Id).GetHashCode();
}