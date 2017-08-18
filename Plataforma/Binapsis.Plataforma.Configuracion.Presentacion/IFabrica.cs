namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public interface IFabrica
    {
        object Crear();
        object Crear(params object[] param);
    }
}
