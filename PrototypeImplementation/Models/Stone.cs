using System.Text;

namespace PrototypeImplementation.Models;
class Stone : Item
{
	private string _pattern = "{0}{0}";
	private int _size = 2;

	public Stone(string symbol) : base(symbol) 
	{
		var sb = new StringBuilder();
		for (int i = 0; i < _size - 1; i++)
		{
			sb.AppendLine(_pattern);
		}

		// Last symbol should not place newline symbol.
		sb.Append(_pattern);
		
		Pattern = sb.ToString();
	}
}