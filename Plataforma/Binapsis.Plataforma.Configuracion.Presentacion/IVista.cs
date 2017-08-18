namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public interface IVista
    {
        void Mostrar(object obj);

        IResultado Resultado
        {
            get;
            set;
        }
    }
}
