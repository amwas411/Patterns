using EventSourcing.Events;

/// <summary>
/// Processes events.
/// </summary>
class EventProcessor
{
	/// <summary>
	/// Holds information about registered events.
	/// </summary>
	public List<ShippingEvent> Log = [];

	/// <summary>
	/// Process event.
	/// </summary>
	/// <param name="shippingEvent">Event.</param>
	public void Process(ShippingEvent shippingEvent)
	{
		shippingEvent.Process();
		Log.Add(shippingEvent);
	}

	/// <summary>
	/// Process a list of events.
	/// </summary>
	/// <param name="shippingEvents">List of events.</param>
	public void Process(IEnumerable<ShippingEvent> shippingEvents)
	{
		foreach (var e in shippingEvents.OrderBy(i => i.Date))
		{
			Process(e);
		}
	}
}