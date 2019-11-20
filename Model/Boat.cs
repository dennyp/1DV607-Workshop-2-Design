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
    public int Id { get; private set; }

    /// <summary>
    /// The length of the boat.
    /// </summary>
    public double Length { get; private set; }

    /// <summary>
    /// The type of the boat.
    /// </summary>
    public BoatType Type { get; private set; }

    /// <summary>
    /// Creating a boat.
    /// </summary>
    /// <param name="type">The type of the boat.</param>
    /// <param name="length">The length of the boat.</param>
    public Boat(BoatType type, double length)
    {
      Type = type;
      Length = length;
    }

    /// <summary>
    /// Sets the fields from a boat object to the instance fields.
    /// </summary>
    /// <param name="boat">The boat to copy fields from.</param>
    public void SetFields(Boat boat)
    {
      Type = boat.Type;
      Length = boat.Length;
    }
  }
}
