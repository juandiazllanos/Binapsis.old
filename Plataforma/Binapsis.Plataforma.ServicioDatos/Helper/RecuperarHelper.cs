using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Binapsis.Plataforma.ServicioDatos.Operaciones;
using Microsoft.AspNetCore.Http;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class RecuperarHelper
    {
        ConfiguracionImpl _configuracion;
        IContexto _contexto;                        
        ITipo _tipo;
        
        public RecuperarHelper(ConfiguracionImpl configuracion, string contexto, string uri, string tipo)
            : this(configuracion, contexto, configuracion?.ObtenerTipo(uri, tipo))
        {
        }

        public RecuperarHelper(ConfiguracionImpl configuracion, string contexto, ITipo tipo)
        {
            _configuracion = configuracion;
            _contexto = ContextoHelper.CrearContexto(configuracion.ObtenerConexion(contexto));
            _tipo = tipo;
        }        

        public ObjetoDatos Ejecutar(object id)
        {
            Recuperar recuperar = new Recuperar(_contexto, _configuracion, _tipo);
            recuperar.Establecer(0, id);
            return recuperar.EjecutarConsultaSimple();
        }

        public ObjetoDatos Ejecutar(string clave, object valor)
        {
            Recuperar recuperar = new Recuperar(_contexto, _configuracion, _tipo);
            recuperar.Establecer(clave, valor);
            return recuperar.EjecutarConsultaSimple();
        }

        public Coleccion Ejecutar(IQueryCollection query)
        {
            ParametroHelper parametros = new ParametroHelper(_tipo, query);
            IPropiedad[] propiedades = parametros.Propiedades;

            Recuperar recuperar = new Recuperar(_contexto, _configuracion, _tipo, propiedades);
            recuperar.Establecer(parametros);
            
            return recuperar.EjecutarConsultaColeccion() as Coleccion;
        }

    }
}
