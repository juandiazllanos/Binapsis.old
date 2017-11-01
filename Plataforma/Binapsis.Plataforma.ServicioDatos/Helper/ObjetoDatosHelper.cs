using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Microsoft.AspNetCore.Http;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class ObjetoDatosHelper : ControllerHelper<ObjetoDatos>
    {
        ObjetoDatos _objetoDatos;
        
        #region Constructores
        public ObjetoDatosHelper(ConfiguracionImpl configuracion, HttpContext httpContext, string uri, string tipo)
            : base(configuracion, httpContext, uri, tipo)
        {            
        }        
        #endregion


        #region Metodos
        protected override ObjetoDatos Resolver()
        {
            if (_objetoDatos == null)
                return _objetoDatos = RequestBodyHelper.Instancia.ResolverObjetoDatos(_httpContext, _tipo); //ObjetoDatosInput.Instancia.ReadRequestBody(_httpContext, _encoding, _tipo) as ObjetoDatos;
            else
                return _objetoDatos;
        }
        
        public override void Crear(string contexto)
        {
            OperacionHelper helper = new OperacionHelper(_configuracion, contexto);
            ObjetoDatos od = Resolver();
            helper.Crear(od);
        }

        public override void Editar(string contexto)
        {
            OperacionHelper helper = new OperacionHelper(_configuracion, contexto);
            ObjetoDatos od = Resolver();
            helper.Editar(od);
        }

        public override void Eliminar(string contexto)
        {
            OperacionHelper helper = new OperacionHelper(_configuracion, contexto);
            ObjetoDatos od = Resolver();
            helper.Eliminar(od);
        }
        #endregion
    }
}
