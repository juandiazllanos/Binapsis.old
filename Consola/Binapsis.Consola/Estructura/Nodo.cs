using Binapsis.Consola.Controllers;
using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Estructura
{
    public class Nodo : ElementoMain
    {
        public Nodo(Main main, Categoria categoria) 
            : base(main, categoria)
        {
        }

        public Categoria Categoria
        {
            get => Elemento as Categoria;
        }

        public NodoController Controller
        {
            get;
            set;
        }
    }
}
