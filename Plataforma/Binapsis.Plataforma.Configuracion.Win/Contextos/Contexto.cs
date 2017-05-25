using System;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win.Contextos
{
    abstract class Contexto : IContexto
    {
        public Contexto(TreeNode nodo, ListViewItem fila)
        {
            Nodo = nodo;
            Fila = fila;
        }

        public IElemento ElementoRoot
        {
            get;
            set;
        }

        public IElemento ElementoPropietario
        {
            get;
            protected set;
        }

        public IElemento ElementoSeleccionado
        {
            get;
            protected set;
        }

        protected ListViewItem Fila
        {
            get;
        }

        protected TreeNode Nodo
        {
            get;
        }

        public IRepositorio Repositorio
        {
            get;
            set;
        }

        public virtual Type Type
        {
            get;
            protected set;
        }

        public VistaElemento Vista
        {
            get;
            set;
        }

        public abstract void Refrescar();
        
    }
}
