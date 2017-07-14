using Binapsis.Plataforma.Estructura;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion
{
    public class Tabla : ConfiguracionBase
    {
        public Tabla(IImplementacion impl)
            : base(impl)
        {
        }
        
        public Columna CrearColumna()
        {
            return (Columna)CrearObjetoDatos("Columnas");
        }

        public bool ContieneColumna(string columna)
        {
            return Columnas.Cast<Columna>().FirstOrDefault(item => item.Nombre == columna) != null;
        }

        public Columna ObtenerColumna(string columna)
        {
            return Columnas.Cast<Columna>().FirstOrDefault(item => item.Nombre == columna);
        }

        public void RemoverColumna(string columna)
        {
            Columna item = ObtenerColumna(columna);
            if (item != null)
                RemoverObjetoDatos("Columnas", item);
        }

        public IColeccion Columnas
        {
            get => ObtenerColeccion("Columnas");
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
		}

        public string TipoAsociado
        {
            get => ObtenerString("Tipo");
            set => EstablecerString("Tipo", value);
        }

    }
}