using EventSourcing.Models;
namespace EventSourcing.Events;

/// <summary>
/// Event which indicates that a ship are arriving at the given port.
/// </summary>
/// <param name="ship">Ship.</param>
/// <param name="port">Port at which the <see cref="ship"/> are arriving.</param>
/// <param name="date">Date at which the event occurred.</param>
class ArrivalEvent(Ship ship, Port port, DateTime date) : ShippingEvent(ship, port, date)
{
	/// <summary>
	/// Process the event.
	/// </summary>
	public override void Process()
	{
		Ship.Location = Port;
	}
}