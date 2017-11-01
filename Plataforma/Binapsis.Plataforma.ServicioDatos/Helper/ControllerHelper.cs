using System.Text;
using Microsoft.AspNetCore.Http;

using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.ServicioDatos.Impl;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    abstract class ControllerHelper<T>
    {
        protected ConfiguracionImpl _configuracion;
        protected HttpContext _httpContext;        
        protected Encoding _encoding;
        protected ITipo _tipo;

        #region Constructores
        public ControllerHelper(ConfiguracionImpl configuracion, HttpContext httpContext, string uri, string tipo)
            : this(configuracion, httpContext, configuracion?.ObtenerTipo(uri, tipo), Encoding.UTF8)
        {
        }

        public ControllerHelper(ConfiguracionImpl configuracion, HttpContext httpContext, ITipo tipo, Encoding encoding)
        {
            _configuracion = configuracion;
            _httpContext = httpContext;
            _tipo = tipo;
            _encoding = encoding;
            
        }
        #endregion

        protected abstract T Resolver();

        public abstract void Crear(string contexto);
        public abstract void Editar(string contexto);
        public abstract void Eliminar(string contexto);
                
    }
}
