using System.Runtime.Serialization;

namespace GuildManager;

public class MissingAccessTokenException : Exception
{
  public MissingAccessTokenException()
  {
  }

  public MissingAccessTokenException(string? message) : base(message)
  {
  }

  public MissingAccessTokenException(string? message, Exception? innerException) : base(message, innerException)
  {
  }

  protected MissingAccessTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
  {
  }
}