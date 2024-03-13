namespace PrototypeImplementation.GraphicalProviders;
/// <summary>
/// Console graphical provider.
/// </summary>
class ConsoleGraphicalProvider : IGraphicalProvider
{
	/// <summary>
	/// Draw text.
	/// </summary>
	/// <param name="text">Text.</param>
	public void Draw(string? text)
	{
		Console.WriteLine(text);
	}
}