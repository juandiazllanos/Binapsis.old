using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Microsoft.AspNetCore.Http;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class ObjetoDatosColeccionHelper : ControllerHelper<Coleccion>
    {
        Coleccion _coleccion;

        public ObjetoDatosColeccionHelper(ConfiguracionImpl configuracion, HttpContext httpContext, string uri, string tipo) 
            : base(configuracion, httpContext, uri, tipo)
        {
        }

        public override void Crear(string contexto)
        {
            OperacionHelper helper = new OperacionHelper(_configuracion, contexto);
            Coleccion col = Resolver();
            helper.Crear(col);
        }

        public override void Editar(string contexto)
        {
            OperacionHelper helper = new OperacionHelper(_configuracion, contexto);
            Coleccion col = Resolver();
            helper.Editar(col);
        }

        public override void Eliminar(string contexto)
        {
            OperacionHelper helper = new OperacionHelper(_configuracion, contexto);
            Coleccion col = Resolver();
            helper.Eliminar(col);
        }

        protected override Coleccion Resolver()
        {
            if (_coleccion == null)
                return _coleccion = RequestBodyHelper.Instancia.ResolverObjetoDatosColeccion(_httpContext, _tipo);
            else
                return _coleccion;
        }
    }
}
