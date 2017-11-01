using Binapsis.Plataforma.AgenteDatos.Http;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.AgenteDatos.Helper
{
    class KeyHelper
    {
        string _url;
        string _contexto;

        public KeyHelper(string url, string contexto)
        {
            _url = url;
            _contexto = contexto;
        }

        public object Obtener(ITipo tipo, IPropiedad clave)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            string valor = httpClient.ObtenerKey(tipo.Uri, tipo.Nombre, clave.Nombre);

            if (!string.IsNullOrEmpty(valor))
                return DataHelper.Instancia.Convert(clave, valor);
            else
                return null;
        }

        public object Obtener(ITipo tipo, IPropiedad clave, int cobertura)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            string valor = httpClient.ObtenerKey(tipo.Uri, tipo.Nombre, clave.Nombre, cobertura);

            if (!string.IsNullOrEmpty(valor))
                return DataHelper.Instancia.Convert(clave, valor);
            else
                return null;
        }
    }
}
