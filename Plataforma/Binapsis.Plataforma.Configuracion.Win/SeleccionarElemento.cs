using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public partial class SeleccionarElemento : Form
    {
        bool _resultado;

        public SeleccionarElemento()
        {
            InitializeComponent();
            btnAceptar.Click += (s, e) => ResolverAceptar();
            lvwElemento.DoubleClick += (s, e) => { if (lvwElemento.SelectedItems.Count > 0) ResolverAceptar(); };
            lvwElemento.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter && lvwElemento.SelectedItems.Count > 0) ResolverAceptar(); };
        }

        public IElemento ElementoRoot { get; set; }

        public IElemento Obtener(string nombre, string valor)
        {
            IElemento elemento = null;
            List<IElemento> resul = new List<IElemento>();

            Text = $"Seleccionar {nombre}";
            Filtrar(ElementoRoot, nombre, valor, resul);
            Mostrar(resul);

            ShowDialog();

            if (_resultado && lvwElemento.SelectedItems.Count > 0)
                elemento = (lvwElemento.SelectedItems[0].Tag as IElemento);

            return elemento;
        }

        private void Filtrar(IElemento elemento, string nombre, string valor, List<IElemento> resultado)
        {
            if (elemento == null || nombre == null || valor == null) return;

            var items = elemento.Items.Where(item => item.Nombre == nombre && item.Valor.ToLower().Contains(valor?.ToLower()));
            if (items == null) return;

            resultado.AddRange(items);

            foreach (IElemento item in elemento.Items)
                Filtrar(item, nombre, valor, resultado);            
        }

        private void Mostrar(IEnumerable<IElemento> items)
        {            
            lvwElemento.BeginUpdate();
            try
            {
                lvwElemento.Items.Clear();

                foreach (IElemento item in items)
                    Mostrar(item);

                if (lvwElemento.Items.Count > 0)
                    lvwElemento.Items[0].Selected = true;

                //lvwElemento.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            finally
            {
                lvwElemento.EndUpdate();
            }
        }

        private void Mostrar(IElemento elemento)
        {
            ListViewItem fila = new ListViewItem();

            fila.Text = elemento.Valor;
            fila.ImageKey = elemento.Nombre;

            //fila.SubItems.Add(elemento.Alias);
            //fila.SubItems.Add(elemento.Propietario?.Valor ?? "");

            fila.Tag = elemento;

            lvwElemento.Items.Add(fila);
        }

        private void ResolverAceptar()
        {
            _resultado = true;
            Close();
        }
    }
}
