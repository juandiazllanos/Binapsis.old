using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.MVVM.Mapeo;
using Binapsis.Presentacion.MVVM.Definicion;
using Binapsis.Presentacion.MVVM.VistaEditor;
using Binapsis.Presentacion.MVVM.Observable;
using System;
using Binapsis.Plataforma.Estructura;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM
{
    public class Vista
    {
        public Vista(MapeoTipo mapeo)
            : this(new VistaTipo(mapeo))
        {
        }
        
        internal Vista(VistaTipo vistaTipo)
        {
            VistaTipo = vistaTipo;
            Invocacion = new Invocacion(VistaTipo.InvocacionTipo);
        }
        
        public Vista CrearVista(string nombre)
        {
            if (TipoInfo != null)
                return CrearVista(TipoInfo[nombre]);
            else
                return null;
        }

        internal Vista CrearVista(PropiedadInfo propiedad)
        {
            Vista vista = null;
            VistaPropiedad vistaPropiedad = VistaTipo[propiedad];

            if (vistaPropiedad.GetType() == typeof(VistaReferencia))
                vista = CrearVista((VistaReferencia)vistaPropiedad);
            else if (vistaPropiedad.GetType() == typeof(VistaColeccion))
                vista = CrearVista((VistaColeccion)vistaPropiedad);

            return vista;
        }

        internal virtual Vista CrearVista(VistaReferencia vistaPropiedad)
        {
            VistaTipo vistaTipo = new VistaTipo(vistaPropiedad.MapeoReferencia);
            vistaTipo.Establecer(vistaPropiedad.Propiedad.TipoInfo);

            Vista vista = new Vista(vistaTipo);
            vistaPropiedad.Vista = vista;

            return vista;            
        }

        internal virtual Vista CrearVista(VistaColeccion vistaPropiedad)
        {
            VistaTipo vistaTipo = new VistaTipo(vistaPropiedad.MapeoReferencia);
            IEditorFila item = vistaPropiedad.Editor.Crear();

            vistaTipo.Establecer(vistaPropiedad.Propiedad.TipoInfo, item);
                        
            VistaItem vista = new VistaItem(vistaTipo, item);
            vistaPropiedad.Agregar(vista);

            return vista;
        }
        
        internal void Establecer(ITipo tipo, TypeInfo type)
        {
            TipoInfo tipoInfo = new TipoInfo();

            tipoInfo.Nombre = tipo?.Nombre ?? type?.Name;
            tipoInfo.Tipo = tipo;
            tipoInfo.Type = type;
            tipoInfo.UsarReflexion = VistaTipo.Mapeo.UsarReflexion;

            //Establecer(tipoInfo);

            VistaTipo.Establecer(tipoInfo);
        }

        //internal void Establecer(TipoInfo tipo)
        //{
        //    VistaTipo.Establecer(tipo);
        //}

        public void Establecer(string nombre, object valor)
        {
            if (TipoInfo != null)
                Establecer(TipoInfo[nombre], valor);
        }

        internal void Establecer(PropiedadInfo propiedad, object valor)
        {
            if (propiedad == null) return;

            VistaPropiedad vistaPropiedad = VistaTipo[propiedad];
            if (vistaPropiedad == null || vistaPropiedad.GetType() != typeof(VistaAtributo)) return;

            ((VistaAtributo)vistaPropiedad).Establecer(valor);
        }

        public void EstablecerVista(string nombre, Vista vista)
        {
            if (TipoInfo != null)
                EstablecerVista(TipoInfo[nombre], vista);
        }

        internal void EstablecerVista(PropiedadInfo propiedad, Vista vista)
        {
            VistaPropiedad vistaPropiedad = VistaTipo[propiedad];
            if (vistaPropiedad == null || vistaPropiedad.GetType() != typeof(VistaReferencia)) return;
            ((VistaReferencia)vistaPropiedad).Vista = vista;
        }


        public object Obtener(string nombre)
        {
            if (TipoInfo != null)
                return Obtener(TipoInfo[nombre]);
            else
                return null;
        }

        internal object Obtener(PropiedadInfo propiedad)
        {
            VistaPropiedad vistaPropiedad = VistaTipo[propiedad];
            if (vistaPropiedad == null || vistaPropiedad.GetType() != typeof(VistaAtributo)) return null;

            return ((VistaAtributo)vistaPropiedad).Obtener();
        }

        public Vista ObtenerVista(string nombre)
        {
            if (TipoInfo != null)
                return ObtenerVista(VistaTipo.Tipo[nombre]);
            else
                return null;
        }

        internal Vista ObtenerVista(PropiedadInfo propiedad)
        {
            VistaPropiedad vista = VistaTipo[propiedad];

            if (vista != null && vista.GetType() == typeof(VistaReferencia)) 
                return (vista as VistaReferencia).Vista;
            else
                return null;
        }
        
        internal void RemoverVista(PropiedadInfo propiedad, VistaItem item)
        {
            VistaPropiedad vista = VistaTipo[propiedad];
            
            if (vista != null && vista.GetType() == typeof(VistaColeccion))
                (vista as VistaColeccion).Remover(item);            
        }

        #region Propiedades
        internal Invocacion Invocacion
        {
            get;
        }

        internal ObservableVista Observable
        {
            get => VistaTipo.Observable;
        }
        
        private VistaTipo VistaTipo
        {
            get;
        }

        internal TipoInfo TipoInfo
        {
            get => VistaTipo?.Tipo;
        }
        #endregion
    }
}
