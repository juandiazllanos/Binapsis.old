using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Configuracion.Datos;
using System.Linq;
using Binapsis.Plataforma.Configuracion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    [Route("configuracion/[controller]")]
    public class ConsultaController : Controller
    {
        public ConsultaController(ContextoInfo contextoInfo)             
        {
            ContextoInfo = contextoInfo;
        }

        [HttpGet("definicion/{clave}")]
        public IObjetoDatos Get(string clave)
        {
            return ConfiguracionRepositorio.Instancia.Comandos.FirstOrDefault(item => item.Nombre.Equals(clave, System.StringComparison.OrdinalIgnoreCase));
        }

        [HttpGet("{consulta}/{*parametros}")]
        public IColeccion Get(string consulta, string parametros)
        {
            Comando comando = Get(consulta) as Comando;
            if (comando == null) return null;

            IContexto contexto = ContextoHelper.CrearContexto(ContextoInfo);
            Recuperar recuperar = RecuperarHelper.CrearComando(contexto, comando);
            if (recuperar == null) return null;

            string[] args = parametros?.Split('&');
            int index = 0;

            if (args != null )
                foreach (string arg in args)
                    recuperar.EstablecerParametro(arg.Substring(0, index = arg.IndexOf("=")), arg.Substring(index + 1));

            return recuperar.EjecutarConsulta();            
        }

        public ContextoInfo ContextoInfo
        {
            get;
        }
        
    }
}
