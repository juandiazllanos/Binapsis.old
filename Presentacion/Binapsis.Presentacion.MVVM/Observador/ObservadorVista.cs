using Binapsis.Presentacion.MVVM.Controlador;
using Binapsis.Presentacion.MVVM.Definicion;

namespace Binapsis.Presentacion.MVVM.Observador
{
    internal class ObservadorVista
    {
        ControladorVistaModelo _controlador;

		public ObservadorVista(ControladorVistaModelo vistaModelo)
        {
            _controlador = vistaModelo;
		}
        
		public void Notificar(PropiedadInfo propiedad)
        {
            _controlador.ActualizarModelo(propiedad);
		}        
	}

}