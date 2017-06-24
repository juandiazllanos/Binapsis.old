using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal abstract class Nodo 
    {        
        List<Nodo> _nodos;

        #region Constructores
        public Nodo()
        {
            _nodos = new List<Nodo>();
        }
        
        public Nodo(Nodo padre)
            : this()
        {
            NodoPadre = padre;
        }
        #endregion


        #region Metodos
        public virtual void Agregar(Nodo nodo)
        {
            _nodos.Add(nodo);            
        }
        #endregion


        #region Propiedades
        public Nodo NodoPadre
        {
            get;
        }
        
        public IReadOnlyList<Nodo> Nodos
        {
            get => _nodos; 
        }

        public string Nombre
        {
            get;
            set;
        }
        #endregion
        
    }
}
