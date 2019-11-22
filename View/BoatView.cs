using System;
using System.Collections.Generic;
using Model;

namespace View
{
  public class BoatView
  {
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

    public void PrintBoats(List<Boat> boats)
    {
      int i = 0;
      foreach (var boat in boats)
      {
        Console.WriteLine($"Index: {i}, Type: {boat.Type}, Length: {boat.Length}");
        i++;
      }
    }

    public Boat EnterBoatUI()
    {
      Console.WriteLine();
      Console.WriteLine("Enter boat values.");
      string type = GetBoatTypeUI();
      string length = GetBoatLengthUI();
      Console.WriteLine();

      BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), type);
      return new Boat(boatType, double.Parse(length));
    }

    private string GetBoatTypeUI()
    {
      Console.Write("Boat type (Sailboat, Motorsailer, Kayakcanoe, Other): ");
      return Console.ReadLine().ToLower();
    }

    private string GetBoatLengthUI()
    {
      Console.Write("Length: ");
      return Console.ReadLine();
    }
  }
}
