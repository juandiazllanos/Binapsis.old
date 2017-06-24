using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Cambios
{
    public interface IResumenCambios
    {
        bool Creado(IObjetoDatos od);
        bool Eliminado(IObjetoDatos od);
        bool Modificado(IObjetoDatos od);

        IColeccion ObtenerObjetoDatosCambiados();
        IEnumerable<IPropiedad> ObtenerCambios(IObjetoDatos od);
        object ObtenerValorAntiguo(IObjetoDatos od, IPropiedad propiedad);
    }
}
