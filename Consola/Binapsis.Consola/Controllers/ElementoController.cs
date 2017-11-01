using Binapsis.Consola.Estructura;

namespace Binapsis.Consola.Controllers
{
    public class ElementoController<T> where T : ElementoMain
    {
        public ElementoController(T elementoMain)
        {
            Elemento = elementoMain;
            Main = elementoMain.Main;
        }

        protected T Elemento
        {
            get;
        }
        
        protected Main Main
        {
            get;
        }
    }
}
