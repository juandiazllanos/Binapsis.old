using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Binapsis.Consola.Win.Vistas;

namespace Binapsis.Consola.Win
{
    public partial class WinChild : XtraForm
    {
        VistaBase _vista;

        public WinChild()
        {
            InitializeComponent();
        }

        public void Establecer(VistaBase vista)
        {
            Controls.Clear();
            Controls.Add(vista);
            vista.Dock = DockStyle.Fill;

            _vista = vista;
        }

        public Image Imagen
        {
            get => _vista.Imagen;            
        }
    }
}