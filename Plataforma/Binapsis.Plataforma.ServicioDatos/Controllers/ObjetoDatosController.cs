using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Helper;
using Binapsis.Plataforma.ServicioDatos.Impl;

using Microsoft.AspNetCore.Mvc;

namespace Binapsis.Plataforma.ServicioDatos.Controllers
{
    [Route("api/datos")]
    public class ObjetoDatosController : Controller
    {
        ConfiguracionImpl _configuracion;

        public ObjetoDatosController(ConfiguracionInfo configuracionInfo)
        {            
            _configuracion = new ConfiguracionImpl(configuracionInfo.Url);
        }

        [HttpGet("{contexto}/od/{uri}/{tipo}/{id}")]
        public ObjetoDatos Get(string contexto, string uri, string tipo, string id)
        {
            RecuperarHelper helper = new RecuperarHelper(_configuracion, contexto, uri, tipo);
            return helper.Ejecutar(id);
        }

        [HttpGet("{contexto}/od/{uri}/{tipo}/{clave}/{valor}")]
        public ObjetoDatos Get(string contexto, string uri, string tipo, string clave, string valor)
        {
            RecuperarHelper helper = new RecuperarHelper(_configuracion, contexto, uri, tipo);
            return helper.Ejecutar(clave, valor);
        }

        [HttpPost("{contexto}/od/{uri}/{tipo}")]
        public void Post(string contexto, string uri, string tipo)
        {
            ObjetoDatosHelper helper = new ObjetoDatosHelper(_configuracion, HttpContext, uri, tipo);
            helper.Crear(contexto);
        }

        [HttpPut("{contexto}/od/{uri}/{tipo}")]
        public void Put(string contexto, string uri, string tipo)
        {
            ObjetoDatosHelper helper = new ObjetoDatosHelper(_configuracion, HttpContext, uri, tipo);
            helper.Editar(contexto);
        }

        [HttpDelete("{contexto}/od/{uri}/{tipo}")]
        public void Delete(string contexto, string uri, string tipo)
        {
            ObjetoDatosHelper helper = new ObjetoDatosHelper(_configuracion, HttpContext, uri, tipo);
            helper.Eliminar(contexto);
        }

        [HttpDelete("{contexto}/od/{uri}/{tipo}/{id}")]
        public void Delete(string contexto, string uri, string tipo, string id)
        {
            
        }
        
    }
}
