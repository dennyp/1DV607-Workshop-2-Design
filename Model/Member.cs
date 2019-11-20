using System;
using System.Collections.Generic;

namespace Model
{
  /// <summary>
  /// Represents a member.
  /// </summary>
  public class Member
  {
    /// <summary>
    /// ID of the member.
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// Name of the member.
    /// </summary>
    /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// SSN of the member.
    /// </summary>
    /// <value></value>
    public string SSN { get; set; }
    // TODO : ssn should be validated

    /// <summary>
    /// List of the boats belonging to the member.
    /// </summary>
    /// <value></value>
    public List<Boat> Boats { get; set; }

    /// <summary>
    /// Creates a member. ID is created by using current time.
    /// </summary>
    /// <param name="name">Name of the member.</param>
    /// <param name="ssn">SSN of the member.</param>
    public Member(string name, string ssn)
    {
      FileHandler fileHandler = new FileHandler();
      // Id = fileHandler.GetNextMemberId();
      Name = name;
      SSN = ssn;
      Boats = new List<Boat>();
    }
  }
}
