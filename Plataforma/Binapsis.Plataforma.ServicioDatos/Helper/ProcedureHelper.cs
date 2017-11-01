using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Binapsis.Plataforma.ServicioDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class ProcedureHelper
    {
        IConfiguracion _configuracion;
        IContexto _contexto;
        string _comando;

        Ejecutar _ejecutar;
        
        public ProcedureHelper(ConfiguracionImpl configuracion, string contexto, string comando)
        {
            _configuracion = configuracion;
            _contexto = ContextoHelper.CrearContexto(configuracion?.ObtenerConexion(contexto));
            _comando = comando;
        }

        public void Ejecutar(IDictionary<string, object> parametros)
        {
            _ejecutar = new Ejecutar(_configuracion, _contexto, _comando);

            foreach (var kvp in parametros)
                _ejecutar.Establecer(kvp.Key, kvp.Value);

            _ejecutar.EjecutarComando();
        }
        
        public object Obtener(string parametro)
        {
            return _ejecutar?.Obtener(parametro);
        }
    }
}
