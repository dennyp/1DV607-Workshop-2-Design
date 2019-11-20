using System.Collections.Generic;
using Newtonsoft.Json;

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
    public int Id { get; private set; }

    /// <summary>
    /// Name of the member.
    /// </summary>
    /// <value></value>
    public string Name { get; private set; }

    /// <summary>
    /// SSN of the member.
    /// </summary>
    /// <value></value>
    public string SSN { get; private set; }

    /// <summary>
    /// List of the boats belonging to the member.
    /// </summary>
    /// <value></value>
    public List<Boat> Boats { get; private set; }

    [JsonConstructor]
    /// <summary>
    /// Creates a member. ID is created by using current time.
    /// </summary>
    /// <param name="name">Name of the member.</param>
    /// <param name="ssn">SSN of the member.</param>
    /// <param name="id">Id of the member.</param>
    public Member(string name, string ssn, int id = -1)
    {
      Id = id;
      Name = name;
      SSN = ssn;
      Boats = new List<Boat>();
    }

    /// <summary>
    /// Creates a member from a member object and uses a new id.
    /// </summary>
    /// <param name="member">Member to be copied.</param>
    /// <param name="id">Id to use for the new member.</param>
    public Member(Member member, int id)
    {
      Id = id;
      SetFields(member);
    }

    /// <summary>
    /// Sets the fields from a member object to the instance fields.
    /// </summary>
    /// <param name="member">The member object to copy fields from.</param>
    public void SetFields(Member member)
    {
      Name = member.Name;
      SSN = member.SSN;
      Boats = member.Boats;
    }

    /// <summary>
    /// Adds a boat to the boat list.
    /// </summary>
    /// <param name="boat">The boat object to add to the boat list.</param>
    public void Addboat(Boat boat)
    {
      Boats.Add(boat);
    }
    
    /// <summary>
    /// Removes a boat from the boat list.
    /// </summary>
    /// <param name="boat">The boat object to remove from the boat list.</param>
    public void RemoveBoat(Boat boat)
    {
      Boats.Remove(boat);
    }
  }
}
