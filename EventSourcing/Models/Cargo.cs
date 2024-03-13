namespace EventSourcing.Models;

/// <summary>
/// Cargo that can be loaded/unloaded to/from a ship.
/// </summary>
/// <param name="name">Cargo name.</param>
/// <param name="weight">Cargo weight.</param>
class Cargo(string name, uint weight)
{
	/// <summary>
	/// Cargo name.
	/// </summary>
	public string Name { get; init; } = name ?? throw new ArgumentNullException(nameof(name));

	/// <summary>
	/// Cargo weight.
	/// </summary>
	public uint Weight { get; init; } = weight;
}