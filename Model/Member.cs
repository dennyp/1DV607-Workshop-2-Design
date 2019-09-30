using System;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
  public class Member
  {
    private string ID;
    private string Name { get; set; }

    // TODO : ssn should be validated
    private string SSN { get; set; }

    public Member(string name, string ssn)
    {
      ID = DateTime.Now.ToString("MMddmmssff");
      Name = name;
      SSN = ssn;
    }

    public void SaveToFile()
    {
      // TODO : Should perhaps read/write to file in separate class.
      // TODO : Append to file instead of overwriting.
      using (StreamWriter file = File.CreateText(@"./members.json"))
      {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, new { ID, Name, SSN });
      }
    }

    public override string ToString()
    {
      return $"{ID}, {Name}, {SSN}";
    }
  }
}
