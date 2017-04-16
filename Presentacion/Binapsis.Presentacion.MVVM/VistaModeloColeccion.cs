using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System;

namespace Binapsis.Presentacion.MVVM
{
    internal class VistaModeloColeccion : VistaModeloPropiedad
    {
        Dictionary<IObjetoDatos, VistaModelo> _items;

        public VistaModeloColeccion(VistaModelo vistaModelo, IPropiedad propiedad) 
            : base(vistaModelo, propiedad)
        {
            _items = new Dictionary<IObjetoDatos, VistaModelo>();
        }
        
        protected override void Crear(VistaModelo vistaModelo)
        {
            if (_items.ContainsKey(vistaModelo.Modelo)) return;
            _items.Add(vistaModelo.Modelo, vistaModelo);
        }

        public override void Eliminar()
        {
            
        }

        public override void Eliminar(IObjetoDatos modelo)
        {
            if (!_items.ContainsKey(modelo)) return;
            Eliminar(_items[modelo]);
            _items.Remove(modelo);
        }

        public override void EliminarTodo()
        {
            foreach (VistaModelo item in _items.Values)
                Eliminar(item);

            _items.Clear();
        }

        public override VistaModelo Obtener()
        {
            return null;
        }

        public override VistaModelo Obtener(IObjetoDatos modelo)
        {
            if (!_items.ContainsKey(modelo)) return null;
            return _items[modelo];
        }

        public VistaModelo this[IObjetoDatos modelo]
        {
            get { return Obtener(modelo); }
        }
        
    }
}
