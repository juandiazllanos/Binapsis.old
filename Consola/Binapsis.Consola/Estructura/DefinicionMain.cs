using Binapsis.Consola.Definicion;

namespace Binapsis.Consola.Estructura
{
    public class DefinicionMain
    {
        public DefinicionMain(Main main, DefinicionBase definicion)
        {
            Definicion = definicion;
            Main = main;
        }

        protected DefinicionBase Definicion
        {
            get;
        }

        public Main Main
        {
            get;
        }
    }
}
