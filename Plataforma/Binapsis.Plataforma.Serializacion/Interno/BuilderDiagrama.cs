using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Interno
{    
    internal class BuilderDiagrama
    {
        Diagrama _diag;
        Heap _heap;
        Dictionary<IObjetoDatos, NodoObjeto> _agre;

        bool _resol;

        public Diagrama Crear(IObjetoDatos od)
        {
            _heap = new Heap(); 
            _diag = new Diagrama();
            _agre = new Dictionary<IObjetoDatos, NodoObjeto>();

            CrearRoot(od);
            ConstruirNodos(_diag.Root);
            ResolverNodos();

            return _diag;
        }

        private void ResolverNodos()
        {
            _resol = true;

            NodoObjeto[] nodos = new NodoObjeto[_agre.Count];
            _agre.Values.CopyTo(nodos, 0);

            foreach (NodoObjeto nodo in nodos)
                ResolverNodo(nodo);
        }

        private void ResolverNodo(NodoObjeto nodo)
        {
            // resolver referencias agregacion
            if (string.IsNullOrEmpty(nodo.Objeto.Propietario))
            {
                nodo.Objeto.Propietario = nodo.Ruta;
                nodo.EsProxy = false; 
            }
                
            // resolver anidamiento
            CrearPropiedad(nodo);
        }

        private void ConstruirNodos(Root root)
        {
            IObjetoDatos od = root.Objeto.ObjetoDatos;

            foreach (IPropiedad propiedad in od.Tipo.Propiedades)
                CrearPropiedad(root, propiedad);
        }

        private void CrearRoot(IObjetoDatos od)
        {
            ObjetoMap omap = _heap.Obtener(od);
            Root root = new Root(omap);
            _diag.Root = root;
        }

        private void CrearObjeto(NodoReferencia nodo)
        {
            IObjetoDatos od = ((NodoObjeto)nodo.Padre).Objeto.ObjetoDatos;
            IPropiedad propiedad = nodo.Propiedad;

            // crear nodos hijos
            if (propiedad.Cardinalidad >= Cardinalidad.Muchos)
                CrearObjeto(nodo, od.ObtenerColeccion(propiedad));
            else
                CrearObjeto(nodo, od.ObtenerObjetoDatos(propiedad));
        }

        private void CrearObjeto(NodoReferencia nodo, IObjetoDatos od)
        {
            CrearObjeto(nodo, od, 0);
        }

        private void CrearObjeto(NodoReferencia nodo, IColeccion col)
        {
            int i = 0;
            foreach (IObjetoDatos od in col)
                CrearObjeto(nodo, od, i++);
        }
        
        private void CrearObjeto(NodoReferencia nodo, IObjetoDatos od, int indice)
        {
            if (od == null) return;

            ObjetoMap omap = _heap.Obtener(od);
            if (omap == null) return;

            // crear nodo
            NodoObjeto nodoobj = new NodoObjeto(nodo, omap);
            nodo.Agregar(nodoobj);

            // establecer valores
            string ruta = ((NodoObjeto)nodo.Padre).Ruta;
            bool composicion = (nodo.Propiedad.Asociacion == Asociacion.Composicion);
            
            if (nodo.Propiedad.Cardinalidad >= Cardinalidad.Muchos)
                ruta = string.Format("{0}/{1}[{2}]", ruta, nodo.Propiedad.Nombre, indice);
            else
                ruta = string.Format("{0}/{1}", ruta, nodo.Propiedad.Nombre);

            nodoobj.Ruta = ruta;
            nodoobj.Indice = indice;
            
            // determinar si debe resolverse
            bool resol = (composicion || _resol) && string.IsNullOrEmpty(omap.Propietario);
            
            // establecer referencia agregacion
            if (!resol)
            {
                // le referencia agregacion es proxy, hasta que se resuelva
                nodoobj.EsProxy = true;
                // se mantiene la primera referencia
                if (!_agre.ContainsKey(od))  _agre.Add(od, nodoobj);
                return;
            }                

            // establecer propietario
            omap.Propietario = ruta;

            // eliminar referencia resuelta
            if (_agre.ContainsKey(od))
                _agre.Remove(od);

            // crear nodos hijos
            CrearPropiedad(nodoobj);
        }
        
        private void CrearPropiedad(NodoObjeto nodo)
        {
            foreach (IPropiedad prop in nodo.Objeto.ObjetoDatos.Tipo.Propiedades)
                CrearPropiedad(nodo, prop);
        }

        private void CrearPropiedad(NodoObjeto nodo, IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato) return;

            IObjetoDatos od = nodo.Objeto.ObjetoDatos;

            if (!od.Establecido(propiedad)) return;

            // crear nodo
            NodoReferencia nodoprop = new NodoReferencia(nodo, propiedad);
            nodo.Agregar(nodoprop);
            
            // crear nodos hijos
            CrearObjeto(nodoprop);
        }

        
    }
}
