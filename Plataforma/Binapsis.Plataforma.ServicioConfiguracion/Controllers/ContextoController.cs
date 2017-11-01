using Binapsis.Plataforma.Configuracion;
using Microsoft.AspNetCore.Mvc;

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class ContextoController : ConfiguracionController<Contexto>
    {
        public ContextoController(ContextoInfo contextoInfo) 
            : base(contextoInfo)
        {
        }

        [HttpGet("{clave}")]
        public Contexto Get(string clave)
        {
            return Obtener(clave);
        }

        [HttpPost]
        public void Post([FromBody]Contexto valor)
        {
            Crear(valor);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Contexto valor)
        {
            Editar(clave, valor);
        }

        [HttpDelete("{clave}")]
        public void Delete(string clave)
        {
            Eliminar(clave);
        }
    }
}
