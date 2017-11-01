using Binapsis.Plataforma.ServicioDatos.Impl;
using System.Collections.Generic;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class ProcedureKeyHelper
    {
        ConfiguracionImpl _configuracion;

        string _comando;
        string _clave;

        public ProcedureKeyHelper(ConfiguracionImpl configuracion, string uri, string tipo)
        {
            _configuracion = configuracion;
            _comando = "usp_Clave_Siguiente";
            _clave = configuracion.ObtenerTabla(uri, tipo)?.Nombre;
        }

        public string ObtenerKey(string contexto)
        {
            return ObtenerKey(contexto, 1);
        }

        public string ObtenerKey(string contexto, int cobertura)
        {   
            Dictionary<string, object> parametros = new Dictionary<string, object>
            {
                { "clave", _clave },
                { "valor", 0 },
                { "cobertura", cobertura }
            };

            ProcedureHelper helper = new ProcedureHelper(_configuracion, contexto, _comando);

            helper.Ejecutar(parametros);

            return helper.Obtener("valor")?.ToString();
        }
    }
}
