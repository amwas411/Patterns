using EventSourcing.Models;
namespace EventSourcing.Events;

/// <summary>
/// Shipping event.
/// </summary>
/// <param name="ship">Ship.</param>
/// <param name="port">Port at which the given ship resides.</param>
/// <param name="date">Date at which the event occurred.</param>
abstract class ShippingEvent(Ship ship, Port port, DateTime date)
{
	/// <summary>
	/// Date at which the event occurred.
	/// </summary>
	public DateTime Date { get; init; } = date;

	/// <summary>
	/// Ship.
	/// </summary>
	protected Ship Ship { get; init; } = ship ?? throw new ArgumentNullException(nameof(ship));

	/// <summary>
	/// Port at which the given ship resides.
	/// </summary>
	protected Port Port { get; init; } = port ?? throw new ArgumentNullException(nameof(port));

	/// <summary>
	/// Get a string represention.
	/// </summary>
	/// <returns>String representation.</returns>
	public override string ToString() => string.Format($"{Date}, {Ship}, {Port}");

	/// <summary>
	/// Process the event.
	/// </summary>
	public abstract void Process();
}