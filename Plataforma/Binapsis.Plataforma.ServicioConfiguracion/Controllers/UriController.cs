using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class UriController : ConfiguracionController<Uri>
    {
        public UriController(ContextoInfo contextoInfo) 
            : base(contextoInfo)
        {
        }

        [HttpGet("{clave}", Order = 0)]
        public Uri Get(string clave)
        {
            return Obtener(clave);
        }


        [HttpGet(Order = 1)]
        public IColeccion Get()
        {
            return ObtenerColeccion(Request.Query);
        }

        [HttpPost]
        public void Post([FromBody]Uri valor)
        {
            Crear(valor);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Uri od)
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
