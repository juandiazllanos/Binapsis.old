using Binapsis.Plataforma.ServicioDatos.Helper;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Binapsis.Plataforma.ServicioDatos.Controllers
{
    [Route("api/datos")]
    public class DiagramaDatosController : Controller
    {
        ConfiguracionImpl _configuracion;

        public DiagramaDatosController(ConfiguracionInfo configuracionInfo)
        {
            _configuracion = new ConfiguracionImpl (configuracionInfo.Url);
        }

        [HttpPost("{contexto}/dd/{uri}/{tipo}")]
        public void Post(string contexto, string uri, string tipo)
        {
            DiagramaDatosHelper helper = new DiagramaDatosHelper(_configuracion, HttpContext, uri, tipo);
            helper.Ejecutar(contexto);
        }
    }
}
