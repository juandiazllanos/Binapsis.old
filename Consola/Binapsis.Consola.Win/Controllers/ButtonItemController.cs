using Binapsis.Consola.Controllers;
using Binapsis.Consola.Estructura;
using DevExpress.XtraBars;

namespace Binapsis.Consola.Win.Controllers
{
    class ButtonItemController : BotonController
    {
        public ButtonItemController(Boton boton, BarButtonItem buttonItem) 
            : base(boton)
        {
            ButtonItem = buttonItem;
            ButtonItem.ItemClick += (s, e) => Click();
        }

        public override void Click()
        {
            Pagina pagina = Main.PaginaActual;
            if (pagina == null) return;

            Accion accion = pagina.Acciones[Boton.AccionInfo];
            accion?.Ejecutar();

            //System.Windows.Forms.MessageBox.Show(Elemento.AccionInfo.Nombre);
        }

        public BarButtonItem ButtonItem
        {
            get;
        }
    }
}
