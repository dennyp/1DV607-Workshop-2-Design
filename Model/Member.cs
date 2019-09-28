using System;

namespace Model
{
  public class Member
  {
    private string ID;
    private string Name { get; set; }

    // TODO : ssn could be validated with a regex
    private string SSN { get; set; }

    public Member(string name, string ssn)
    {
      ID = DateTime.Now.ToString("MMddmmssff");
      Name = name;
      SSN = ssn;
    }
  }
}
