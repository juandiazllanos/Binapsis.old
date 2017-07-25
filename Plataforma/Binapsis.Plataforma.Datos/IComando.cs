using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos
{
    public interface IComando
    {        
        void Ejecutar();
        IColeccion EjecutarConsulta();
        IObjetoDatos EjecutarConsultaSimple();

        void EstablecerParametro(int indice, object valor);
        void EstablecerParametro(string nombre, object valor);

        object ObtenerParametro(int indice);
        object ObtenerParametro(string nombre);
    }
}
