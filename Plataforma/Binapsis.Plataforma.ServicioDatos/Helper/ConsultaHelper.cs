using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Binapsis.Plataforma.ServicioDatos.Operaciones;

using Microsoft.AspNetCore.Http;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class ConsultaHelper
    {
        IConfiguracion _configuracion;
        IContexto _contexto;

        string _consulta;

        #region Constructores
        public ConsultaHelper(ConfiguracionImpl configuracion, string contexto, string consulta)
        {
            _configuracion = configuracion;
            _contexto = ContextoHelper.CrearContexto(configuracion?.ObtenerConexion(contexto));
            
            _consulta = consulta;
        }
        #endregion


        #region Metodos
        public Coleccion Ejecutar(IQueryCollection query)
        {
            //Consultar consultar = new Consultar(_contexto, _configuracion, _consulta);
            Ejecutar consultar = new Ejecutar(_configuracion, _contexto, _consulta);
            
            foreach (var kvp in query)
                consultar.Establecer(kvp.Key, kvp.Value.ToString());

            return consultar.EjecutarConsulta();
        }        
        #endregion
        

    }
}
