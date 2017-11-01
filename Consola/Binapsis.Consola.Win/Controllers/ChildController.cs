using Binapsis.Consola.Controllers;
using Binapsis.Consola.Estructura;

namespace Binapsis.Consola.Win.Controllers
{
    class ChildController : TabController
    {
        bool _activando;
        bool _cerrando;

        public ChildController(Tab tab, WinChild child) 
            : base(tab)
        {
            Child = child;

            Child.Activated += (s, e) => Activar();
            Child.FormClosed += (s, e) => Cerrar();
        }

        public override void Activar()
        {
            if (_activando) return;

            _activando = true;

            try
            {
                base.Activar();

                Child.Show();
                Child.Activate();
            }
            finally
            {
                _activando = false;
            }            
        }

        public WinChild Child
        {
            get;
        }
    }
}
