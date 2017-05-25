using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Builder;
using Binapsis.Presentacion.MVVM.Controlador;
using Binapsis.Presentacion.MVVM.Definicion;
using Binapsis.Presentacion.MVVM.Interno;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM
{
    public class VistaModelo
    {
        ControladorVistaModelo _controlador;
        VistaModeloTipo _contenido;
        InvocacionModelo _invocacion;

        #region Constructor
        public VistaModelo(Vista vista)
        {
            Vista = vista;
            _contenido = new VistaModeloTipo(Vista);
            _controlador = new ControladorVistaModelo();
            _invocacion = new InvocacionModelo(Vista.Invocacion);
        }
        #endregion


        #region Metodos internos
        internal void AgregarVistaModelo(PropiedadInfo propiedad, IObjetoDatos modelo)
        {
            _contenido.Agregar(propiedad, modelo);
        }
        
        internal void EstablecerVistaModelo(PropiedadInfo propiedad, IObjetoDatos modelo)
        {
            _contenido.Establecer(propiedad, modelo);            
        }
        
        internal VistaModelo ObtenerVistaModelo(PropiedadInfo propiedad)
        {
            return _contenido.Obtener(propiedad);
        }

        internal VistaModelo ObtenerVistaModelo(PropiedadInfo propiedad, IObjetoDatos modelo)
        {
            return _contenido.Obtener(propiedad, modelo);
        }
                
        internal void RemoverVistaModelo(PropiedadInfo propiedad, IObjetoDatos modelo)
        {
            _contenido.Remover(propiedad, modelo);
        }
        #endregion


        #region Metodos publicos
        public void Establecer(IObjetoDatos modelo)
        {
            if (modelo == Modelo) return;

            // establecer modelo
            Modelo = modelo;
            
            // resolver el tipo de la vista
            ResolverTipo();

            // establecer modelo en controlador
            _controlador.Establecer(this);

            // construir vista modelo (referencias)
            BuilderVistaModelo builder = new BuilderVistaModelo(this);
            builder.Construir();

            // actualizar la vista
            ActualizarVista();
            
            // establecer modelo en invocacion
            _invocacion.Establecer(modelo);
        }

        private void ResolverTipo()
        {
            if (TipoInfo != null || Modelo == null) return;

            ITipo tipo = Modelo.Tipo;
            TypeInfo type = Modelo.GetType().GetTypeInfo();

            Vista.Establecer(tipo, type);

            //TipoInfo tipoInfo = new TipoInfo();

            //tipoInfo.Nombre = Modelo.Tipo.Nombre;
            //tipoInfo.Tipo = Modelo.Tipo;
            //tipoInfo.Type = Modelo.GetType().GetTypeInfo();
            
            //Vista.Establecer(tipoInfo);
        }
                
        public void ActualizarModelo()
        {
                
        }

        public void ActualizarVista()
        {
            foreach (PropiedadInfo propiedad in TipoInfo.Propiedades)
                ActualizarVista(propiedad);
        }

        public void ActualizarVista(string nombre)
        {
            PropiedadInfo propiedad = Vista.TipoInfo[nombre];
            if (propiedad == null) return;

            ActualizarVista(propiedad);
        }

        internal void ActualizarVista(PropiedadInfo propiedad)
        {
            if (propiedad.TipoInfo.EsTipoDeDato)
                _controlador.ActualizarVista(propiedad);
            else if (!propiedad.EsColeccion && _contenido.Existe(propiedad))
                _contenido.Obtener(propiedad).ActualizarVista();
            else if (propiedad.EsColeccion && _contenido.Existe(propiedad))
                foreach (VistaModelo vistaModelo in _contenido.ObtenerColeccion(propiedad))
                    vistaModelo.ActualizarVista();
        }

        
        public virtual void Controlar(IObjetoDatos objeto, string propiedad)
        {

        }

        public virtual void ControlarAgregar(IObjetoDatos objeto, string propiedad, IObjetoDatos item)
        {

        }

        public virtual void ControlarRemover(IObjetoDatos objeto, string propiedad, IObjetoDatos item)
        {

        }
        #endregion


        #region Propiedades
        public Vista Vista
        {
            get;
        }

        public IObjetoDatos Modelo
        {
            get;
            private set;
        }

        internal TipoInfo TipoInfo
        {
            get => Vista.TipoInfo;            
        }
        #endregion
    }
}
