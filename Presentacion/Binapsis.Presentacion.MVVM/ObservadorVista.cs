using Binapsis.Plataforma.Estructura;

namespace Binapsis.Presentacion.MVVM
{
	internal class ObservadorVista
    {
        VistaModelo _vistaModelo;

		public ObservadorVista(VistaModelo vistaModelo)
        {
            _vistaModelo = vistaModelo;
		}
        
		public void Notificar(IPropiedad propiedad)
        {
            _vistaModelo.ActualizarModelo(propiedad);
		}

	}

}