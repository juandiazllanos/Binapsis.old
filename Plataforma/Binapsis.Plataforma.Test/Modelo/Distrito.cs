using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test.Modelo
{
    class Distrito : ObjetoId
    {
        public Distrito(IImplementacion impl) 
            : base(impl)
        {
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
        }
    }
}
