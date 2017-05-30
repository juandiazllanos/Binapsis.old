using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion
{
    public class Relacion : ConfiguracionBase
    {
        public Relacion(IImplementacion impl)
            : base(impl)
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
    }
}