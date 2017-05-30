using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class Definicion : ConfiguracionBase
    {
        public Definicion()
            : base(typeof(Definicion))
        {
        }
        
        public Definicion(IImplementacion impl) 
            : base(impl)
        {
        }

        #region Metodos
        public Definicion CrearDefinicion()
        {
            return (Definicion)CrearObjetoDatos("Definiciones");
        }
        #endregion

        #region Propiedades
        public string Alias
        {
            get => ObtenerString("Alias"); 
            set => EstablecerString("Alias", value); 
        }

        public IColeccion Definiciones
        {
            get => ObtenerColeccion("Definiciones"); 
        }

        public string Nombre
        {
            get => ObtenerString("Nombre"); 
            set => EstablecerString("Nombre", value); 
        }

        public string Valor
        {
            get => ObtenerString("Valor"); 
            set => EstablecerString("Valor", value); 
        }
        #endregion

    }
}
