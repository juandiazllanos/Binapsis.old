using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using System.Collections;

namespace Binapsis.Plataforma.Datos
{
    public interface IDAS
    {
        void AplicarCambios(IList datos);
        void AplicarCambios(IDiagramaDatos dd);
        void AplicarCambios(IObjetoDatos od);
    }
}
