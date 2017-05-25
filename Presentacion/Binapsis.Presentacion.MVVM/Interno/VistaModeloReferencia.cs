using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Definicion;

namespace Binapsis.Presentacion.MVVM.Interno
{
    class VistaModeloReferencia : VistaModeloPropiedad
    {
        public VistaModeloReferencia(Vista vista, PropiedadInfo propiedad) 
            : base(vista, propiedad)
        {
        }
        
        public override void Establecer(IObjetoDatos modelo)
        {
            if (VistaModelo == null)
                VistaModelo = Crear(modelo);

            VistaModelo.Establecer(modelo);
        }
        
        public override VistaModelo Obtener()
        {
            return VistaModelo;
        }
        

        public VistaModelo VistaModelo
        {
            get;
            set;
        }
    }
}
