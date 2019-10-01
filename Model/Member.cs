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
    public string ID { get; set; }

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
      ID = DateTime.Now.ToString("MMddmmssff");
      Name = name;
      SSN = ssn;
      Boats = new List<Boat>();
    }

    /// <summary>
    /// Creates a string of a member.
    /// </summary>
    /// <returns>A string representation of the member.</returns>
    public override string ToString()
    {
      // TODO : add numbers of boats to string
      return $"{ID}, {Name}";
    }

    /// <summary>
    /// Creates a string of a member by a certain format.
    /// </summary>
    /// <param name="format">The format to use for the string.</param>
    /// <returns>A string representation of the member.</returns>
    public string ToString(string format)
    {
      string lowerFormat = format.ToLower();

      if (lowerFormat == "c" || String.IsNullOrWhiteSpace(lowerFormat))
      {
        return ToString();
      }
      else if (lowerFormat == "v")
      {
        // TODO : add string with name, personal number, member id and boats with boat information
        return $"{ID}, {Name}, {SSN}";
      }
      else
      {
        throw new FormatException("Wrong format specified.");
      }
    }
  }
}
