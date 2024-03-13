using PrototypeImplementation.Models;
using PrototypeImplementation.GraphicalProviders;
using PrototypeImplementation.Exceptions;

try
{
	var graphicalFramework = new GraphicalFramework(new ConsoleGraphicalProvider(), new Wall("+", ItemOrientation.Horizontal), new Stone("-"), new Room("*"));
	graphicalFramework.DrawWall();
	graphicalFramework.DrawStone();
	graphicalFramework.DrawWall();
	graphicalFramework.DrawRoom();
	graphicalFramework.DrawRoom();
	graphicalFramework.RotateWall();
	graphicalFramework.DrawWall();
	graphicalFramework.RotateWall();
	graphicalFramework.DrawWall();
	
}
catch (GraphicException e)
{
	Console.WriteLine(e);
}