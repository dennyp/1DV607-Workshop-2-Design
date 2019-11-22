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
      Console.WriteLine("Q to quit");
      Console.Write("Enter choice: ");
    }

    public string CollectData() => Console.ReadLine();

    public Member UpdateMemberUI()
    {
      Console.WriteLine("Change the following member.");

      int memberId = GetMemberIdUI();

      Console.Write("Modify name: ");
      string name = Console.ReadLine();

      Console.Write("Modify SSN: ");
      string ssn = Console.ReadLine();

      return new Member(name, ssn, memberId);
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
      PrintBoats(member.Boats);
    }

    private void PrintBoats(List<Boat> boats)
    {
      int i = 0;
      foreach (var boat in boats)
      {
        Console.WriteLine($"Index: {i}, Type: {boat.Type}, Length: {boat.Length}");
        i++;
      }
    }

    public void PresentErrorMessage(string message)
    {
      Console.WriteLine();
      Console.WriteLine("-----------------------");
      Console.WriteLine(message);
      Console.WriteLine("-----------------------");
      Console.WriteLine();
    }

    public Boat SelectBoatUI(List<Boat> boats)
    {
      if (boats.Count == 0)
      {
        return null;
      }

      Console.WriteLine();

      PrintBoats(boats);

      Console.Write("Select index: ");
      int index = int.Parse(Console.ReadLine());
      Console.WriteLine();

      return boats[index];
    }

    public Boat EnterBoatUI()
    {
      Console.WriteLine();
      Console.WriteLine("Enter boat values.");
      string type = GetBoatTypeUI();
      string length = GetLengthUI();
      Console.WriteLine();

      BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), type);
      return new Boat(boatType, double.Parse(length));
    }

    private string GetBoatTypeUI()
    {
      Console.Write("Boat type (Sailboat, Motorsailer, Kayakcanoe, Other): ");
      return Console.ReadLine().ToLower();
    }

    private string GetLengthUI()
    {
      Console.Write("Length: ");
      return Console.ReadLine();
    }
  }
}
