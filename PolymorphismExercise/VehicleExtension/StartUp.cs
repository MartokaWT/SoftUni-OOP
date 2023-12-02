using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Core;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.Factories;
using VehiclesExtension.IO.Interfaces;
using VehiclesExtension.IO;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IVehicleFactory vehicleFactory = new VehicleFactory();

IEngine engine = new Engine(reader, writer, vehicleFactory);

engine.Run();