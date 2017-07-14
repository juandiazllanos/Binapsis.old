using Binapsis.Plataforma.Estructura;

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
            set
            {
                EstablecerString("ColumnaPrincipal", value);
                EstablecerNombre();
            }
		}

		public string ColumnaSecundaria
        {
            get => ObtenerString("ColumnaSecundaria");
            set
            {
                EstablecerString("ColumnaSecundaria", value);
                EstablecerNombre();
            }
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
            set
            {
                EstablecerString("TablaPrincipal", value);
                EstablecerNombre();
            }
        }

        public string TablaSecundaria
        {
            get => ObtenerString("TablaSecundaria");
            set
            {
                EstablecerString("TablaSecundaria", value);
                EstablecerNombre();
            }
        }

        public string TipoAsociado
        {
            get => ObtenerString("Tipo");
            set => EstablecerString("Tipo", value);
        }     
        
        private void EstablecerNombre()
        {
            Nombre = $"{TablaSecundaria}_{ColumnaSecundaria?.Replace(" ", "_")}=>{TablaPrincipal}_{ColumnaPrincipal?.Replace(" ", "_")}";
        }
    }
}