using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion
{
	public class Columna : ConfiguracionBase
    {
        public Columna(IImplementacion impl) 
            : base(impl)
        {
        }

        public bool ClavePrimaria
        {
            get => ObtenerBoolean("ClavePrincipal");
            set => EstablecerBoolean("ClavePrincipal", value);
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

    }
}