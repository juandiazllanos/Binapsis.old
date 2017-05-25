using Binapsis.Presentacion.MVVM.Mapeo;
using Binapsis.Presentacion.MVVM.Observable;
using System.Collections.Generic;

namespace Binapsis.Presentacion.MVVM.InvocacionEditor
{
    class InvocacionTipo
    {
        List<InvocacionComando> _invocaciones;

        public InvocacionTipo(MapeoTipo mapeo)
        {
            _invocaciones = new List<InvocacionComando>();

            Mapeo = mapeo;
            Observable = new ObservableInvocacion();

            Construir();
        }

        private void Construir()
        {
            foreach (MapeoComando mapeoItem in Mapeo.Comandos)
                Agregar(mapeoItem);
        }

        private void Agregar(MapeoComando mapeoItem)
        {            
            _invocaciones.Add(new InvocacionComando(this, 
                mapeoItem.Nombre, 
                mapeoItem.Comando, 
                mapeoItem.Invocador));
        }

        public void Notificar(InvocacionComando item)
        {
            Observable.Notificar(item.Nombre);
        }

        #region Propiedades
        public IEnumerable<InvocacionComando> Invocaciones
        {
            get => _invocaciones;
        }

        public ObservableInvocacion Observable
        {
            get;
        }

        public MapeoTipo Mapeo
        {
            get;
        }
        #endregion
    }
}
