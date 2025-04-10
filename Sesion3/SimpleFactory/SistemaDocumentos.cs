using PatronesCreacionales2.SimpleFactory;

public class SistemaDocumentos 
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== SISTEMA DE DOCUMENTO ACADEMICOS ===");

        try
        {
            //El estudiante solicita una constancia desde el sistema
            int idEstudiante = 12345;
            IDocumentoAcademico constancia = DocumentoAcademicoFactory.CrearDocumento("constancia");
            constancia.Generar(idEstudiante);
            constancia.Imprmir();

			//El estudiante solicita una carta de recomendacion desde el sistema
			IDocumentoAcademico carta = DocumentoAcademicoFactory.CrearDocumento("recomendacion");
			carta.Generar(idEstudiante);
			carta.Imprmir();
		}
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error {ex.Message}");
            throw;
        }
    }
}
