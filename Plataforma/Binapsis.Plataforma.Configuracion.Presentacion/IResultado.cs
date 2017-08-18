namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public interface IResultado
    {
        void OK();
        void OK(object resultado);
        void Cancelar();
    }
}