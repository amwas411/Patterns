using EventSourcing.Events;
using EventSourcing.Models;

var shipA = new Ship("ShipA", 500);
var shipB = new Ship("ShipB", 40);
var shipC = new Ship("ShipC", 200);
var port1 = new Port("Port1");
var port2 = new Port("Port2");
var cargo1 = new Cargo("Cargo1", 10);
var cargo2 = new Cargo("Cargo2", 100);
var cargo3 = new Cargo("Cargo3", 1000);

var a1 = new ArrivalEvent(shipA,port1, new DateTime(2024, 1, 1));
var a2 = new ArrivalEvent(shipB,port2, new DateTime(2024, 1, 2));
var a3 = new ArrivalEvent(shipC, port2, new DateTime(2024, 1, 3));
var d1 = new DepartureEvent(shipC, port2, new DateTime(2024, 1, 4));
var c3 = new UnloadEvent(shipB, port2, new DateTime(2024, 1, 3), cargo1);
var c1 = new LoadEvent(shipB, port2, new DateTime(2024, 1, 4), cargo1);
var c2 = new LoadEvent(shipB, port2, new DateTime(2024, 1, 4), cargo2);
var c4 = new LoadEvent(shipB, port2, new DateTime(2024, 1, 4), cargo3);
var ep = new EventProcessor();
try
{
	ep.Process([a1,a2,d1, a3, c1,c2,c3,c4]);
}
catch (ShippingException e)
{
	Console.WriteLine(e.Message);
}

foreach (var i in ep.Log)
{
	Console.WriteLine($"{i}");
}