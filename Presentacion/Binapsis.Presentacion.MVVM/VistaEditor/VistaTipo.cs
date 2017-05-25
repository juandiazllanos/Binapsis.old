using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.MVVM.InvocacionEditor;
using Binapsis.Presentacion.MVVM.Mapeo;
using Binapsis.Presentacion.MVVM.Definicion;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Binapsis.Presentacion.MVVM.Observable;

namespace Binapsis.Presentacion.MVVM.VistaEditor
{
    internal class VistaTipo 
    {   
        List<VistaPropiedad> _propiedades;
                
        public VistaTipo(MapeoTipo mapeo)
        {
            _propiedades = new List<VistaPropiedad>();

            Mapeo = mapeo;
            Observable = new ObservableVista();
            InvocacionTipo = new InvocacionTipo(mapeo);
        }
        
        public void Establecer(TipoInfo tipo)
        {
            Establecer(tipo, null);
        }

        public void Establecer(TipoInfo tipo, IEditorFila item)
        {
            Tipo = tipo;
            Construir(item);
        }

        internal void Notificar(VistaAtributo vistaAtributo)
        {
            Observable?.Notificar(vistaAtributo.Propiedad);
        }

        protected virtual void Construir(IEditorFila item)
        {
            _propiedades.Clear();

            if (Mapeo == null) return;

            foreach (MapeoPropiedad mapeo in Mapeo.Propiedades)
                Agregar(mapeo, item);            
        }

        private void Agregar(MapeoPropiedad mapeo, IEditorFila item)
        {
            PropiedadInfo propiedad = Tipo.CrearPropiedad(mapeo.Propiedad.Nombre, mapeo.Propiedad.UsarReflexion);
            VistaPropiedad vistaPropiedad = null;
            IEditor editor = null;

            // verificar la propiedad mapeada
            if (propiedad == null) return;

            editor = mapeo.Editor;

            if (item != null && editor != null && typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(editor.GetType().GetTypeInfo()))
                editor = item.Crear((IEditorColumna)editor);

            if (mapeo.GetType() == typeof(MapeoReferencia) || mapeo.GetType().GetTypeInfo().IsSubclassOf(typeof(MapeoReferencia)))
                vistaPropiedad = Crear(propiedad, ((MapeoReferencia)mapeo).Mapeo, editor);
            else
                vistaPropiedad = Crear(propiedad, editor);

            if (vistaPropiedad == null) return;

            _propiedades.Add(vistaPropiedad);
        }
        
        private VistaPropiedad Crear(PropiedadInfo propiedad, IEditor editor)
        {
            return Crear(propiedad, null, editor);
        }

        private VistaPropiedad Crear(PropiedadInfo propiedad, MapeoTipo mapeo, IEditor editor)
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

        protected virtual VistaPropiedad Crear(PropiedadInfo propiedad, IEditorAtributo editor)
        {
            if (propiedad.TipoInfo.EsTipoDeDato)
                return new VistaAtributo(this, editor) { Propiedad = propiedad };
            else
                return null;
        }

        protected virtual VistaPropiedad Crear(PropiedadInfo propiedad, IEditorColumna editor)
        {
            return null;
        }

        protected virtual VistaPropiedad Crear(PropiedadInfo propiedad, MapeoTipo mapeo)
        {
            if (!propiedad.TipoInfo.EsTipoDeDato)
                return new VistaReferencia(this) { Propiedad = propiedad, MapeoReferencia = mapeo };
            else
                return null;
        }

        protected virtual VistaPropiedad Crear(PropiedadInfo propiedad, MapeoTipo mapeo, IEditorColeccion editor)
        {
            if (propiedad.EsColeccion)
                return new VistaColeccion(this, editor) { Propiedad = propiedad, MapeoReferencia = mapeo };
            else
                return null;
        }

        private VistaPropiedad Obtener(string nombre)
        {
            return Obtener(Tipo[nombre]);
        }

        public VistaPropiedad Obtener(PropiedadInfo propiedad)
        {
            return _propiedades.Where(item => item.Propiedad == propiedad).FirstOrDefault();
        }


        #region Propiedades
        public InvocacionTipo InvocacionTipo
        {
            get;
            private set;
        }

        public MapeoTipo Mapeo
        {
            get;
            private set;
        }

        public ObservableVista Observable
        {
            get;
        }

        public IReadOnlyList<VistaPropiedad> Propiedades
        {
            get => _propiedades;
        }

        public VistaPropiedad this[string nombre]
        {
            get => Obtener(nombre);
        }

        public VistaPropiedad this[PropiedadInfo propiedad]
        {
            get => Obtener(propiedad);
        }
        
        public TipoInfo Tipo
        {
            get;
            private set;
        }
        #endregion

    }
}
