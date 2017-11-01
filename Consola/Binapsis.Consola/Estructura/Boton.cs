using Binapsis.Consola.Navegacion;
using Binapsis.Consola.Definicion;
using Binapsis.Consola.Controllers;

namespace Binapsis.Consola.Estructura
{
    public class Boton : ElementoMain
    {
        public Boton(Main main, Elemento elemento) 
            : base(main, elemento)
        {            
        }
        
        public AccionInfo AccionInfo
        {
            get;
            set;
        }

        public BotonController Controller
        {
            get;
            set;
        }
        
    }
}
