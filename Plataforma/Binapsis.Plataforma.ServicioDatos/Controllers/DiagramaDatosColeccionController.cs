using Binapsis.Plataforma.ServicioDatos.Helper;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Binapsis.Plataforma.ServicioDatos.Controllers
{
    [Route("api/datos")]
    public class DiagramaDatosColeccionController : Controller
    {
        ConfiguracionImpl _configuracion;

        public DiagramaDatosColeccionController(ConfiguracionInfo configuracionInfo)
        {
            _configuracion = new ConfiguracionImpl(configuracionInfo.Url);
        }

        [HttpPost("{contexto}/col/dd/{uri}/{tipo}")]
        public void Post(string contexto, string uri, string tipo)
        {
            DiagramaDatosColeccionHelper helper = new DiagramaDatosColeccionHelper(_configuracion, HttpContext, uri, tipo);
            helper.Ejecutar(contexto);
        }
    }
}
