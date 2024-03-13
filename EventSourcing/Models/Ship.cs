namespace EventSourcing.Models;

/// <summary>
/// Ship.
/// </summary>
/// <param name="name"></param>
/// <param name="storageWeightThreshold"></param>
class Ship(string name, uint storageWeightThreshold)
{
	/// <summary>
	/// Ship name.
	/// </summary>
	protected string Name { get; init; } = name ?? throw new ArgumentNullException(nameof(name));

	/// <summary>
	/// Location at which the ship currently resides.
	/// </summary>
	public Port Location { get; set; } = Ports.Sea;

	/// <summary>
	/// Ship storage.
	/// </summary>
	public List<Cargo> Storage { get; init; } = [];

	/// <summary>
	/// Weight limit to load at the ship.
	/// </summary>
	public uint StorageWeightThreshold { get; init; } = storageWeightThreshold;

	/// <summary>
	/// Get a string represention.
	/// </summary>
	/// <returns>String representation.</returns>
	public override string ToString() => string.Format($"{Name}");
}