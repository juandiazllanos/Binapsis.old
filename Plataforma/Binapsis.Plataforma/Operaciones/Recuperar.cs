using Binapsis.Plataforma.AgenteDatos;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Operaciones
{
    class Recuperar
    {
        string _url;
        string _contexto;
        IFabrica _fabrica;

        public Recuperar(string url, string contexto, IFabrica fabrica)
        {
            _url = url;
            _contexto = contexto;
            _fabrica = fabrica;
        }

        public EntidadBase Ejecutar(ITipo tipo, object id)
        {
            ServicioDatos servicio = new ServicioDatos(_url, _contexto, _fabrica);

            if (tipo != null && id != null)
                return servicio.ObtenerObjetoDatos(tipo, id) as EntidadBase;
            else
                return null;
        }

        public T Ejecutar<T>(object id) where T : EntidadBase
        {
            ServicioDatos servicio = new ServicioDatos(_url, _contexto, _fabrica);
            ITipo tipo = HelperContext.TypeHelper.Obtener(typeof(T));

            if (tipo != null && id != null)
                return servicio.ObtenerObjetoDatos(tipo, id) as T;
            else
                return null;
        }
        
    }
}
