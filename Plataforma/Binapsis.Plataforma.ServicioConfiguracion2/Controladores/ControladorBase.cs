namespace Binapsis.Plataforma.ServicioConfiguracion.Controladores
{
    public abstract class ControladorBase : IControlador
    {
        public abstract void Establecer(string valor);

        public abstract string Obtener(string consulta);

        public string CadenaConexion
        {
            get;
            set;
        }
    }
}
