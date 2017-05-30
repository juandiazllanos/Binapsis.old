using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion
{
    public class Conexion : ConfiguracionBase
    {
        public Conexion(IImplementacion impl)
            : base(impl)
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
    }
}