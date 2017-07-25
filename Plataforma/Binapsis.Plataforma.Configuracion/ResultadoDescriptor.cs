using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class ResultadoDescriptor : ConfiguracionBase
    {
        public ResultadoDescriptor(IImplementacion impl) 
            : base(impl)
        {
        }
        
        public string Columna
        {
            get => ObtenerString("Columna");
            set => EstablecerString("Columna", value);
        }

        public int Indice
        {
            get => ObtenerInteger("Indice");
            set => EstablecerInteger("Indice", value);
        }

        public string Nombre
        {
            get;
            set;
        }

        public string Tabla
        {
            get => ObtenerString("Tabla");
            set => EstablecerString("Tabla", value);
        }

        public string TipoDato
        {
            get => ObtenerString("Tipo");
            set => EstablecerString("Tipo", value);
        }
    }
}
