using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Estructura
{
    public class ElementoMain
    {
        public ElementoMain(Main main, Elemento elemento)
        {
            Main = main;
            Elemento = elemento;
        }
        
        protected Elemento Elemento
        {
            get;
        }

        public Main Main
        {
            get;
        }
        
    }
}
