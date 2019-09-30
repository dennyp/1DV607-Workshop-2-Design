using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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
    /// Reads the member file, adds the member to JSON and creates a new member file.
    /// </summary>
    /// <param name="member">Member to save</param>
    public static void Save(Member member)
    {
      List<Member> list = ReadFile(fileName);
      list.Add(member);

      CreateFile(list, fileName);
    }

    /// <summary>
    /// Delete a member from file.
    /// </summary>
    /// <param name="memberId">ID of member to delete.</param>
    public static void Delete(string memberId)
    {
      List<Member> list = ReadFile(fileName);
      list.Remove(list.SingleOrDefault(x => x.ID == memberId));

      CreateFile(list, fileName);
    }

    /// <summary>
    /// Reads a file, deserializes it and returns a list of the content.
    /// </summary>
    /// <param name="fileName">The file to read</param>
    /// <returns>A list of deserialized members</returns>
    private static List<Member> ReadFile(string fileName)
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
    /// Serializes list of members to JSON and saves to file.
    /// </summary>
    /// <param name="list">The list of members</param>
    /// <param name="fileName">The file to create</param>
    private static void CreateFile(List<Member> list, string fileName)
    {
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, list);
      }
    }
  }
}
