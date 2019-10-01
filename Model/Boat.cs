using System;

namespace Model
{
  /// <summary>
  /// Represents a boat.
  /// </summary>
  public class Boat
  {
    /// <summary>
    /// ID of boat.
    /// </summary>
    /// <value></value>
    public string ID { get; set; }

    /// <summary>
    /// The length of the boat.
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// The type of the boat.
    /// </summary>
    public BoatType Type { get; set; }

    /// <summary>
    /// Creating a boat.
    /// </summary>
    /// <param name="type">The type of the boat.</param>
    /// <param name="length">The length of the boat.</param>
    public Boat(BoatType type, double length)
    {
      ID = DateTime.Now.ToString("ddmmssffMM");
      Type = type;
      Length = length;
    }

    /// <summary>
    /// String representation of a boat.
    /// </summary>
    /// <returns>The string describing a boat.</returns>
    public override string ToString() => $"Type: {Type}, Length: {Length}";
  }
}
