using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace View
{
  public class MemberView
  {
    private BoatView boatView = new BoatView();
    private const string compactListChar = "c";
    private const string verboseListChar = "v";

    private string GetCompactListChar() => compactListChar;

    private string GetVerboseListChar() => verboseListChar;

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
      Console.WriteLine("9. Quit");
      Console.Write("Enter choice: ");
    }

    public MenuChoice SelectChoice()
    {
      string choice = Console.ReadLine();
      return (MenuChoice)Enum.Parse(typeof(MenuChoice), choice);
    }

    public Member UpdateMemberUI()
    {
      Console.WriteLine("-----------------------");
      Console.WriteLine("Change the following member.");

      int memberId = GetMemberIdUI();

      string name = GetName();
      string ssn = GetSSN();

      return new Member(name, ssn, memberId);
    }

    public Member RegisterMemberUI()
    {
      Console.WriteLine("-----------------------");
      Console.WriteLine("Please create a new member below.");

      string name = GetName();
      string ssn = GetSSN();

      return new Member(name, ssn);
    }

    private string GetName()
    {
      Console.Write("Name: ");
      string name = Console.ReadLine();
      return name;
    }

    private string GetSSN()
    {
      Console.Write("Personal id: ");
      string ssn = Console.ReadLine();
      return ssn;
    }

    private int GetMemberIdUI()
    {
      Console.Write("Enter member ID: ");
      return int.Parse(Console.ReadLine());
    }

    public Member SelectMemberUI(FileHandler fileHandler)
    {
      Console.Write("Enter member ID: ");
      int memberId = int.Parse(Console.ReadLine());

      return fileHandler.GetMember(memberId);
    }

    public void ShowMemberListUI(List<Member> members)
    {
      string format = GetFormatForList();

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

    private string GetFormatForList()
    {
      Console.Write($"Type {compactListChar} for a compact list or {verboseListChar} for a verbose list of the members: ");
      string format = Console.ReadLine();
      return format;
    }

    public void ShowMemberUI(List<Member> members)
    {
      int memberId = GetMemberIdUI();
      Member member = members.SingleOrDefault(m => m.Id == memberId);

      PresentVerboseMemberString(member);
    }

    private void PresentMemberString(Member member)
    {
      Console.WriteLine("-----------------------");
      Console.WriteLine($"Name: {member.Name}");
      Console.WriteLine($"Member id: {member.Id}");
      Console.WriteLine($"Number of boats: {member.NumberOfBoats}");
    }

    private void PresentVerboseMemberString(Member member)
    {
      Console.WriteLine("-----------------------");
      Console.WriteLine($"Name: {member.Name}");
      Console.WriteLine($"SSN: {member.SSN}");
      Console.WriteLine($"Member id: {member.Id}");
      Console.WriteLine("Boats: ");
      boatView.PrintBoats(member.Boats);
    }

    public void PresentErrorMessage(string message)
    {
      Console.WriteLine();
      Console.WriteLine("-----------------------");
      Console.WriteLine(message);
      Console.WriteLine("-----------------------");
      Console.WriteLine();
    }
  }
}
