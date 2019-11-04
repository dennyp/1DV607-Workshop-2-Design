using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Model
{
  /// <summary>
  /// Class that handles file management.
  /// </summary>
  public class FileHandler
  {
    /// <summary>
    /// The filename for the JSON file that members are stored in.
    /// </summary>
    private const string fileName = "members.json";

    /// <summary>
    /// Serializes list of members to JSON and saves to file.
    /// </summary>
    /// <param name="list">The list of members</param>
    /// <param name="fileName">The file to create</param>
    private void CreateFile(List<Member> list, string fileName)
    {
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, list);
      }
    }

    /// <summary>
    /// Delete a member from file.
    /// </summary>
    /// <param name="memberId">ID of member to delete.</param>
    public void Delete(string memberId)
    {
      List<Member> list = GetMembers();
      list.Remove(list.SingleOrDefault(x => x.ID == memberId));

      CreateFile(list, fileName);
    }

    /// <summary>
    /// Delete a boat from a member.
    /// </summary>
    /// <param name="boatId">ID of the boat to delete.</param>
    public void DeleteBoat(string boatId)
    {
      Member member = FindMemberWithBoatId(boatId);

      member.Boats.Remove(member.Boats.SingleOrDefault(b => b.ID == boatId));

      Delete(member.ID);
      Save(member);
    }

    /// <summary>
    /// Finds the member with the specified boat ID.
    /// </summary>
    /// <param name="boatId">The ID of the boat.</param>
    /// <returns>A member object that owns the boat.</returns>
    public Member FindMemberWithBoatId(string boatId)
    {
      List<Member> members = GetMembers();

      string memberWithBoatId = "";
      foreach (var member in members)
      {
        foreach (var boat in member.Boats)
        {
          if (boat.ID == boatId)
          {
            memberWithBoatId = member.ID;
          }
        }
      }

      return members.SingleOrDefault(m => m.ID == memberWithBoatId);
    }

    /// <summary>
    /// Reads members from file.
    /// </summary>
    /// <returns>A list of members.</returns>
    public List<Member> GetMembers()
    {
      return ReadFile(fileName);
    }

    /// <summary>
    /// Reads a file, deserialize it and returns a list of the content.
    /// </summary>
    /// <param name="fileName">The file to read</param>
    /// <returns>A list of deserialized members</returns>
    private List<Member> ReadFile(string fileName)
    {
      List<Member> list;
      using (StreamReader r = new StreamReader(fileName))
      {
        string json = r.ReadToEnd();
        list = JsonConvert.DeserializeObject<List<Member>>(json);
      }

      return list;
    }

    /// <summary>
    /// Registers a boat to a member.
    /// </summary>
    /// <param name="memberId">The member who owns the boat.</param>
    /// <param name="type">The type of the boat.</param>
    /// <param name="length">The length of the boat</param>
    /// <returns>The owner of the boat.</returns>
    public Member RegisterBoat(string memberId, string type, string length)
    {
      List<Member> members = GetMembers();
      Member member = members.SingleOrDefault(m => m.ID == memberId);

      BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), type);
      Boat boat = new Boat(boatType, double.Parse(length));
      member.Boats.Add(boat);
      return member;
    }

    /// <summary>
    /// Reads the member file, adds the member to JSON and creates a new member file.
    /// </summary>
    /// <param name="member">Member to save</param>
    public void Save(Member member)
    {
      List<Member> members = GetMembers();
      members.Add(member);

      CreateFile(members, fileName);
    }

    /// <summary>
    /// Updates info of a boat.
    /// </summary>
    /// <param name="boatId">The ID of the boat.</param>
    /// <param name="type">The type of the boat.</param>
    /// <param name="length">The length of the boat.</param>
    /// <returns>The member who owns the boat.</returns>
    public Member UpdateBoat(string boatId, string type, string length)
    {
      List<Member> members = GetMembers();
      Member member = FindMemberWithBoatId(boatId);

      BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), type);
      Boat boat = member.Boats.SingleOrDefault(b => b.ID == boatId);
      boat.Length = int.Parse(length);
      boat.Type = boatType;

      return member;
    }
  }
}
