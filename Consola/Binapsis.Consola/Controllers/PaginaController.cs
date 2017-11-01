using Binapsis.Consola.Estructura;

namespace Binapsis.Consola.Controllers
{
    public class PaginaController : ElementoController<Pagina>
    {
        public PaginaController(Pagina pagina)
            : base(pagina)
        {
        }

        #region Metodos
        public virtual void Activar()
        {
            Tab tab = Main.Tabs[Elemento.Categoria];

            if (tab == null)
                tab = Main.Tabs.Crear(Elemento.Categoria);
            
            Main.PaginaActual = Elemento;
        }

        public virtual void Cerrar()
        {
            // establecer pagina actual
            if (Main.PaginaActual == Elemento)
                Main.PaginaActual = null;

            // eliminar pagina
            Main.Paginas.Remover(Elemento.Categoria);
        }

        public virtual void Mostrar()
        {

        }
        #endregion

        #region Propiedades
        public virtual object[] ItemSeleccionado
        {
            get;
        }
        #endregion

    }
}
