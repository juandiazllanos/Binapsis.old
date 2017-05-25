using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Configuracion;
using Microsoft.Extensions.Configuration;
using Binapsis.Plataforma.Configuracion.Sql;
using Binapsis.Plataforma.Configuracion.Sql.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class DefinicionController : Controller
    {
        // GET: api/values
        [HttpGet]
        public Definicion Get()
        {
            IHelper helper = new HelperDefinicion(CadenaConexion);
            return (Definicion)helper.Recuperar("");
        }

        [HttpGet("{definicion}/{clave}")]
        public Definicion Get(string definicion, string clave)
        {
            IHelper helper = new HelperDefinicion(CadenaConexion);
            return (Definicion)helper.Recuperar($"{definicion}/{clave}");
        }

        private string CadenaConexion
        {
            get
            {
                return Startup.Configuration.GetValue<string>("cadenaConexion");
            }
        }
    }
}
