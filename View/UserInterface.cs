using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace View
{
  public class UserInterface
  {
    private const string compactListChar = "c";
    private const string verboseListChar = "v";

    public string GetCompactListChar() => compactListChar;

    public string GetVerboseListChar() => verboseListChar;

    public void PresentMenu()
    {
      Console.WriteLine("-----------------------");
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

    public string CollectData() => Console.ReadLine();

    public void PresentBoatUI()
    {
      Console.WriteLine("Please enter ID of the boat.");
      Console.Write("Boat ID: ");
    }

    public void PresentBoatCreationUI() => Console.WriteLine("Create a new boat for a member. (Sailboat, Motorsailer, Kayakcanoe, Other)");

    public void PresentBoatTypeUI() => Console.Write("Type: ");

    public void PresentBoatLengthUI() => Console.Write("Length: ");

    public void PresentMemberInfoUI() => Console.WriteLine("Change the following member.");

    public int DeleteMemberUI()
    {
      Console.WriteLine("Please enter id of member to delete.");

      Console.Write("Member ID: ");
      string memberId = Console.ReadLine();

      return int.Parse(memberId);
    }

    public Member RegisterMemberUI()
    {
      Console.WriteLine("Please create a new member below.");

      Console.Write("Name: ");
      string name = Console.ReadLine();

      Console.Write("Personal id: ");
      string ssn = Console.ReadLine();

      return new Member(name, ssn);
    }

    public void ShowMemberListUI(List<Member> members)
    {
      Console.Write($"Type {compactListChar} for a compact list or {verboseListChar} for a verbose list of the members: ");
      string format = Console.ReadLine();

      foreach (var member in members)
      {
        if (format == GetCompactListChar())
        {
          PresentMemberString(member);
        }
        else if (format == GetVerboseListChar())
        {
          PresentVerboseMemberString(member);
        }
      }
    }

    public void ShowMemberUI(List<Member> members)
    {
      Console.Write("Enter member ID: ");
      string memberId = Console.ReadLine();
      Member member = members.SingleOrDefault(m => m.Id == int.Parse(memberId));

      PresentVerboseMemberString(member);
    }

    public void PresentMemberString(Member member)
    {
      Console.WriteLine("-----------------------");
      Console.WriteLine($"Name: {member.Name}");
      Console.WriteLine($"Member id: {member.Id}");
      Console.WriteLine($"Number of boats: {member.NumberOfBoats}");
    }

    public void PresentVerboseMemberString(Member member)
    {
      Console.WriteLine("-----------------------");
      Console.WriteLine($"Name: {member.Name}");
      Console.WriteLine($"SSN: {member.SSN}");
      Console.WriteLine($"Member id: {member.Id}");
      // TODO Boats with boat information
    }

    public void PresentErrorMessage(string message) => Console.WriteLine(message);
  }
}
