using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Datos.Configuracion
{
    public class Relacion : ObjetoBase
    {
		public Relacion()
            : this(FabricaImpl.Instancia)
        {
		}
        
        public Relacion(IFabricaImpl impl)
            : base(impl.Crear(Types.Instancia.Obtener(typeof(Relacion))))
        {
        }

		public string ColumnaPrincipal
        {
            get => ObtenerString("ColumnaPrincipal");
            set => EstablecerString("ColumnaPrincipal", value);
		}

		public string ColumnaSecundaria
        {
            get => ObtenerString("ColumnaSecundaria");
            set => EstablecerString("ColumnaSecundaria", value);
		}

		public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
		}

        public string Propiedad
        {
            get => ObtenerString("Propiedad");
            set => EstablecerString("Propiedad", value);
        }

        public string TablaPrincipal
        {
            get => ObtenerString("TablaPrincipal");
            set => EstablecerString("TablaPrincipal", value);
        }

        public string TablaSecundaria
        {
            get => ObtenerString("TablaSecundaria");
            set => EstablecerString("TablaSecundaria", value);
        }

        public string TipoAsociado
        {
            get => ObtenerString("Tipo");
            set => EstablecerString("Tipo", value);
        }

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return Fabrica.Instancia.Crear(impl);
        }
    }
}