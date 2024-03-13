namespace PrototypeImplementation.Exceptions;

class GraphicException : ApplicationException 
{
	public GraphicException() : base() {}
	public GraphicException(string? message) : base(message) {}
}