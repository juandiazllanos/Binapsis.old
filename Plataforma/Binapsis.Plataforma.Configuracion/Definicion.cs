using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class Definicion : ObjetoBase
    {
        public Definicion(IImplementacion impl) 
            : base(impl)
        {
        }

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return FabricaConfiguracion.Instancia.Crear(impl);
        }

        public Definicion CrearDefinicion()
        {
            return (Definicion)CrearObjetoDatos("Definiciones");
        }

        public string Alias
        {
            get { return ObtenerString("Alias"); }
            set { EstablecerString("Alias", value); }
        }

        public IColeccion Definiciones
        {
            get { return ObtenerColeccion("Definiciones"); }
        }

        public string Nombre
        {
            get { return ObtenerString("Nombre"); }
            set { EstablecerString("Nombre", value); }
        }

        public string Valor
        {
            get { return ObtenerString("Valor"); }
            set { EstablecerString("Valor", value); }
        }

    }
}
