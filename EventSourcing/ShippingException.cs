/// <summary>
/// Exception occured in shipping event processing.
/// </summary>
class ShippingException : ApplicationException
{
	public ShippingException() : base() {}
	public ShippingException(string? message) : base(message) {}
}