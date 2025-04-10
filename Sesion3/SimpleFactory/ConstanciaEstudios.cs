namespace PatronesCreacionales2.SimpleFactory
{
    // Implementaciones concretas
    public class ConstanciaEstudios : IDocumentoAcademico
    {
        private string _contenido;
        private string _nombreEstudiante;

        public void Generar(int idEstudiante)
        {
            _nombreEstudiante = $"Estudiante{idEstudiante}";
            _contenido = $"Por medio de la presente se certifica qu el {_nombreEstudiante}es un buen alumno";
        }

        public void Imprmir()
        {
            Console.WriteLine($"Imprimiendo contasncia de estudios para{_nombreEstudiante}");
            Console.WriteLine(_contenido);
            Console.WriteLine("---Fin---");
        }

        public string ObtenerNombreDocumento()
        {
            return "Constancia de estudio";
        }
    }
}
