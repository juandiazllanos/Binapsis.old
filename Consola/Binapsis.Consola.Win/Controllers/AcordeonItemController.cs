using Binapsis.Consola.Controllers;
using Binapsis.Consola.Estructura;
using Binapsis.Consola.Navegacion;
using Binapsis.Consola.Win.Vistas;
using DevExpress.XtraBars.Navigation;

namespace Binapsis.Consola.Win.Controllers
{
    public class AcordeonItemController : NodoController
    {
        bool _seleccionando;

        public AcordeonItemController(Nodo nodo, AccordionControlElement acordeonItem) 
            : base(nodo)
        {
            AcordeonItem = acordeonItem;
            AcordeonItem.Click += (s, e) => Seleccionar();
        }

        public override void Seleccionar()
        {
            if (_seleccionando) return;

            _seleccionando = true;

            try
            {
                base.Seleccionar();

                if (AcordeonItem.AccordionControl.SelectedElement != AcordeonItem)
                    AcordeonItem.AccordionControl.SelectedElement = AcordeonItem;

                Pagina pagina = Main.Paginas[Elemento.Categoria];
                VistaController vistaController = pagina?.Controller as VistaController;

                if (vistaController == null && pagina != null)
                    pagina.Controller = vistaController = new VistaController(pagina, CrearVista(pagina));

                Tab tab = Main.Tabs[Elemento.Categoria];
                TabController tabController = tab?.Controller;

                if (tabController == null)
                    tab.Controller = tabController = new ChildController(tab, CrearChild(vistaController.Vista));

                pagina.Controller.Activar();
                tab.Controller.Activar();
            }
            finally
            {
                _seleccionando = false;
            }
        }

        private VistaBase CrearVista(Pagina pagina)
        {
            Contenido contenido = pagina.CrearContenido();
            VistaBase vista = new VistaGrid();
            Grid grid = contenido as Grid;
                
            vista.EstablecerContenido(grid);
            vista.Imagen = Main.Galeria.Obtener(new Ruta(Elemento.Categoria.Padre).ToString(), Elemento.Categoria.Nombre, 16);
            vista.Name = Elemento.Categoria.Nombre;

            return vista;
        }

        private WinChild CrearChild(VistaBase vista)
        {
            WinChild child = new WinChild();
            child.Establecer(vista);
            child.MdiParent = AcordeonItem.AccordionControl.FindForm();
            child.Text = vista.Name;
            
            return child;
        }

        public AccordionControlElement AcordeonItem
        {
            get;
        }
        
    }
}
