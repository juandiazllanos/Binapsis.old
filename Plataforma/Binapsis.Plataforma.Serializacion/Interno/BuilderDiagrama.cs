using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal class BuilderDiagrama
    {
        Diagrama _diag;
        Heap _heap;
        Dictionary<IObjetoDatos, NodoObjetoDatos> _agre;

        bool _resol;

        #region Constructores
        public BuilderDiagrama(Diagrama diagrama)
        {
            _heap = new Heap();            
            _agre = new Dictionary<IObjetoDatos, NodoObjetoDatos>();

            Diagrama = diagrama;
        }
        #endregion


        #region Propiedades
        public Diagrama Diagrama
        {
            get;
        }
        #endregion


        public void Construir(IDiagramaDatos[] diagramaDatos)
        {
            // crear nodo
            NodoColeccion nco = new NodoColeccion() { Nombre = "Coleccion" };
            // crear nodos
            foreach (IDiagramaDatos item in diagramaDatos)
            {
                NodoObjeto ndd = CrearNodoDiagramaDatos(nco, item);
                ConstruirNodoDiagramaDatos(ndd);
                nco.Agregar(ndd);
            }
            // resolver nodos
            ResolverNodos();
            // establecer root
            Diagrama.Root = nco;
        }

        public void Construir(IObjetoDatos[] od)
        {
            // crear nodo
            NodoColeccion nco = new NodoColeccion() { Nombre = "Coleccion" };
            // crear nodos
            foreach(IObjetoDatos item in od)
            {
                NodoObjetoDatos nod = CrearNodoObjetoDatos(nco, item);
                ConstruirNodoObjetoDatos(nod);
                nco.Agregar(nod);
            }
            // resolver nodos
            ResolverNodos();
            // establecer root
            Diagrama.Root = nco;
        }

        public void Construir(IDiagramaDatos diagramaDatos)
        {
            // crear nodo
            NodoObjeto ndd = CrearNodoDiagramaDatos(diagramaDatos);
            // construir nodo
            ConstruirNodoDiagramaDatos(ndd);
            // resolver nodos
            ResolverNodos();
            // establecer root
            Diagrama.Root = ndd;
        }

        
        public void Construir(IObjetoDatos od)
        {
            // crear nodo
            NodoObjetoDatos nod = CrearNodoObjetoDatos(od);           
            // construir nodo
            ConstruirNodoObjetoDatos(nod);
            // resolver nodos
            ResolverNodos();
            // establecer root
            Diagrama.Root = nod;
        }


        private void ResolverNodos()
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

        
        private NodoObjeto CrearNodoDiagramaDatos(IDiagramaDatos diagramaDatos)
        {
            return CrearNodoDiagramaDatos(null, diagramaDatos);
        }

        private NodoObjeto CrearNodoDiagramaDatos(Nodo padre, IDiagramaDatos diagramaDatos)
        {
            // crear nodo diagrama de datos
            return new NodoObjeto(padre) { Objeto = diagramaDatos, Nombre = "DiagramaDatos" };             
        }

        private NodoObjetoDatos CrearNodoObjetoDatos(IObjetoDatos od)
        {
            return CrearNodoObjetoDatos(null, od);
        }

        private NodoObjetoDatos CrearNodoObjetoDatos(Nodo padre, IObjetoDatos od)
        {
            ObjetoMap omap = _heap.Obtener(od);
            omap.Propietario = padre == null ? "/" : padre.Nombre;
            return new NodoObjetoDatos(padre, omap) { Nombre = od.Tipo.Nombre };
        }


        private void ConstruirNodoDiagramaDatos(NodoObjeto ndd)
        {
            IDiagramaDatos dd = ndd.Objeto as IDiagramaDatos;
            if (dd == null) return;

            IObjetoDatos od = dd.ObjetoDatos;
            ResumenCambios resumen = dd.ResumenCambios as ResumenCambios;
            IObjetoCambios cambios = resumen?[od];
            
            // nodo objeto de datos
            NodoObjetoDatos nod = CrearNodoObjetoDatos(ndd, od);
            ndd.Agregar(nod);
            ConstruirNodoObjetoDatos(nod);

            // nodo objeto de cambios
            NodoObjetoDatos noc = CrearNodoObjetoDatos(ndd, cambios);
            ndd.Agregar(noc);
            ConstruirNodoObjetoDatos(noc);
        }
        
        private void ConstruirNodoObjetoDatos(NodoObjetoDatos nodo)
        {
            IObjetoDatos od = nodo.ObjetoMap.ObjetoDatos;

            foreach (IPropiedad propiedad in od.Tipo.Propiedades)
                CrearPropiedad(nodo, propiedad);
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
            NodoObjetoDatos nodoobj = new NodoObjetoDatos(nodo, omap);
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

        
    }
}
