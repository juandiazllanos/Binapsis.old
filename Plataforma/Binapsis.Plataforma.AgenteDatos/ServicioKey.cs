using Binapsis.Plataforma.AgenteDatos.Helper;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.AgenteDatos
{
    public class ServicioKey
    {
        string _url;
        string _contexto;

        public ServicioKey(string url, string contexto)
        {
            _url = url;
            _contexto = contexto;
        }

        public object ObtenerKey(ITipo tipo, IPropiedad clave)
        {
            KeyHelper helper = new KeyHelper(_url, _contexto);
            return helper.Obtener(tipo, clave);
        }

        public object ObtenerKey(ITipo tipo, IPropiedad clave, int cobertura)
        {
            KeyHelper helper = new KeyHelper(_url, _contexto);
            return helper.Obtener(tipo, clave, cobertura);
        }

    }
}
