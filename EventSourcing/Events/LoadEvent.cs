using EventSourcing.Models;
namespace EventSourcing.Events;

/// <summary>
/// Event indicating that a ship are loading a cargo at the given port.
/// </summary>
/// <param name="ship">Ship.</param>
/// <param name="port">Port at which the <see cref="ship"/> are loading cargo.</param>
/// <param name="date">Date at which the event occurred.</param>
class LoadEvent(Ship ship, Port port, DateTime date, Cargo cargo) : ShippingEvent(ship, port, date)
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
			throw new ShippingException($"{Ship} cannot load cargo at {Port} because it resides in {Ship.Location}.");
		}
		var shipStorageWeight = Ship.Storage.Sum(i => i.Weight) + Cargo.Weight;
		if (shipStorageWeight >= Ship.StorageWeightThreshold)
		{
			throw new ShippingException($"{Ship} cannot hold more than {Ship.StorageWeightThreshold} weight, but was trying to hold {shipStorageWeight}.");
		}
		Ship.Storage.Add(cargo);
	}
}