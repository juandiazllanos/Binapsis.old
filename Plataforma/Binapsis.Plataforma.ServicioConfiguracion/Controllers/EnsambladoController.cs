using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Configuracion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class EnsambladoController : ConfiguracionController<Ensamblado>
    {
        public EnsambladoController(ContextoInfo contextoInfo) 
            : base(contextoInfo)
        {
        }

        [HttpGet("{clave}")]
        public Ensamblado Get(string clave)
        {            
            return Obtener(clave) as Ensamblado;
        }

        [HttpPost]
        public void Post([FromBody]Ensamblado valor)
        {            
            Crear(valor);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Ensamblado valor)
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
