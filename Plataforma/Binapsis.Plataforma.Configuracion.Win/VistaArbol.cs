using Binapsis.Plataforma.Configuracion.Win.Modelo;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public class VistaArbol : VistaElemento
    {
        TreeNode _nodo;
        VistaElemento _vistaAsociada;
        bool _redundacia;
        
        public VistaArbol(TreeNode nodo, VistaElemento vistaAsociada)
        {
            _nodo = nodo;
            _vistaAsociada = vistaAsociada;           
        }

        public override void Mostrar()
        {
            if (_nodo == null || _redundacia) return;
            _redundacia = true;

            _nodo.TreeView.BeginUpdate();

            try
            {
                // eliminar jerarquia
                _nodo.Nodes.Clear();
                // mostrar jeraquia
                Mostrar(_nodo);
                // mostrar vista asociada
                _vistaAsociada?.Mostrar();
                // seleccionar nodo
                _nodo.TreeView.SelectedNode = _nodo;
                // expandir nodo
                _nodo.Expand();
            }
            finally
            {
                _nodo.TreeView.EndUpdate();
                _redundacia = false;
            }
        }

        private void Mostrar(TreeNode nodo)
        {
            Elemento elemento = (nodo.Tag as Elemento);
            if (elemento == null) return;

            nodo.Text = elemento.Valor;
            nodo.ImageKey = elemento.Nombre;
            nodo.SelectedImageKey = elemento.Nombre;

            TreeNode nodoItem = null;

            foreach (Elemento elementoItem in elemento.Items)
            {
                nodoItem = new TreeNode();
                nodoItem.Tag = elementoItem;

                Mostrar(nodoItem);

                nodo.Nodes.Add(nodoItem);
            }
        }

        //private void Seleccionar(Elemento elemento)
        //{
        //    TreeNode nodosel = null;

        //    foreach (TreeNode nodoItem in _nodo.Nodes)            
        //        if (nodoItem.Tag == _elemref)
        //        {
        //            nodosel = nodoItem;
        //            break;
        //        }

        //    if (nodosel == null)
        //        nodosel = _nodo;

        //    _nodo.TreeView.SelectedNode = nodosel;
        //    _nodo.Expand();
        //}
    }
}
