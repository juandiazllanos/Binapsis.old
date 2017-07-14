using Binapsis.Plataforma.Configuracion;
using System.Collections;

namespace Binapsis.Plataforma.Datos
{
    public interface IConfiguracion
    {

        Tabla ObtenerTabla(string uri, string tipo);        
        Tabla ObtenerTabla(string nombreTabla);
        Relacion ObtenerRelacion(string uri, string tipo, string propiedad);

        IList ObtenerTablas();
        IList ObtenerRelaciones();
        IList ObtenerRelacionesPorTipo(string uri, string tipo);
        IList ObtenerRelacionesPorTabla(string tablaPrincipal, string tablaSecundaria);

        Tipo ObtenerTipo(string uri, string tipo);
    }
}
