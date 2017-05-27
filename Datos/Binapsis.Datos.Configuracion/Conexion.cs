using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Datos.Configuracion
{
    public class Conexion : ObjetoBase
    {
        public Conexion()
            : this(FabricaImpl.Instancia)
        {
        }

        public Conexion(IFabricaImpl impl)
            : base(impl.Crear(Types.Instancia.Obtener(typeof(Conexion))))
        {
        }
        
        public string Nombre
        {
			get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
		}

		public string CadenaConexion
        {
            get => ObtenerString("CadenaConexion");
            set => EstablecerString("CadenaConexion", value);
		}

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return Fabrica.Instancia.Crear(impl.Tipo);
        }
    }
}