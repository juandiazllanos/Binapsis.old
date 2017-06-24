using System;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    class NodoObjeto : Nodo
    {
        public NodoObjeto()
            : base()
        {

        }

        public NodoObjeto(Nodo padre) 
            : base(padre)
        {
        }

        public object Objeto
        {
            get;
            set;
        }

        public Type Type
        {
            get => Objeto?.GetType();
        }
    }
}
