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
      Console.WriteLine("4. Specific member information");
      Console.WriteLine("5. Change member information");
      Console.WriteLine("6. Register boat");
      Console.WriteLine("7. Delete boat");
      Console.WriteLine("8. Change boat information");
      Console.WriteLine("Q to quit");
      Console.Write("Enter choice: ");
    }

    public void PresentMemberCreationUI() => Console.WriteLine("Please create a new member below.");

    public void PresentMemberNameUI() => Console.Write("Name: ");

    public void PresentMemberPersonalIdUI() => Console.Write("Personal id: ");

    public string CollectData() => Console.ReadLine();

    public void PresentMemberUI()
    {
      Console.WriteLine("Please enter id of member.");
      Console.Write("Member ID: ");
    }

    public void PresentBoatUI()
    {
      Console.WriteLine("Please enter ID of the boat.");
      Console.Write("Boat ID: ");
    }

    public void PresentBoatCreationUI() => Console.WriteLine("Create a new boat for a member. (Sailboat, Motorsailer, Kayakcanoe, Other)");

    public void PresentBoatTypeUI() => Console.Write("Type: ");

    public void PresentBoatLengthUI() => Console.Write("Length: ");

    public void PresentMemberInfoUI() => Console.WriteLine("Change the following member.");

    public void PresentMemberListUI() => Console.Write("Type C for a compact list or V for a verbose list of the members: ");

    public void PresentMemberString(Member member)
    {
      Console.WriteLine($"Name: {member.Name}");
      Console.WriteLine($"Member id: {member.ID}");
      // TODO Console.WriteLine($"Number of boats: {member.NumberOfBoats}");
    }

    public void PresentVerboseMemberString(Member member)
    {
      Console.WriteLine($"Name: {member.Name}");
      Console.WriteLine($"SSN: {member.SSN}");
      Console.WriteLine($"Member id: {member.ID}");
      // TODO Boats with boat information
    }

    public void PresentErrorMessage(string message) => Console.WriteLine(message);

    public void PresentMemberInformation() => Console.Write("Enter member ID: ");
  }
}
