using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class ComandoController : ConfiguracionController<Comando>
    {
        public ComandoController(ContextoInfo contextoInfo) 
            : base(contextoInfo)
        {
        }


        [HttpGet("{clave}")]
        public Comando Get(string clave)
        {
            return Obtener(clave);
        }

        [HttpPost]
        public void Post([FromBody]Comando od)
        {
            Crear(od);
        }

        [HttpPut("{clave}")]
        public void Put(string clave, [FromBody]Comando od)
        {
            Editar(clave, od);
        }

        [HttpDelete("{clave}")]
        public void Delete(string clave)
        {
            Eliminar(clave);
        }

        //protected override Type Type
        //{
        //    get => typeof(Comando);
        //}

    }
}
