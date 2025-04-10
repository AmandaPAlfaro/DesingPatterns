namespace Sesion6.Patrones;

//Interfaz comun
public interface ILogger 
{
    void Log(string message);   
}

//Implementacion real
public class ConsoleLogger : ILogger 
{
    public void Log(string message)
    {
        Console.WriteLine($"$[LOG]: {message}");
    }
}

public class NullLogger : ILogger
{
    public void Log(string message) 
    {
        //no hacemos nada
    }
}

//Close client que usa el Logger
public class Cliente 
{
    private ILogger _logger;

    public Cliente(ILogger? logger = null) 
    {
        _logger = logger ?? new NullLogger();
    }

    public void DoSomething() 
    {
        //Procesamos algo...
        _logger.Log("Haciendo algo");
        //No hay necesidad de verificar si el logger es null
    }
}

//Uso del patron Null Object
public class AppNullObject
{
    public static void Ejecutar() 
    {
        //Creamos un logger real 
        ILogger logger = new ConsoleLogger();

        Cliente cliente = new(logger);
        cliente.DoSomething();

        //Crear una clase cliente pero sin logger
        Cliente cliente2 = new();
        cliente2.DoSomething();
    }
}