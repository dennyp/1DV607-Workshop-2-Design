using System;
using Model;

namespace View
{
  public class UserInterface
  {
    public void PresentMenu()
    {
      Console.WriteLine("Please choose one below.");
      Console.WriteLine("1. Register Member");
      Console.WriteLine("2. Delete Member");
      Console.WriteLine("3. Show a list of members");
      Console.WriteLine("Q to quit");
      Console.Write("Enter choice: ");
    }

    public void PresentMemberCreationUI() => Console.WriteLine("Please create a new member below.");

    public void PresentMemberNameUI() => Console.Write("Name: ");

    public void PresentMemberPersonalIdUI() => Console.Write("Personal id: ");

    public string CollectData() => Console.ReadLine();

    public void PresentDeleteMemberUI()
    {
      Console.WriteLine("Please enter id of member that should be deleted.");
      Console.Write("Member ID: ");
    }

    public void PresentMemberListUI() => Console.Write("Type C for a compact list or V for a verbose list of the members: ");

    public void PresentMemberString(Member member, string format) => Console.WriteLine(member.ToString(format));

    public void PresentErrorMessage(string message) => Console.WriteLine(message);
  }
}
