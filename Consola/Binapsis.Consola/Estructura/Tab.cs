using Binapsis.Consola.Controllers;
using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Estructura
{
    public class Tab : ElementoMain
    {
        public Tab(Main main, Categoria categoria) 
            : base(main, categoria)
        {
        }

        public Categoria Categoria
        {
            get => Elemento as Categoria;
        }

        public TabController Controller
        {
            get;
            set;
        }
        
    }
}
