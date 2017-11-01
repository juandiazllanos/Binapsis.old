using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Cambios.Impl
{
    public class ObjetoCambios : ObjetoDatos, IObjetoCambios
    {
        #region Constructores
        public ObjetoCambios(ITipo tipo)
            : this(new FabricaImpl().Crear(tipo))
        {
        }

        public ObjetoCambios(IImplementacion impl) 
            : base(impl)
        {
            Cambio = Cambio.Ninguno;
        }
        #endregion


        #region Metodos
        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return new ObjetoCambios(impl) { Cambio = Cambio };
        }

        private IObjetoDatos ObtenerPropietario()
        {
            return null;
        }

        private IObjetoDatos ObtenerPropietarioAntiguo()
        {
            if (Cambio == Cambio.Creado) return null;

            IObjetoDatos propietario = base.Propietario;

            if (propietario is ObjetoCambios propietarioCambios &&
                propietarioCambios.Cambio == Cambio.Modificado)
                return propietarioCambios.ObtenerObjetoDatosReferencia();
            else
                return propietario;
            
        }

        internal IObjetoDatos ObtenerObjetoDatosReferencia()
        {
            if (!string.IsNullOrEmpty(Referencia))
                return ResumenCambios?.DiagramaDatos.ObjetoDatos.ObtenerObjetoDatos(Referencia);
            else if (base.Propietario == null)
                return ResumenCambios?.DiagramaDatos.ObjetoDatos;
            else
                return null;
        }
        #endregion


        #region Propiedades
        public Cambio Cambio
        {
            get;
            set;
        }

        public new IObjetoDatos Propietario
        {
            get => ObtenerPropietario();
        }

        public IObjetoDatos PropietarioAntiguo
        {
            get => ObtenerPropietarioAntiguo();
        }

        public string Referencia
        {
            get;
            set;
        }

        public ResumenCambios ResumenCambios
        {
            get;
            internal set;
        }
        #endregion

    }
}
