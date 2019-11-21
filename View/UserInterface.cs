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

    public int GetMemberIdUI()
    {
      Console.Write("Enter member ID: ");
      return int.Parse(Console.ReadLine());
    }

    public Member GetMemberUI(FileHandler fileHandler)
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
      // TODO Boats with boat information
    }

    public void PresentErrorMessage(string message)
    {
      Console.WriteLine();
      Console.WriteLine("-----------------------");
      Console.WriteLine(message);
      Console.WriteLine("-----------------------");
      Console.WriteLine();
    }

    public Boat DeleteBoatUI(List<Boat> boats)
    {
      if (boats.Count == 0)
      {
        return null;
      }
      Console.WriteLine();
      Console.WriteLine("Delete a boat belonging to a member.");

      int i = 0;
      foreach (var boat in boats)
      {
        Console.WriteLine($"Index: {i}, Type: {boat.Type}, Length: {boat.Length}");
        i++;
      }

      Console.Write("Enter index to delete: ");
      int index = int.Parse(Console.ReadLine());
      Console.WriteLine();

      return boats[index];
    }

    private void PrintBoat(Boat boat)
    {
      Console.WriteLine($"Type: {boat.Type}");
      Console.WriteLine($"Length: {boat.Length}");
    }

    public Boat RegisterBoatUI()
    {
      Console.WriteLine();
      Console.WriteLine("Create a new boat for a member.");

      Console.Write("Boat type (Sailboat, Motorsailer, Kayakcanoe, Other): ");
      string type = Console.ReadLine().ToLower();

      Console.Write("Length: ");
      string length = Console.ReadLine();
      Console.WriteLine();

      BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), type);
      return new Boat(boatType, double.Parse(length));
    }
  }
}
