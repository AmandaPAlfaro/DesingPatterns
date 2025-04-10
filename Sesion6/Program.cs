using Sesion6.Patrones;

Console.WriteLine("Patrones de Comportamiento");

Console.WriteLine("Seleccione el patron a ejecutar");

Console.WriteLine("1. Patron Observer");
Console.WriteLine("2. Patron Observer Mejorado");
Console.WriteLine("3. Patron Mediator");
Console.WriteLine("4. Patron Null Object");
Console.WriteLine("5. Patron Interator");


var opcion = Console.ReadLine();

switch (opcion) 
{
    case "1":
        Console.WriteLine("Patron Observador");
        AppObserver.Ejecutar();
        break;

    case "2":
        Console.WriteLine("Patron Observador Mejorado");
        AppObserverMejorado.Ejecutar();
        break;

    case "3":
        Console.WriteLine("Patron Mediator");
        AppMediator.Ejecutar();
        break;

    case "4":
        Console.WriteLine("Patron Null Object");
        AppNullObject.Ejecutar();
        break;

    case "5":
        Console.WriteLine("Patron Iterator");
        AppIterator.Ejecutar();
        break;

    case "6":
        Console.WriteLine("Opcion no valida");
        break;
}