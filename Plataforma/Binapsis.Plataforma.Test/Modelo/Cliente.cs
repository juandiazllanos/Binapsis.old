using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test.Modelo
{
    public class Cliente : ObjetoId
    {
        protected internal Cliente(IImplementacion impl) 
            : base(impl)
        {
        }
        
        public string Nombres
        {
            get => ObtenerString("Nombres");
            set => EstablecerString("Nombres", value);
        }
    }
}
