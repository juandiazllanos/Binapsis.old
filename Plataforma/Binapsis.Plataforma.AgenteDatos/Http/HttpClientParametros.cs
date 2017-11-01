using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.AgenteDatos.Http
{
    class HttpClientParametros
    {
        StringBuilder _parametros;

        #region Constructores
        public HttpClientParametros()
        {
            _parametros = new StringBuilder();
        }

        public HttpClientParametros(IDictionary<string, object> parametros)
            : this()
        {
            if (parametros == null) return;

            foreach (var kvp in parametros)
                Agregar(kvp.Key, kvp.Value?.ToString());
        }
        #endregion

        
        #region Metodos
        public void Agregar(string clave, string valor)
        {
            if (string.IsNullOrEmpty(valor)) return;
            if (_parametros.Length != 0) _parametros.Append("&");
            _parametros.Append($"{clave}={valor}");
        }

        public override string ToString()
        {
            return _parametros.ToString();
        }
        #endregion
    }
}
