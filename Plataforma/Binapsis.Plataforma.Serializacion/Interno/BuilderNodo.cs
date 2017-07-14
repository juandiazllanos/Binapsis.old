using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    abstract class BuilderNodo
    {        
        Heap _heap;
        Dictionary<IObjetoDatos, NodoObjetoDatos> _agre;

        bool _resol;

        #region Constructores
        public BuilderNodo(Nodo nodo)
        {
            _heap = new Heap();            
            _agre = new Dictionary<IObjetoDatos, NodoObjetoDatos>();

            Nodo = nodo;
        }
        #endregion


        #region Propiedades
        public Nodo Nodo
        {
            get;
        }
        #endregion


        #region Metodos
        protected void ResolverNodos()
        {
            _resol = true;

            NodoObjetoDatos[] nodos = new NodoObjetoDatos[_agre.Count];
            _agre.Values.CopyTo(nodos, 0);

            foreach (NodoObjetoDatos nodo in nodos)
                ResolverNodo(nodo);
        }

        private void ResolverNodo(NodoObjetoDatos nodo)
        {
            // resolver referencias agregacion
            if (string.IsNullOrEmpty(nodo.ObjetoMap.Propietario))
            {
                nodo.ObjetoMap.Propietario = nodo.Ruta;
                nodo.EsProxy = false; 
            }
                
            // resolver anidamiento
            CrearPropiedad(nodo);
        }
        
        protected void ConstruirNodoDiagramaDatos(NodoObjeto ndd, IDiagramaDatos dd)
        {
            //IDiagramaDatos dd = ndd.Objeto as IDiagramaDatos;
            if (dd == null) return;

            IObjetoDatos od = dd.ObjetoDatos;
            ResumenCambios resumen = dd.ResumenCambios as ResumenCambios;
            IObjetoCambios cambios = resumen?[od];

            ndd.Objeto = dd;
            ndd.Nombre = "DiagramaDatos";

            // nodo objeto de datos
            NodoObjetoDatos nod = new NodoObjetoDatos(ndd); 
            ndd.Agregar(nod);
            ConstruirNodoObjetoDatos(nod, od);

            // nodo objeto de cambios
            NodoObjetoDatos noc = new NodoObjetoDatos(ndd); 
            ndd.Agregar(noc);
            ConstruirNodoObjetoDatos(noc, cambios);
        }
        
        protected void ConstruirNodoObjetoDatos(NodoObjetoDatos nod, IObjetoDatos od)
        {
            if (od == null) return;

            ObjetoMap omap = _heap.Obtener(od);

            omap.Propietario = nod.NodoPadre == null ? "/" : nod.NodoPadre.Nombre;

            nod.Nombre = od.Tipo.Nombre;
            nod.ObjetoDatos = od;
            nod.ObjetoMap = omap;
            
            foreach (IPropiedad propiedad in od.Tipo.Propiedades)
                CrearPropiedad(nod, propiedad);
        }
        
        private void CrearObjeto(NodoReferencia nodo)
        {
            IObjetoDatos od = ((NodoObjetoDatos)nodo.NodoPadre).ObjetoMap.ObjetoDatos;
            IPropiedad propiedad = nodo.Propiedad;

            // crear nodos hijos
            if (propiedad.Cardinalidad >= Cardinalidad.CeroAMuchos)
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
            NodoObjetoDatos nodoobj = new NodoObjetoDatos(nodo);
            nodoobj.ObjetoDatos = od;
            nodoobj.ObjetoMap = omap;

            nodo.Agregar(nodoobj);

            // establecer valores
            string ruta = ((NodoObjetoDatos)nodo.NodoPadre).Ruta;
            bool composicion = (nodo.Propiedad.Asociacion == Asociacion.Composicion);
            
            if (nodo.Propiedad.Cardinalidad >= Cardinalidad.CeroAMuchos)
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
                // se mantiene la primera referencia y que sea diferente del root
                if (!_agre.ContainsKey(od) && omap.Propietario != "/")  _agre.Add(od, nodoobj);
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
        
        private void CrearPropiedad(NodoObjetoDatos nodo)
        {
            foreach (IPropiedad prop in nodo.ObjetoMap.ObjetoDatos.Tipo.Propiedades)
                CrearPropiedad(nodo, prop);
        }

        private void CrearPropiedad(NodoObjetoDatos nodo, IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato) return;

            IObjetoDatos od = nodo.ObjetoMap.ObjetoDatos;

            if (!od.Establecido(propiedad)) return;

            // crear nodo
            NodoReferencia nodoprop = new NodoReferencia(nodo, propiedad);
            nodo.Agregar(nodoprop);
            
            // crear nodos hijos
            CrearObjeto(nodoprop);
        }
        #endregion

    }
}
