using System.Collections.Generic;
using System.Linq;
using Binapsis.Presentacion.MVVM.Definicion;
using Binapsis.Plataforma.Estructura;
using System.Collections;

namespace Binapsis.Presentacion.MVVM.Interno
{
    class VistaModeloColeccion : VistaModeloPropiedad, IEnumerable<VistaModelo>
    {
        List<VistaModelo> _items;

        public VistaModeloColeccion(Vista vista, PropiedadInfo propiedad) 
            : base(vista, propiedad)
        {
            _items = new List<VistaModelo>();
        }

        #region Metodos
        public override void Agregar(IObjetoDatos modelo)
        {
            Agregar(Crear(modelo));
        }

        public void Agregar(VistaModelo vistaModelo)
        {
            if (!_items.Contains(vistaModelo))
                _items.Add(vistaModelo);
        }
        
        public override VistaModelo Obtener(IObjetoDatos modelo)
        {
            return _items.FirstOrDefault(item => item.Modelo == modelo);
        }
        
        public override void Remover(IObjetoDatos modelo)
        {
            Remover(Obtener(modelo));            
        }

        public void Remover(VistaModelo vistaModelo)
        {
            if (vistaModelo == null) return;

            // obtner vista item
            VistaItem vistaItem = (vistaModelo.Vista as VistaItem);
            if (vistaItem == null) return;

            // remover en vista
            Vista.RemoverVista(Propiedad, vistaItem);

            // remover vistaModelo
            if (_items.Contains(vistaModelo))
                _items.Remove(vistaModelo);
        }
        #endregion


        #region IEnumerable
        public IEnumerator<VistaModelo> GetEnumerator()
        {
            return ((IEnumerable<VistaModelo>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<VistaModelo>)_items).GetEnumerator();
        }
        #endregion
    }
}
