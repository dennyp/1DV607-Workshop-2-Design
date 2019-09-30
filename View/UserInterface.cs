using System;

namespace View
{
  public class UserInterface
  {
    public void PresentMenu()
    {
      Console.WriteLine("Please choose one below.");
      Console.WriteLine("1. Register Member");
      Console.WriteLine("2. Delete Member");
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
  }
}
