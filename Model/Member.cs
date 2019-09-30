using System;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
  public class Member
  {
    public string ID { get; set; }
    public string Name { get; set; }

    // TODO : ssn should be validated
    public string SSN { get; set; }

    public Member(string name, string ssn)
    {
      ID = DateTime.Now.ToString("MMddmmssff");
      Name = name;
      SSN = ssn;
    }

    public override string ToString()
    {
      return $"{ID}, {Name}, {SSN}";
    }
  }
}
