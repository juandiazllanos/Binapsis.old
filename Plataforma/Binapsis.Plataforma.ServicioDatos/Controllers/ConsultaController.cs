using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Helper;
using Binapsis.Plataforma.ServicioDatos.Impl;

using Microsoft.AspNetCore.Mvc;

namespace Binapsis.Plataforma.ServicioDatos.Controllers
{
    [Route("api/datos")]
    public class ConsultaController : Controller
    {
        ConfiguracionImpl _configuracion;

        public ConsultaController(ConfiguracionInfo configuracionInfo)
        {
            _configuracion = new ConfiguracionImpl(configuracionInfo.Url);
        }

        [HttpGet("{contexto}/qry/{consulta}")]
        public Coleccion Get(string contexto, string consulta)
        {
            ConsultaHelper helper = new ConsultaHelper(_configuracion, contexto, consulta);
            return helper.Ejecutar(Request.Query);
        }
    }
}
