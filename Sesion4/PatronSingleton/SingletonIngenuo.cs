#nullable disable

namespace Sesion04.PatronSingleton;

public class SingletonIngenuo
{
    private static SingletonIngenuo _instance;
    private SingletonIngenuo() {}

    public static SingletonIngenuo GetInstance() 
    {
        if (_instance is null) 
        {
            _instance = new SingletonIngenuo(); 
        }
        return _instance;
    }

    public void ImprimeMensaje() 
    {
        Console.WriteLine("Hola  soy la instancia ingenua");
    }
}

public sealed class ThreadSafeSingleton 
{
    private static ThreadSafeSingleton _instance;
    private static readonly object _padLock = new object();
    
    public ThreadSafeSingleton()
    {
    }

    public static ThreadSafeSingleton GetInstance() 
    {
        if (_instance is null)
        {
            lock (_padLock)
            {
                if (_instance == null)
                {
                    _instance = new ThreadSafeSingleton();
                }
            }
        }
        return _instance;   
    }


    public void ImprimeMensaje()
    {
        Console.WriteLine("Hola  soy la instancia segura para hilos");
    }
}

public sealed class EagerSingleton
{
    private static readonly EagerSingleton _instance = new EagerSingleton();
    public EagerSingleton() 
    {

    }

    public static EagerSingleton Instance => _instance;

    public void ImprimeMensaje() 
    {
        Console.WriteLine("Hola soy la instancia con catrga temprana");
    }
}

public sealed class SingletonLazy
{
    private static readonly Lazy<SingletonLazy> _instance = new(() => new SingletonLazy());
    
    private SingletonLazy() 
    {
        Console.WriteLine($"Instancia creada {nameof(SingletonLazy)}");
    }

    public static SingletonLazy Instance => _instance.Value;

    public void ImprimeMensaje()
    {
        Console.WriteLine("Hola soy la instancia con carga diferida (Lazy)");
    }
}


public sealed class SingletonDobleCheck
{
    private static SingletonDobleCheck _instance;
    private static readonly object _padLock = new object();

    public SingletonDobleCheck()
    {
        Console.WriteLine("Instancia creada a la antigua");
    }

    public static SingletonDobleCheck GetInstance()
    {
        if (_instance is null)
        {
            lock (_padLock)
            {
                if (_instance == null)
                {
                    _instance = new SingletonDobleCheck();
                }
            }
        }
        return _instance;
    }


    public void ImprimeMensaje()
    {
        Console.WriteLine("Hola  soy la instancia segura para hilos");
    }
}
