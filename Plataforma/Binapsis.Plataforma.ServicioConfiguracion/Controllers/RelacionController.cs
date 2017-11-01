using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Microsoft.AspNetCore.Http;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class RelacionController : ConfiguracionController<Relacion>
    {
        public RelacionController(ContextoInfo contextoInfo) : base(contextoInfo)
        {
        }


        [HttpGet("{clave}", Order = 0)]
        public Relacion Get(string clave)
        {
            return Obtener(clave);
        }

        [HttpGet(Order = 1)]
        public IColeccion Get()
        {
            return ObtenerColeccion(Request.Query);
        }
        
        [HttpPost]
        public void Post([FromBody]Relacion valor)
        {
            Crear(valor);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Relacion valor)
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
