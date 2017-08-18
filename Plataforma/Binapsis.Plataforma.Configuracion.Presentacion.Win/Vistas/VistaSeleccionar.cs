using System.Windows.Forms;
using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using System.Collections;
using System;
using System.ComponentModel;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    [ToolboxItem(false)]
    public partial class VistaSeleccionar : UserControl
    {
        public event Action SeleccionarItem;

        public VistaSeleccionar()
        {
            InitializeComponent();
            Inicializar();
        }
        
        private void Inicializar()
        {
            // asignar controlador asignar item
            lvwClave.SelectedIndexChanged += (sender, e) => Item = lvwClave.SelectedItems.Count > 0 ? lvwClave.SelectedItems[0].Tag : null;
            // asignar controlador seleccionar item
            lvwClave.KeyDown += (object sender, KeyEventArgs e) => { if (e.KeyCode == Keys.Enter) OnSeleccionarItem(); };
            lvwClave.DoubleClick += (sender, e) => OnSeleccionarItem();
        }
                
        public void Establecer(object obj)
        {
            Items = obj as IEnumerable;
            Mostrar();
        }

        private void Mostrar()
        {
            lvwClave.Items.Clear();

            try
            {
                lvwClave.BeginUpdate();

                if (Items == null) return;

                foreach (object item in Items)
                    MostrarItem(item as Clave);

                if (lvwClave.Items.Count > 0)
                    lvwClave.Items[0].Selected = true;
            }
            finally
            {
                lvwClave.EndUpdate();
            }
        }

        private void MostrarItem(Clave clave)
        {
            if (clave == null) return;

            ListViewItem fila = new ListViewItem();
            fila.Text = clave.Nombre;
            fila.Tag = clave;

            lvwClave.Items.Add(fila);
        }

        private void OnSeleccionarItem()
        {
            if (Item != null && SeleccionarItem != null)
                SeleccionarItem.Invoke();
        }
        
        private IEnumerable Items
        {
            get;
            set;
        }

        public object Item
        {
            get;
            set;
        }

    }
}
