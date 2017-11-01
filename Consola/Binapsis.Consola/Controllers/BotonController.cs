using Binapsis.Consola.Estructura;

namespace Binapsis.Consola.Controllers
{
    public class BotonController : ElementoController<Boton>
    {
        Boton _boton;
                
        public BotonController(Boton boton) 
            : base(boton)
        {
        }

        public virtual void Click()
        {

        }        

        public Boton Boton
        {
            get => Elemento as Boton;
        }
    }
}
