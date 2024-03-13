using EventSourcing.Models;
namespace EventSourcing.Events;

/// <summary>
/// Event indicating that a ship are unloading a cargo at the given port.
/// </summary>
/// <param name="ship">Ship.</param>
/// <param name="port">Port at which the <see cref="ship"/> are unloading cargo.</param>
/// <param name="date">Date at which the event occurred.</param>
class UnloadEvent(Ship ship, Port port, DateTime date, Cargo cargo) : ShippingEvent(ship, port, date)
{
	/// <summary>
	/// Cargo.
	/// </summary>
	protected Cargo Cargo = cargo ?? throw new ArgumentNullException(nameof(cargo));

	/// <summary>
	/// Process the event.
	/// </summary>
	public override void Process()
	{
		if (Ship.Location != Port)
		{
			throw new ShippingException($"{Ship} cannot unload cargo at {Port} because it resides in {Ship.Location}.");
		}
		Console.WriteLine(Ship.Storage.Remove(cargo));
	}
}