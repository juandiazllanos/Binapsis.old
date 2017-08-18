using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class Parametro : ConfiguracionBase
    {
        public Parametro(IImplementacion impl) 
            : base(impl)
        {
        }

        public string Direccion
        {
            get => ObtenerString("Direccion");
            set => EstablecerString("Direccion", value);
        }

        public int Indice
        {
            get => ObtenerInteger("Indice");
            set => EstablecerInteger("Indice", value);
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
        }

        public int Longitud
        {
            get => ObtenerInteger("Longitud");
            set => EstablecerInteger("Longitud", value);
        }

        public string TipoDato
        {
            get => ObtenerString("Tipo");
            set => EstablecerString("Tipo", value);
        }

    }
}
