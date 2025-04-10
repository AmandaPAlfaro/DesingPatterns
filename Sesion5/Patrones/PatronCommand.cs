using System;

namespace PatronesComportamiento.Patrones;

/*
Escenario: Sistema de control de iluminacion en una casa inteligente. El sistema debe apagar y encender luces a través
de diferentes comandos. Cada comando encapsula la acción específica que se va a realizar.
*/

// 1. Definir la interfaz Command
public interface ICommand
{
    void Execute();
}

// 2. Clase receptora: representa al dispositivo que realizará la accion
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Luz encendida");
    }

    public void TurnOff()
    {
        Console.WriteLine("Luz apagada");
    }
}

// 3. Implementacion concreta de los comandos
public class TurnOnLightCommand : ICommand
{
    private Light _light;

    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

// 4. Implementacion concreta de los comandos
public class TurnOffLightCommand : ICommand
{
    private Light _light;

    public TurnOffLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}

// 5. Clase invocadora: representa al control remoto
public class RemoteControl
{
    private ICommand _command = null!;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

// 6. Implementacion del cliente
public class AppCommand
{
    public static void Ejecutar()
    {
        Console.WriteLine("Patron Command");

        // Crear el receptor
        Light light = new Light();

        // Crear los comandos
        ICommand turnOnCommand = new TurnOnLightCommand(light);
        ICommand turnOffCommand = new TurnOffLightCommand(light);

        // Crear el invocador
        RemoteControl remoteControl = new RemoteControl();

        // Asignar los comandos al invocador
        remoteControl.SetCommand(turnOnCommand);
        remoteControl.PressButton();

        remoteControl.SetCommand(turnOffCommand);
        remoteControl.PressButton();
    }
}