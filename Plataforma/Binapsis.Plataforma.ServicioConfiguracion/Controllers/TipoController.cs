using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Configuracion;
using Microsoft.Extensions.Configuration;
using Binapsis.Plataforma.Configuracion.Sql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class TipoController : Controller
    {        
        // GET api/values/5
        [HttpGet("{nombre}")]
        public Tipo Get(string nombre)
        {
            HelperTipo helper = new HelperTipo(CadenaConexion);
            return helper.Recuperar(nombre);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Tipo value)
        {
            IHelper sql = new HelperTipo(CadenaConexion);

            if (!sql.Existe(value))
                sql.Insertar(value);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Tipo value)
        {
            IHelper sql = new HelperTipo(CadenaConexion);

            if (sql.Existe(clave))
                sql.Actualizar(clave, value);
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
