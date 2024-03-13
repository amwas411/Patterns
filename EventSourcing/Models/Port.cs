namespace EventSourcing.Models;

/// <summary>
/// Port at which a ship resides.
/// </summary>
/// <param name="name">Port name.</param>
class Port(string name)
{
	/// <summary>
	/// Port name.
	/// </summary>
	protected string Name { get; init; } = name ?? throw new ArgumentNullException(nameof(name));

	/// <summary>
	/// Get a string represention.
	/// </summary>
	/// <returns>String representation.</returns>
	public override string ToString() => string.Format($"{Name}");
}

/// <summary>
/// Known ports.
/// </summary>
class Ports
{
	// Sea.
	public static readonly Port Sea = new("Sea");
}