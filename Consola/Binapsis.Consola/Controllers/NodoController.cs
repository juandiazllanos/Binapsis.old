using Binapsis.Consola.Estructura;

namespace Binapsis.Consola.Controllers
{
    public class NodoController : ElementoController<Nodo>
    {
        public NodoController(Nodo nodo)
            : base(nodo)
        { 
        }

        public virtual void Seleccionar()
        {
            Pagina pagina = Main.Paginas[Elemento.Categoria];

            if (pagina == null)
                pagina = Main.Paginas.Crear(Elemento.Categoria);

            Tab tab = Main.Tabs[Elemento.Categoria];

            if (tab == null)
                tab = Main.Tabs.Crear(Elemento.Categoria);
        }
    }
}
