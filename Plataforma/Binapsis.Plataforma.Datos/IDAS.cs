using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using System.Collections;

namespace Binapsis.Plataforma.Datos
{
    public interface IDAS
    {
        void AplicarCambios(IList datos);
        void AplicarCambios(IDiagramaDatos dd);
        void AplicarCambios(IObjetoDatos od);

        IComando ObtenerComando(string nombre);
        IComando CrearComando(ITipo tipo);
        IComando CrearComando(ITipo tipo, IPropiedad propiedad);
        IComando CrearComando(Comando comando);

        //IObjetoDatos RecuperarObjetoDatos(ITipo tipo, IPropiedad propiedad, object valor);
    }
}
