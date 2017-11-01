using Binapsis.Consola.Definicion;
using Binapsis.Consola.Estructura;
using Binapsis.Plataforma;
using Binapsis.Plataforma.Comandos;
using System.Collections;

namespace Binapsis.Consola
{
    public class Contenido
    {
        public Contenido(ContenidoInfo contenidoInfo)
        {
            ContenidoInfo = contenidoInfo;            
        }

        public virtual IEnumerable Consultar()
        {
            ConsultaInfo consultaInfo = Pagina.Main.ConsolaInfo.Consultas[ContenidoInfo.ConsultaInfo.Nombre];
            if (consultaInfo == null) return null;

            Consulta consulta = new Consulta(HelperContext.Contexto, consultaInfo.Nombre);
            return consulta.Ejecutar();            
        }
        
        public ContenidoInfo ContenidoInfo
        {
            get;
        }
        
        public Pagina Pagina
        {
            get;
            internal set;
        }
    }
}
