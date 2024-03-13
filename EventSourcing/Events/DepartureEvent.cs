using EventSourcing.Models;
namespace EventSourcing.Events;

/// <summary>
/// Event indicating that a ship are departing from the given port.
/// </summary>
/// <param name="ship">Ship.</param>
/// <param name="port">Port from which the <see cref="ship"/> are departing.</param>
/// <param name="date">Date at which the event occurred.</param>
class DepartureEvent(Ship ship, Port port, DateTime date) : ShippingEvent(ship, port, date)
{
	/// <summary>
	/// Process the event.
	/// </summary>
	public override void Process()
	{
		if (Ship.Location != Port)
		{
			throw new ShippingException($"{Ship} cannot depart from {Port} because it resides in {Ship.Location}.");
		}
		Ship.Location = Ports.Sea;
	}
}