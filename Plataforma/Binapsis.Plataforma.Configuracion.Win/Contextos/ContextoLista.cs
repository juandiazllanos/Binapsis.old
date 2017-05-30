using Binapsis.Plataforma.Configuracion.Win.Modelo;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win.Contextos
{
    class ContextoLista : ContextoArbol
    {       
        public ContextoLista(TreeNode nodo, ListViewItem fila) 
            : base(nodo, fila)
        {
        }

        protected override void Inicializar()
        {
            ElementoPropietario = (Nodo.Tag as Elemento);
            if (ElementoPropietario == null) return;            
            ElementoRoot = ElementoPropietario.Root;
            Type = ElementoPropietario?.TypeItem;
            ElementoSeleccionado = (Fila?.Tag as IElemento);            
        }
    }
}
