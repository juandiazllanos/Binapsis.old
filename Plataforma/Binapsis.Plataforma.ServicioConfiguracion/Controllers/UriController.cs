using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Configuracion.Sql;
using Binapsis.Plataforma.Configuracion;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class UriController : Controller
    {        
        // GET api/values/5
        [HttpGet("{nombre}")]
        public Uri Get(string nombre)
        {
            IHelper sql = new HelperUri(CadenaConexion);            
            Uri valor = (Uri)sql.Recuperar(nombre);
            return valor;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Uri valor)
        {
            IHelper sql = new HelperUri(CadenaConexion);

            if (!sql.Existe(valor))                
                sql.Insertar(valor);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Uri valor)
        {
            IHelper sql = new HelperUri(CadenaConexion);

            if (sql.Existe(clave))
                sql.Actualizar(clave, valor);            
        }

        [HttpDelete("{nombre}")]
        public void Delete(string nombre)
        {
            IHelper sql = new HelperUri(CadenaConexion);
            Uri valor = (Uri)sql.Recuperar(nombre);
            sql.Eliminar(valor);
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
