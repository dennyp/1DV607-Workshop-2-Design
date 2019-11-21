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
    private int memberId;
    private List<Member> members = new List<Member>();

    /// <summary>
    /// The filename for the JSON file that members are stored in.
    /// </summary>
    private const string fileName = "members.json";

    public FileHandler()
    {
      members = GetMembers();
      memberId = GetNextMemberId();
    }

    /// <summary>
    /// Calculates the next available id for the members.
    /// </summary>
    /// <returns>The next available id.</returns>
    private int GetNextMemberId()
    {
      int nextId = 0;
      int highestId = 0;
      foreach (var member in members)
      {
        if (member.Id > highestId)
        {
          highestId = member.Id;
        }
      }

      nextId = highestId + 1;

      return nextId;
    }

    /// <summary>
    /// Changes the member's information.
    /// </summary>
    /// <param name="newMember">Member who will be changed.</param>
    public void ChangeMemberInformation(Member memberWithNewInfo)
    {
      Member memberWithOldInfo = members.SingleOrDefault(m => m.Id == memberWithNewInfo.Id);
      DeleteMember(memberWithOldInfo);
      SaveMember(memberWithNewInfo);
      CreateFileWithMembers();
    }

    /// <summary>
    /// Deletes a member from the member list.
    /// </summary>
    /// <param name="member">Member to delete.</param>
    public void DeleteMember(Member member)
    {
      members.Remove(member);
    }

    /// <summary>
    /// Saves a member to the member list.
    /// </summary>
    /// <param name="member">Member to save</param>
    public void SaveMember(Member member)
    {
      members.Add(member);
    }

    /// <summary>
    /// Adding a member to list and saves the list to file.
    /// </summary>
    /// <param name="member">Member to be saved and written to file.</param>
    public void SaveMemberToFile(Member member)
    {
      Member newMember = new Member(member, memberId);
      SaveMember(newMember);
      CreateFileWithMembers();
      memberId++;
    }

    /// <summary>
    /// Removes a member from the member list and saves the list to file.
    /// </summary>
    /// <param name="id">Id of the member to remove.</param>
    public void RemoveMemberFromFile(int id)
    {
      Member member = members.SingleOrDefault(m => m.Id == id);
      DeleteMember(member);
      CreateFileWithMembers();
    }

    /// <summary>
    /// Serializes list of members to JSON and saves to file.
    /// </summary>
    private void CreateFileWithMembers()
    {
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, members);
      }
    }

    /// <summary>
    /// Delete a boat from a member.
    /// </summary>
    /// <param name="member">The member who owns the boat to delete.</param>
    /// <param name="boat">The boat to delete.</param>
    public void DeleteBoat(Member member, Boat boat)
    {
      member.RemoveBoat(boat);
      // TODO: Should use an UpdateMember method?
      DeleteMember(member);
      SaveMember(member);
    }



    /// <summary>
    /// Finds the member with the specified boat ID.
    /// </summary>
    /// <param name="boatId">The ID of the boat.</param>
    /// <returns>A member object that owns the boat.</returns>
    public Member FindMemberWithBoatId(int boatId)
    {
      int memberWithBoatId = 0;
      foreach (var member in members)
      {
        foreach (var boat in member.Boats)
        {
          if (boat.Id == boatId)
          {
            memberWithBoatId = member.Id;
          }
        }
      }

      return members.SingleOrDefault(m => m.Id == memberWithBoatId);
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
    public void RegisterBoat(int memberId, string type, string length)
    {
      Member member = members.SingleOrDefault(m => m.Id == memberId);

      BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), type);
      Boat boat = new Boat(boatType, double.Parse(length));
      member.Boats.Add(boat);
      DeleteMember(member);
      SaveMember(member);
    }

    /// <summary>
    /// Updates info of a boat.
    /// </summary>
    /// <param name="boatId">The ID of the boat.</param>
    /// <param name="type">The type of the boat.</param>
    /// <param name="length">The length of the boat.</param>
    public void UpdateBoat(int boatId, string type, string length)
    {
      Member member = FindMemberWithBoatId(boatId);

      BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), type);
      Boat boat = member.Boats.SingleOrDefault(b => b.Id == boatId);
      // boat.Length = int.Parse(length);
      // boat.Type = boatType;

      DeleteMember(member);
      SaveMember(member);
    }
  }
}
