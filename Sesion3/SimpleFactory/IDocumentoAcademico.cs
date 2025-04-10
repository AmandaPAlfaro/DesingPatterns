namespace PatronesCreacionales2.SimpleFactory
{
    public interface IDocumentoAcademico
    {
        void Generar(int idEstudiante);
        void Imprmir();
        string ObtenerNombreDocumento();
    }
}
