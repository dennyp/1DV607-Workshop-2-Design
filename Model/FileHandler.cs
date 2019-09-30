using System.IO;
using Newtonsoft.Json;

namespace Model
{
  class FileHandler
  {
    public static void Save(Member member)
    {
      // TODO : Append to file instead of overwriting.
      using (StreamWriter file = File.CreateText(@"./members.json"))
      {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, member);
      }
    }
  }

}
