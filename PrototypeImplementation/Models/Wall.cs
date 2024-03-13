using System.Text;

namespace PrototypeImplementation.Models;
class Wall : Item
{
	private int _orientation;
	private const int _size = 4;

	private void SetPattern()
	{
		var sb = new StringBuilder();
		if (_orientation == ItemOrientation.Horizontal)
		{
			for (int i = 0; i < _size; i++)
			{
				sb.Append("{0}");
			}
			Pattern = sb.ToString();
		}
		else if (_orientation == ItemOrientation.Vertical)
		{
			for (int i = 0; i < _size - 1; i++)
			{
				sb.AppendLine("{0}");
			}

			// Last symbol should not place newline symbol.
			sb.Append("{0}");
			
			Pattern = sb.ToString();
		}
		else
		{
			throw new NotImplementedException($"Unknown placement id = {_orientation}");
		}
	}

	public Wall(string symbol, int orientation) : base(symbol)
	{
		_orientation = orientation;
		SetPattern();
	}

	public void Rotate()
	{
		_orientation = _orientation == ItemOrientation.Horizontal
			? ItemOrientation.Vertical
			: ItemOrientation.Horizontal;
		SetPattern();
	}
}