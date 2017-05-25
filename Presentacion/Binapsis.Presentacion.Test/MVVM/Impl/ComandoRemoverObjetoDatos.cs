using Binapsis.Presentacion.MVVM;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class ComandoRemoverObjetoDatos : IComando
    {
        string _propiedad;

        public ComandoRemoverObjetoDatos(string propiedad)
        {
            _propiedad = propiedad;
        }

        public void Ejecutar(IObjetoDatos od)
        {
            IColeccion col = od.ObtenerColeccion(_propiedad);
            if (col.Longitud == 0) return;
                        
            od.RemoverObjetoDatos(_propiedad, col[col.Longitud - 1]);
        }
    }
}
