using Binapsis.Plataforma.Configuracion.Win.Modelo;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win.Contextos
{
    class ContextoArbol : Contexto
    {   
        public ContextoArbol(TreeNode nodo, ListViewItem fila) 
            : base(nodo, fila)
        {
            Inicializar();
        }

        protected virtual void Inicializar()
        {
            ElementoSeleccionado = (Nodo.Tag as IElemento);
            if (ElementoSeleccionado == null) return;
            ElementoPropietario = ElementoSeleccionado.Propietario;
            ElementoRoot = ElementoPropietario.Root;
            Type = ElementoSeleccionado.Type;
        }

        public override void Refrescar()
        {
            Elemento elemento = (Nodo.Tag as Elemento);
            elemento?.Actualizar();
            Vista?.Mostrar();
        }
    }
}
