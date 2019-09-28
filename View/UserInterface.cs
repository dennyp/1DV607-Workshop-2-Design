using System;

namespace View
{
  public class UserInterface
  {
    public void PresentMemberCreationUI() => Console.WriteLine("Please create a new member below.");

    public void PresentMemberNameUI() => Console.Write("Name: ");

    public void PresentMemberPersonalIdUI() => Console.Write("Personal id: ");

    public string CollectData() => Console.ReadLine();
  }
}
