using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using DevExpress.XtraBars;
using System;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main(Consola consola)
        {
            Consola = consola;
            InitializeComponent();
            Inicializar();    
        }

        private Consola Consola
        {
            get;
            set;
        }
        
        private void Inicializar()
        {
            ConstruirArbol();

            // asignar controlador resolver nodo
            tvwMain.BeforeExpand += (object sender, TreeViewCancelEventArgs e) => ResolverNodo(e.Node);
            // asignar controlador seleccionar nodo
            tvwMain.AfterSelect += (object sender, TreeViewEventArgs e) => SeleccionarNodo(e.Node); 
            // asignar controlador seleccionar item
            lvwMain.SelectedIndexChanged +=  (object sender, EventArgs e) => SeleccionarItem();
            // asignar controlador ejecutar accion
            barMain.ItemClick += (object sender, ItemClickEventArgs e) => Ejecutar(e.Item);
            // asignar controlador ordenar items
            lvwMain.ColumnClick += (object sender, ColumnClickEventArgs e) => OrdernarItems(e.Column);
            // asignar controlador actualizar
            //Consola.AccionTerminar += (object sender, AccionResultadoEventArgs e) => Actualizar(e.Type);
        }
        
        private void ConstruirArbol()
        {
            tvwMain.Nodes.Clear();
            
            foreach(Grupo grupo in Consola.Navegador.Grupos)            
                tvwMain.Nodes.Add(CrearNodo(grupo));
        }

        private TreeNode CrearNodo(Grupo grupo)
        {
            Nodo nodo = Consola.Navegador.CrearNodo(grupo);
            TreeNode node = CrearNodo(nodo);
            return node;
        }


        private TreeNode CrearNodo(Nodo nodo)
        {
            TreeNode node = new TreeNode();
            // obtener categoria del elemento
            string imagen = ObtenerImagen(nodo);
            // obtener index imagen
            int indiceImagen = ObtenerImagenIndice(imagen);
            // crear controlador de sub-nodos
            ResolverNodo resolver = new ResolverNodo(Consola.Navegador, nodo);

            // establecer valores
            node.Text = nodo.Nombre;
            node.Tag = resolver;
            // establecer imagen
            node.ImageIndex = indiceImagen;
            node.SelectedImageIndex = indiceImagen;
            node.StateImageIndex = indiceImagen;

            // agregar nodo vacío
            node.Nodes.Add("");
                        
            return node;
        }

        private void CrearNodos(TreeNode nodoPadre)
        {
            Nodo nodo = nodoPadre.Tag as Nodo;
            if (nodo == null) return;

            nodoPadre.Nodes.Clear();

            // construir sub-nodos
            foreach (Nodo nodoHijo in nodo.Nodos)
                nodoPadre.Nodes.Add(CrearNodo(nodoHijo));

            //tvwMain.Sort();
        }

        private string ObtenerImagen(Nodo nodo)
        {
            string imagen = nodo.Padre?.Nombre;

            if (imagen == null) imagen = "Configuracion";
            
            return imagen;
        }

        private int ObtenerImagenIndice(string imagen)
        {
            if (!string.IsNullOrEmpty(imagen))
                return imgElemento16.Images.IndexOfKey(imagen);
            else
                return -1;
        }

        private void ResolverNodo()
        {
            ResolverNodo(tvwMain.SelectedNode);
        }

        private void ResolverNodo(TreeNode item)
        {
            if (item == null) return;

            ResolverNodo resolver = item.Tag as ResolverNodo;
            if (resolver == null) return;
                        
            try
            {
                resolver.Resolver();
                item.Tag = resolver.Nodo;

                tvwMain.BeginUpdate();                
                CrearNodos(item);                
            }
            finally
            {
                tvwMain.EndUpdate();
            }
        }

        private void MostrarItems(Nodo nodo)
        {
            try
            {
                lvwMain.BeginUpdate();
                lvwMain.Items.Clear();

                // obtener item clave
                var items = Consola.Navegador.ObtenerClaves(nodo);

                // agregar filas
                if (items != null) 
                    foreach (Clave clave in items)
                        MostrarItem(clave);

                // establecer sorter
                lvwMain.ListViewItemSorter = new ListViewColumnSorter();
                // ordenar por nombre
                OrdernarItems(1);
            }
            finally
            {
                lvwMain.EndUpdate();
            }
        }
        
        private void MostrarItem(Clave clave)
        {
            ListViewItem item = new ListViewItem();
            string imagen = clave.Nombre;

            item.Text = clave.Nombre;
            item.ImageIndex = ObtenerImagenIndice(imagen);

            if (clave.ObjetoDatos.Tipo.ContienePropiedad("Nombre"))
                item.SubItems.Add(clave.ObjetoDatos.ObtenerString("Nombre"));
            else
                item.SubItems.Add(clave.Valor);

            item.Tag = clave;

            lvwMain.Items.Add(item);
        }

        private void SeleccionarNodo()
        {
            SeleccionarNodo(tvwMain.SelectedNode);
        }

        private void SeleccionarNodo(TreeNode item)
        {
            ResolverNodo(item);

            Nodo nodo = item.Tag as Nodo;

            if (nodo != null)
                Consola.Seleccionar(nodo);

            MostrarItems(nodo);            
        }

        private void SeleccionarItem()
        {
            if (lvwMain.SelectedItems.Count > 0)
                SeleccionarItem(lvwMain.SelectedItems[0]);
            else
                SeleccionarItem(null);
        }

        private void SeleccionarItem(int item)
        {
            if (item >= 0)
                SeleccionarItem(lvwMain.Items[item]);
            else
                SeleccionarItem(null);
        }

        private void SeleccionarItem(ListViewItem item)
        {
            Consola.Seleccionar(item?.Tag as Clave);
        }
                
        private void Ejecutar(BarItem item)
        {
            try
            {
                string accion = item?.Tag as string;
                if (accion == null) return;

                EjecutarAccion ejecutar = new EjecutarAccion(this, Consola, accion);
                ResultadoAccion resultado = new ResultadoAccion(this, tvwMain.SelectedNode);

                ejecutar.Ejecutar(resultado);
            }
            catch(Exception ex)
            {
                ControlarError(ex);
            }
        }

        public void Actualizar()
        {
            TreeNode nodo = tvwMain.SelectedNode;
            if (nodo != null)
                Actualizar(nodo);
        }

        internal void Actualizar(TreeNode node)
        {
            if (node == null) return;

            Nodo nodo = node.Tag as Nodo;
            if (nodo == null) return;

            Consola.Navegador.ResolverNodo(nodo);

            CrearNodos(node);
            MostrarItems(nodo);
        }

        private void ControlarError(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void OrdernarItems(int columna)
        {
            ListViewColumnSorter sorter = lvwMain.ListViewItemSorter as ListViewColumnSorter;
            if (sorter == null) return;

            // Determine if clicked column is already the column that is being sorted.
            if (columna == sorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;                
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn = columna;
                sorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvwMain.Sort();
        }

    }
}