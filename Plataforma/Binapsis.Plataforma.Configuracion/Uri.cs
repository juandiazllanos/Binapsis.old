using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class Uri : ConfiguracionBase
    {
        public Uri() 
            : base(typeof(Uri))
        {
        }

        //public Uri(IFabricaImpl impl)
        //    : base(typeof(Uri), impl)
        //{
        //}

        public Uri(IImplementacion impl) 
            : base(impl)
        {
        }

        public Ensamblado Ensamblado
        {
            get => (Ensamblado)ObtenerObjetoDatos("Ensamblado");
            set => EstablecerObjetoDatos("Ensamblado", value);
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
        }
    }
}
