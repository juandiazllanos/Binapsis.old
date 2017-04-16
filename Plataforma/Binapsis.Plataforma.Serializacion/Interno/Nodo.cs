using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal abstract class Nodo
    {
        Nodo _padre;
        List<Nodo> _nodos;

        public Nodo()
        {
            _nodos = new List<Nodo>();
        }

        public Nodo(Nodo padre)
            : this()
        {
            _padre = padre;
        }

        public virtual void Agregar(Nodo nodo)
        {
            _nodos.Add(nodo);            
        }

        public IReadOnlyList<Nodo> Nodos
        {
            get { return _nodos; }
        }

        public Nodo Padre
        {
            get { return _padre; }
        }

    }
}
