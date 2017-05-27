using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Datos.Configuracion
{
	public class Columna : ObjetoBase
    {
        public Columna()
            : this(FabricaImpl.Instancia)
        {
        }

        public Columna(IFabricaImpl impl)
            : base(impl.Crear(Types.Instancia.Obtener(typeof(Tabla))))
        {
        }

        public bool ClavePrimaria
        {
            get => ObtenerBoolean("ClavePrimaria");
            set => EstablecerBoolean("ClavePrimaria", value);
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

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return Fabrica.Instancia.Crear(impl);
        }
    }
}