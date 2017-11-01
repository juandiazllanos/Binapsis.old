using Binapsis.Consola.Estructura;

namespace Binapsis.Consola.Controllers
{
    public class TabController : ElementoController<Tab>
    {        
        public TabController(Tab tab)
            : base(tab)
        {
        }

        public virtual void Activar()
        {
            Main.Nodos[Elemento.Categoria]?.Controller?.Seleccionar();

            //Pagina pagina = Main.Paginas[Elemento.Categoria];

            //if (pagina != null)
            //    pagina.Controller?.Activar();
        }

        public void Cerrar()
        {
            Pagina pagina = Main.Paginas[Elemento.Categoria];

            if (pagina != null)
                pagina.Controller?.Cerrar();

            Main.Tabs.Remover(Elemento.Categoria);
        }        
    }
}
