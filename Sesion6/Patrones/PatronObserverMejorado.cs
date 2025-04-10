namespace Sesion6.Patrones;

public class WeatherStation
{
    public delegate void TemperatureChangedHandler(float newTemperature);
    public event TemperatureChangedHandler TemperatureChanged;

    private float _temperature;

    public float Temperature
    {
        get { return _temperature; }
        set
        {
            _temperature = value;
            TemperatureChanged?.Invoke(_temperature);
        }
    }

}

// Uso del evento
public class TemperatureDisplay
{
    private readonly WeatherStation _station;

    public TemperatureDisplay(WeatherStation station)
    {
        _station = station;
        // Suscribimos al evento
        _station.TemperatureChanged += StationOnTemperatureChanged;
    }

    private void StationOnTemperatureChanged(float newtemperature)
    {
        Console.WriteLine($"La temperatura ha cambiado a {newtemperature} °C");
    }

    public void Desuscribir()
    {
        _station.TemperatureChanged -= StationOnTemperatureChanged;
    }
}

// Clase de uso

public class AppObserverMejorado
{
    public static void Ejecutar()
    {
        var weatherStation = new WeatherStation();
        var temperatureDisplay = new TemperatureDisplay(weatherStation);
        weatherStation.Temperature = 20;
        weatherStation.Temperature = 25;

        Console.WriteLine("Ahora nos desuscribimos");
        temperatureDisplay.Desuscribir();

        weatherStation.Temperature = 30;

        Console.WriteLine("Hasta aqui se acaban las notificaciones");
    }
}