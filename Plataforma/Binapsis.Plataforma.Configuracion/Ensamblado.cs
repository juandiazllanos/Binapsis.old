using Binapsis.Plataforma.Estructura;


namespace Binapsis.Plataforma.Configuracion
{
    public class Ensamblado : ConfiguracionBase
    {
        public Ensamblado() 
            : base(typeof(Ensamblado))
        {
        }
        
        public Ensamblado(IImplementacion impl) 
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
