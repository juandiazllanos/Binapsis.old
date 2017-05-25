using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Configuracion.Sql;
using Binapsis.Plataforma.Configuracion;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class EnsambladoController : Controller
    {

        // GET api/values/5
        [HttpGet("{nombre}")]
        public Ensamblado Get(string nombre)
        {
            IHelper sql = new HelperEnsamblado(CadenaConexion);
            Ensamblado valor = (Ensamblado)sql.Recuperar(nombre);
            return valor;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]Ensamblado value)
        {
            IHelper sql = new HelperEnsamblado(CadenaConexion);

            if (!sql.Existe(value))                
                sql.Insertar(value);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Ensamblado value)
        {
            IHelper sql = new HelperEnsamblado(CadenaConexion);

            if (sql.Existe(clave))
                sql.Actualizar(clave, value);
        }

        [HttpDelete("{nombre}")]
        public void Delete(string nombre)
        {
            IHelper sql = new HelperEnsamblado(CadenaConexion);
            Ensamblado valor = (Ensamblado)sql.Recuperar(nombre);
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
