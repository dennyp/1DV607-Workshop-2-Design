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

    /// <summary>
    /// Creates a member. ID is created by using current time.
    /// </summary>
    /// <param name="name">Name of the member.</param>
    /// <param name="ssn">SSN of the member.</param>
    /// <param name="id">Id of the member.</param>
    public Member(string name, string ssn, int id)
    {
      Id = id;
      Name = name;
      SSN = ssn;
      Boats = new List<Boat>();
    }

    /// <summary>
    /// Sets the fields from a member object to the instance fields.
    /// </summary>
    /// <param name="member">The member object to copy fields from.</param>
    public void SetFields(Member member)
    {
      Id = member.Id;
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
