namespace Model
{
  /// <summary>
  /// Represents a boat.
  /// </summary>
  public class Boat
  {
    /// <summary>
    /// The length of the boat.
    /// </summary>
    private double _length;

    /// <summary>
    /// The type of the boat.
    /// </summary>
    private BoatType _type;

    /// <summary>
    /// Creating a boat.
    /// </summary>
    /// <param name="type">The type of the boat.</param>
    /// <param name="length">The length of the boat.</param>
    public Boat(BoatType type, double length)
    {
      _type = type;
      _length = length;
    }

    /// <summary>
    /// String representation of a boat.
    /// </summary>
    /// <returns>The string describing a boat.</returns>
    public override string ToString() => $"Type: {_type}, Length: {_length}";
  }
}
