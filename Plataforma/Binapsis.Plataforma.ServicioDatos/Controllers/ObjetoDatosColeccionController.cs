using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Helper;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Binapsis.Plataforma.ServicioDatos.Controllers
{
    [Route("api/datos")]
    public class ObjetoDatosColeccionController : Controller
    {
        ConfiguracionImpl _configuracion;

        public ObjetoDatosColeccionController(ConfiguracionInfo configuracionInfo)
        {
            _configuracion = new ConfiguracionImpl(configuracionInfo.Url);
        }

        [HttpGet("{contexto}/col/od/{uri}/{tipo}")]
        public Coleccion Get(string contexto, string uri, string tipo)
        {
            RecuperarHelper helper = new RecuperarHelper(_configuracion, contexto, uri, tipo);
            return helper.Ejecutar(HttpContext.Request.Query);            
        }

        [HttpPost("{contexto}/col/od/{uri}/{tipo}")]
        public void Post(string contexto, string uri, string tipo)
        {
            ObjetoDatosColeccionHelper helper = new ObjetoDatosColeccionHelper(_configuracion, HttpContext, uri, tipo);
            helper.Crear(contexto);
        }

        [HttpPut("{contexto}/col/od/{uri}/{tipo}")]
        public void Put(string contexto, string uri, string tipo)
        {
            ObjetoDatosColeccionHelper helper = new ObjetoDatosColeccionHelper(_configuracion, HttpContext, uri, tipo);
            helper.Editar(contexto);
        }

        [HttpDelete("{contexto}/col/od/{uri}/{tipo}")]
        public void Delete(string contexto, string uri, string tipo)
        {
            ObjetoDatosColeccionHelper helper = new ObjetoDatosColeccionHelper(_configuracion, HttpContext, uri, tipo);
            helper.Eliminar(contexto);
        }
        
    }
}
