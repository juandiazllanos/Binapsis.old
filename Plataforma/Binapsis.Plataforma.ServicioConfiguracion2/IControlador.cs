namespace Binapsis.Plataforma.ServicioConfiguracion
{
    internal interface IControlador
    {
        void Establecer(string valor);
        string Obtener(string consulta);
        string CadenaConexion { get; set; }
    }
}
