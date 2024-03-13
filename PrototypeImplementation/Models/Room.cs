using System.Text;
namespace PrototypeImplementation.Models;

class Room : Item
{
	public Room(string symbol) : base(symbol)
	{
		var sb = new StringBuilder();
		sb.AppendLine("{0}{0}{0}{0}");
		sb.AppendLine("{0}  {0}");
		sb.AppendLine("{0}  {0}");

		// Last symbol should not place newline symbol.
		sb.Append("{0}{0}{0}{0}");
		
		Pattern = sb.ToString();
	}
}