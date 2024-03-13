using PrototypeImplementation.Exceptions;
namespace PrototypeImplementation.Models;

abstract class Item(string symbol)
{
	private bool _isDrawn = false;
	protected string Pattern
	{ 
		get => _pattern;
		set
		{
			_pattern = value ?? throw new ArgumentNullException(nameof(Pattern));
		}
	}
	private string _pattern = string.Empty;

	public string Symbol { get; init; } = symbol ?? throw new ArgumentNullException(nameof(symbol));

	public Item Clone()
	{
		return (Item)MemberwiseClone();
	}

	public virtual string Draw() 
	{
		if (_isDrawn)
		{
			throw new GraphicException($"Item {GetType().Name} was already drawn.");
		}
		_isDrawn = true;
		return string.Format(Pattern, Symbol);
	}
}