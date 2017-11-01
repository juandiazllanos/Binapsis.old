using Binapsis.Consola.Controllers;
using Binapsis.Consola.Definicion;
using Binapsis.Consola.Estructura;
using Binapsis.Consola.Win.Vistas;
using DevExpress.XtraBars;
using System.Drawing;
using System.Linq;

namespace Binapsis.Consola.Win.Controllers
{
    public class VistaController : PaginaController
    {
        PopupMenu _menu;

        public VistaController(Pagina pagina, VistaBase vista) 
            : base(pagina)
        {   
            Vista = vista;            

            // asignar controlador
            Vista.MouseClickDerecho += (p) => MostrarMenu(p);
        }

        public override void Mostrar()
        {
            Vista.Actualizar();
        }

        private void MostrarMenu(Point p)
        {
            if (_menu == null)
                ConstruirMenu();

            _menu.ShowPopup(p);
        }

        private void ConstruirMenu()
        {
            WinMain winMain = (Vista.FindForm() as WinChild).MdiParent as WinMain;
            _menu = new PopupMenu();

            foreach (AccionModeloInfo accionModeloInfo in Elemento.ModeloInfo.Acciones)
                ConstruirMenu(_menu, accionModeloInfo.AccionInfo);

            _menu.Manager = winMain?.BarManager;
        }

        private void ConstruirMenu(PopupMenu menu, AccionInfo accionInfo)
        {
            Boton boton = Main.Botones.FirstOrDefault(item => item.AccionInfo == accionInfo);
            BarButtonItem buttonItem = (boton.Controller as ButtonItemController)?.ButtonItem;

            if (buttonItem != null)
                menu.AddItem(buttonItem);
        }
        
        #region Propiedades
        public override object[] ItemSeleccionado
        {
            get => Vista.ItemSeleccionado;
        }

        public VistaBase Vista
        {
            get;
        }
        #endregion
    }
}
