using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;
using System.Linq;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal class NodoReferencia : Nodo, INodoReferencia
    {
        public NodoReferencia(NodoObjeto padre, IPropiedad propiedad)
            : base(padre)
        {
            Propiedad = propiedad;            
        }
        
        public override void Agregar(Nodo nodo)
        {
            if (nodo == null || typeof(NodoObjeto) != nodo.GetType()) return;

            NodoObjeto nodoobj = (NodoObjeto)nodo;
            string ruta = string.Empty;
            int indice = Nodos.Count;

            if (Propiedad.Asociacion == Asociacion.Composicion)
                ruta = string.Format("{0}/{1}[{2}]", ((NodoObjeto)Padre).Ruta, Propiedad.Nombre, indice);
            else
                ruta = string.Format("{0}/{1}", ((NodoObjeto)Padre).Ruta, Propiedad.Nombre);

            nodoobj.Ruta = ruta;
            nodoobj.Indice = indice;

            base.Agregar(nodo); 
        }
        
        public IPropiedad Propiedad { get; }

        IEnumerable<INodoObjeto> INodoReferencia.Objetos
        {
            get { return Nodos.OfType<INodoObjeto>(); }
        }
    }
}
