using Binapsis.Plataforma.Estructura;
using System.Reflection;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal class NodoReferencia : Nodo
    {
        public NodoReferencia(NodoObjetoDatos padre, IPropiedad propiedad)
            : base(padre)
        {
            Propiedad = propiedad;            
        }
        
        public override void Agregar(Nodo nodo)
        {
            if (nodo == null) return;

            NodoObjetoDatos nodoobj = nodo as NodoObjetoDatos;
            
            string ruta = string.Empty;
            int indice = Nodos.Count;

            if (Propiedad.Asociacion == Asociacion.Composicion)
                ruta = string.Format("{0}/{1}[{2}]", ((NodoObjetoDatos)NodoPadre).Ruta, Propiedad.Nombre, indice);
            else
                ruta = string.Format("{0}/{1}", ((NodoObjetoDatos)NodoPadre).Ruta, Propiedad.Nombre);

            if (nodoobj != null)
            {
                nodoobj.Ruta = ruta;
                nodoobj.Indice = indice;
            }            

            base.Agregar(nodo); 
        }
        
        public IPropiedad Propiedad
        {
            get;
        }

        //public IEnumerable<NodoObjetoDatos> Objetos
        //{
        //    get => Nodos.OfType<NodoObjetoDatos>(); 
        //}
    }
}
