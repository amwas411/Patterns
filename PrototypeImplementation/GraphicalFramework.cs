using PrototypeImplementation.Models;
using PrototypeImplementation.GraphicalProviders;

/// <summary>
/// Framework for drawing items. Contains all currently drawn items.
/// </summary>
/// <param name="graphicalProvider">Graphical provider.</param>
/// <param name="wall">Wall prototype.</param>
/// <param name="stone">Stone prototype.</param>
/// <param name="room">Room prototype.</param>
class GraphicalFramework(IGraphicalProvider graphicalProvider, Wall wall, Stone stone, Room room)
{
	private readonly IGraphicalProvider _graphicalProvider = graphicalProvider ?? throw new ArgumentNullException(nameof(graphicalProvider));
	private readonly Wall _wallPrototype = wall ?? throw new ArgumentNullException(nameof(wall));
	private readonly Stone _stonePrototype = stone ?? throw new ArgumentNullException(nameof(stone));
	private readonly Room _roomPrototype = room ?? throw new ArgumentNullException(nameof(room));
	private List<Item> _itemCollection = [];

	/// <summary>
	/// Perform redrawing.
	/// </summary>
	/// <exception cref="NotImplementedException">Unknown item type</exception>
	private void Redraw()
	{
		var itemCollection = new List<Item>();
		foreach (var item in _itemCollection)
		{
			var type = item.GetType();
			Item? newItem;
			
			if (type == typeof(Wall))
			{
				newItem = _wallPrototype.Clone();
			}
			else if (type == typeof(Stone))
			{
				newItem = _stonePrototype.Clone();
			}
			else if (type == typeof(Room))
			{
				newItem = _roomPrototype.Clone();
			}
			else 
			{
				throw new NotImplementedException($"Unknown item type {type.Name}");
			}
			itemCollection.Add(newItem);
			_graphicalProvider.Draw(newItem.Draw());
		}
		_itemCollection.Clear();
		_itemCollection = itemCollection;
	}

	/// <summary>
	/// Draw a new wall.
	/// </summary>
	public void DrawWall()
	{
		var wall = _wallPrototype.Clone();
		_itemCollection.Add(wall);
		_graphicalProvider.Draw(wall.Draw());
	}

	/// <summary>
	/// Draw a new stone.
	/// </summary>
	public void DrawStone()
	{
		var stone = _stonePrototype.Clone();
		_itemCollection.Add(stone);
		_graphicalProvider.Draw(stone.Draw());
	}

	/// <summary>
	/// Draw a new room.
	/// </summary>
	public void DrawRoom()
	{
		var room = _roomPrototype.Clone();
		_itemCollection.Add(room);
		_graphicalProvider.Draw(room.Draw());
	}

	/// <summary>
	/// Redraw the current picture without walls.
	/// </summary>
	public void RemoveWalls()
	{
		_itemCollection = _itemCollection.Where((i) => i.GetType() != typeof(Wall)).ToList();
		Redraw();
	}

	public void RotateWall()
	{
		_wallPrototype.Rotate();
	}
}