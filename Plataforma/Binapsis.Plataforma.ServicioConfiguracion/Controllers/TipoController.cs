using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion;

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class TipoController : ConfiguracionController<Tipo>
    {
        public TipoController(ContextoInfo contextoInfo) 
            : base(contextoInfo)
        {
        }

        [HttpGet("{clave}", Order = 0)]
        public Tipo Get(string clave)
        {
            return Obtener(clave);
        }


        [HttpGet(Order = 1)]
        public IColeccion Get()
        {
            return ObtenerColeccion(Request.Query);
        }

        [HttpPost]
        public void Post([FromBody]Tipo od)
        {
            Crear(od);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Tipo od)
        {
            Editar(clave, od);
        }

        [HttpDelete("{clave}")]
        public void Delete(string clave)
        {
            Eliminar(clave);
        }
    }
}
