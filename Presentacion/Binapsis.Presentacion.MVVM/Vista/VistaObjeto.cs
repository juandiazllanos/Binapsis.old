using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.MVVM.Mapeo;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM.Vista
{
	public class VistaObjeto 
    {		
        ITipo _tipo;
		MapeoTipo _mapeo;
		ObservableVista _observable;
        List<VistaPropiedad> _propiedades;

        public VistaObjeto(ITipo tipo, MapeoTipo mapeo)
        {
            _tipo = tipo;
            _mapeo = mapeo;
            _propiedades = new List<VistaPropiedad>();
            _observable = new ObservableVista();

            Construir();
		}

        protected virtual void Construir()
        {
            foreach (MapeoPropiedad mapeo in _mapeo.Propiedades)
                Agregar(mapeo);
        }
        
        private void Agregar(MapeoPropiedad mapeo)
        {
            IPropiedad propiedad = _tipo.ObtenerPropiedad(mapeo.Nombre);
            
            VistaPropiedad vistaPropiedad = null;

            if (mapeo.GetType() == typeof(MapeoReferencia) || mapeo.GetType().GetTypeInfo().IsSubclassOf(typeof(MapeoReferencia)))
                vistaPropiedad = Crear(propiedad, ((MapeoReferencia)mapeo).Mapeo, mapeo.Editor);
            else
                vistaPropiedad = Crear(propiedad, mapeo.Editor);

            if (vistaPropiedad == null) return;

            _propiedades.Add(vistaPropiedad);
        }

        private VistaPropiedad Crear(IPropiedad propiedad, IEditor editor)
        {
            return Crear(propiedad, null, editor);
        }

        private VistaPropiedad Crear(IPropiedad propiedad, MapeoTipo mapeo, IEditor editor)
        {
            if (editor == null && mapeo == null) return null;

            if (editor == null)
                return Crear(propiedad, mapeo);
            else if (typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(editor.GetType().GetTypeInfo()))
                return Crear(propiedad, (IEditorAtributo)editor);
            else if (typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(editor.GetType().GetTypeInfo()))
                return Crear(propiedad, (IEditorColumna)editor);
            else if (typeof(IEditorColeccion).GetTypeInfo().IsAssignableFrom(editor.GetType().GetTypeInfo()) && mapeo != null)
                return Crear(propiedad, mapeo, (IEditorColeccion)editor);
            else
                return null;
        }

        protected virtual VistaPropiedad Crear(IPropiedad propiedad, IEditorAtributo editor)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                return new VistaAtributo(this, propiedad, editor);
            else
                return null;
        }
        
        protected virtual VistaPropiedad Crear(IPropiedad propiedad, IEditorColumna editor)
        {
            return null;
        }

        protected virtual VistaPropiedad Crear(IPropiedad propiedad, MapeoTipo mapeo)
        {
            if (!propiedad.Tipo.EsTipoDeDato)
                return new VistaReferencia(this, propiedad, mapeo);
            else
                return null;
        }

        protected virtual VistaPropiedad Crear(IPropiedad propiedad, MapeoTipo mapeo, IEditorColeccion editor)
        {
            if (propiedad.EsColeccion)
                return new VistaColeccion(this, propiedad, mapeo, editor);
            else
                return null;
        }

        public VistaObjeto CrearVista(IPropiedad propiedad)
        {
            VistaObjeto vista = null;

            if (propiedad.EsColeccion)
                vista = _propiedades.OfType<VistaColeccion>().Where((item) => item.Propiedad == propiedad).FirstOrDefault()?.Crear();
            else if (!propiedad.Tipo.EsTipoDeDato)
                vista = _propiedades.OfType<VistaReferencia>().Where((item => item.Propiedad == propiedad)).FirstOrDefault()?.Crear();
                        
            return vista;
        }

        public void EliminarVista(IPropiedad propiedad)
        {
            EliminarVista(propiedad, null);
        }

        public void EliminarVista(IPropiedad propiedad, VistaObjeto vista)
        {
            if (propiedad.EsColeccion && vista != null && vista.GetType() == typeof(VistaFila))
                _propiedades.OfType<VistaColeccion>().Where((item) => item.Propiedad == propiedad).FirstOrDefault()?.Remover((VistaFila)vista);
            else if (!propiedad.EsColeccion)
                _propiedades.OfType<VistaReferencia>().Where((item) => item.Propiedad == propiedad).FirstOrDefault()?.Eliminar();            
        }
        
        public void Establecer(IPropiedad propiedad, object valor)
        {   
            foreach (VistaAtributo vistaAtributo in _propiedades.OfType<VistaAtributo>().Where((item) => item.Propiedad == propiedad))
                vistaAtributo.Establecer(valor);
        }

        internal void Notificar(VistaPropiedad vista)
        {
            Observable.Notificar(vista.Propiedad);
        }
        
		public object Obtener(IPropiedad propiedad)
        {
            return _propiedades.OfType<VistaAtributo>().Where((item) => item.Propiedad == propiedad).FirstOrDefault()?.Obtener();            
		}
        
        public void Liberar()
        {
            _propiedades.ForEach((item) => item.Liberar());
        }

        public MapeoTipo Mapeo
        {
            get { return _mapeo; }
        }

        internal ObservableVista Observable
        {
            get { return _observable; }
        }

        public ITipo Tipo
        {
            get { return _tipo; }
        }

        public IEnumerable<VistaPropiedad> VistaPropiedad
        {
            get { return _propiedades; }
        }
        
    }

}