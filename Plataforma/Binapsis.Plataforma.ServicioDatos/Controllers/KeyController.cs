using Binapsis.Plataforma.ServicioDatos.Helper;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Binapsis.Plataforma.ServicioDatos.Controllers
{
    [Route("api/datos")]
    public class KeyController : Controller
    {
        ConfiguracionImpl _configuracion;

        public KeyController(ConfiguracionInfo configuracionInfo)
        {
            _configuracion = new ConfiguracionImpl(configuracionInfo.Url);
        }

        [HttpGet("{contexto}/key/{uri}/{tipo}/{clave}")]
        public string Get(string contexto, string uri, string tipo, string clave)
        {   
            ProcedureKeyHelper helper = new ProcedureKeyHelper(_configuracion, uri, tipo);

            // obtener key sin conbertura
            if (!HttpContext.Request.Query.ContainsKey("cobertura"))
                return helper.ObtenerKey(contexto);

            // obtener key de acuerdo a cobertura
            int cobertura;
            int.TryParse(HttpContext.Request.Query["cobertura"].ToString(), out cobertura);

            return helper.ObtenerKey(contexto, cobertura);
        }
    }
}
