using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Definicion;

namespace Binapsis.Presentacion.MVVM.Interno
{
    class VistaModeloPropiedad
    {
        public VistaModeloPropiedad(Vista vista, PropiedadInfo propiedad)             
        {            
            Propiedad = propiedad;
            Vista = vista;
        }

        #region Metodos
        public virtual VistaModelo Crear(IObjetoDatos modelo)
        {
            Vista vistaItem = Vista.CrearVista(Propiedad);
            VistaModelo vistaModeloItem = new VistaModelo(vistaItem);
            vistaModeloItem.Establecer(modelo);

            return vistaModeloItem;
        }

        public virtual void Agregar(IObjetoDatos modelo) { }
        public virtual void Establecer(IObjetoDatos modelo) { }
        public virtual VistaModelo Obtener(IObjetoDatos modelo) => null;
        public virtual VistaModelo Obtener() => null;
        public virtual void Remover(IObjetoDatos modelo) { }
        #endregion


        #region Propiedades
        public PropiedadInfo Propiedad
        {
            get;
        }

        public Vista Vista
        {
            get;
        }
        #endregion

    }
}
