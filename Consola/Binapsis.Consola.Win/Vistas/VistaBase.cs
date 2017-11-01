using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

//using Binapsis.Consola.Espacios;

namespace Binapsis.Consola.Win.Vistas
{
    [ToolboxItem(false)]
    public partial class VistaBase : UserControl
    {
        public VistaBase()
        {
            InitializeComponent();
        }
        
        public event Action<Point> MouseClickDerecho;

        public virtual void Actualizar()
        {

        }
        
        public virtual void EstablecerContenido(Contenido contenido)
        {
            
        }

        protected void OnMouseClick(MouseButtons mouseButtons)
        {
            if (mouseButtons == MouseButtons.Right)
                MouseClickDerecho?.Invoke(MousePosition);
        }

        public virtual object[] ItemSeleccionado
        {
            get;
        }

        public Image Imagen
        {
            get;
            set;
        }
    }
}
