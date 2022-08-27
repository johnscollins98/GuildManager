using System.Runtime.Serialization;

namespace GuildManager;

public class MissingGuildIdException : Exception
{
  public MissingGuildIdException()
  {
  }

  public MissingGuildIdException(string? message) : base(message)
  {
  }

  public MissingGuildIdException(string? message, Exception? innerException) : base(message, innerException)
  {
  }

  protected MissingGuildIdException(SerializationInfo info, StreamingContext context) : base(info, context)
  {
  }
}