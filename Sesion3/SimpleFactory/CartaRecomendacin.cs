using PatronesCreacionales2.SimpleFactory;

public class CartaRecomendacin : IDocumentoAcademico
{
    private string _contenido;
    private string _nombreEstudiante;
    private string _nombreProfesor = "Ing. Erik";
    public void Generar(int idEstudiante)
    {
        _nombreEstudiante = $"Estudiante {idEstudiante}";
        _contenido = $"A quien corresponda\n\nPor medio de la presente, recomiendo {_nombreEstudiante}"+
            $"Atentamente\n{_nombreProfesor}";
    }

    public void Imprmir()
    {
        Console.WriteLine($"Imprimiendo carta de recomendacion para {_nombreEstudiante}");
		Console.WriteLine(_contenido);
		Console.WriteLine("---Fin---");
	}

    public string ObtenerNombreDocumento()
    {
        return "Carta de Recomendacion";
    }
}
