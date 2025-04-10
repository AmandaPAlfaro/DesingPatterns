using System.Linq.Expressions;

namespace PatronesCreacionales2.Abstract_Factory;

//Interface abstacta para los productos
public interface IButton
{
    void Paint();
}

public interface ITextBox
{
    void DisplayText();
}

//Clases de productos concretos (Estilo Windows)
public class WindowsButton : IButton
{
    public void Paint() => Console.WriteLine("Pintando boton estilo Windows");
}

public class WindowsTextBox : ITextBox 
{
    public void DisplayText() => Console.WriteLine("Textbox de estilo windows");
}

// Clases de productos concretos (Estilo MacOS)

public class MacButton : IButton 
{
    public void Paint() => Console.WriteLine("Pintando boton estiulo MacOs");
}

public class MacTextBox : ITextBox
{
    public void DisplayText() => Console.WriteLine("Mostrando texbox estilo MacOs");
}


//Interfaz abstacta para a fabrica

public interface IGuiFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}

//Fabrica concreta
public class WindowsGuiFactory : IGuiFactory
{
    public IButton CreateButton() => new WindowsButton();

    public ITextBox CreateTextBox() => new WindowsTextBox();
}

public class MacOsGuiFactory : IGuiFactory
{
    public IButton CreateButton() => new MacButton();

    public ITextBox CreateTextBox() => new MacTextBox(); 
}

//Codigo Cliente
public class UIContoller 
{
    private IGuiFactory _guiFactory;
    private readonly IButton _button;
    private readonly ITextBox _textBox;

    public UIContoller(IGuiFactory guiFactory) 
    {
        _guiFactory = guiFactory;
        _button = _guiFactory.CreateButton();
        _textBox = _guiFactory.CreateTextBox(); 
    }

    public void Display() 
    {
        _button.Paint();
        _textBox.DisplayText();
    }
}

public class SistemaCliente 
{
    public static void Ejecutar()
    { 
        IGuiFactory winFactory =  new  WindowsGuiFactory();
        UIContoller windowsUi = new UIContoller(winFactory);
        windowsUi.Display();

        Console.WriteLine();

        // Crear una interfaz de usuario con estilo MacOs
        IGuiFactory macFactory = new MacOsGuiFactory();
        UIContoller macUi = new UIContoller(macFactory);
        macUi.Display();
    }
}











