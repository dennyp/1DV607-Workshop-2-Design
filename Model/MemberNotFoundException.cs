using System;

namespace Model
{
  public class MemberNotFoundException : Exception
  {
    public MemberNotFoundException()
    {
    }

    public MemberNotFoundException(string message) : base(message)
    {
    }
  }
}
