using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Sql;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class TablaController : Controller
    {        
        [HttpGet("{nombre}")]
        public Tabla Get(string nombre)
        {
            IHelper helper = new HelperTabla(CadenaConexion);
            return (Tabla)helper.Recuperar(nombre);
        }
        
        [HttpPost]
        public void Post([FromBody]Tabla value)
        {
            IHelper helper = new HelperTabla(CadenaConexion);
            helper.Insertar(value);
        }
                
        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Tabla value)
        {
            IHelper helper = new HelperTabla(CadenaConexion);
            helper.Actualizar(clave, value);
        }
                
        [HttpDelete("{clave}")]
        public void Delete(string clave)
        {
            IHelper helper = new HelperTabla(CadenaConexion);
            Tabla valor = (Tabla)helper.Recuperar(clave);
            helper.Eliminar(valor);
        }

        private string CadenaConexion
        {
            get => Startup.Configuration.GetValue<string>("cadenaConexion");
        }
    }
}
