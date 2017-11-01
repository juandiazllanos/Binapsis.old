using Binapsis.Plataforma.AgenteDatos;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

using System.Collections.Generic;

namespace Binapsis.Plataforma.Helper
{
    public class ResolverKeyHelper
    {
        string _url;
        string _contexto;

        IEnumerable<IObjetoDatos> _coleccion;
        Dictionary<ITipo, List<IObjetoDatos>> _items;

        public ResolverKeyHelper(string url, string contexto, IObjetoDatos od)            
            : this(url, contexto, new Coleccion())
        {
            (_coleccion as Coleccion)?.Agregar(od);
        }

        public ResolverKeyHelper(string url, string contexto, IEnumerable<IObjetoDatos> col)
        {
            _url = url;
            _contexto = contexto;
            _coleccion = col;

            _items = new Dictionary<ITipo, List<IObjetoDatos>>();
        }
        
        public void ResolverKey()
        {
            foreach(IObjetoDatos od in _coleccion)
                ResolverTipo(od);

            foreach (ITipo tipo in _items.Keys)
                ResolverKey(tipo);
        }

        private void ResolverKey(ITipo tipo)
        {
            List<IObjetoDatos> items = _items[tipo];
            if (items == null || items.Count == 0) return;
            
            IPropiedad[] propiedades = HelperProvider.KeyHelper.GetProperty(tipo);

            foreach (IPropiedad clave in propiedades)
                ResolverKey(tipo, clave, items);                
        }

        private void ResolverKey(ITipo tipo, IPropiedad clave, IList<IObjetoDatos> items)
        {
            ServicioKey servicio = new ServicioKey(_url, _contexto);
            int id = (int) servicio.ObtenerKey(tipo, clave, items.Count);

            foreach (IObjetoDatos item in items)
                item.Establecer(clave, id++);
        }


        private void ResolverTipo(IObjetoDatos od)
        {
            if (od == null) return;

            IKey key = HelperProvider.KeyHelper.GetKey(od);

            if (key == null)
                Agregar(od);

            foreach (IPropiedad propiedad in od.Tipo.Propiedades)
                ResolverTipo(od, propiedad);
        }

        private void ResolverTipo(IObjetoDatos od, IPropiedad propiedad)
        {
            if (od == null || propiedad.Asociacion != Asociacion.Composicion) return;

            if (!propiedad.EsColeccion)
                ResolverTipo(od.ObtenerObjetoDatos(propiedad));
            else
                foreach (IObjetoDatos item in od.ObtenerColeccion(propiedad))
                    ResolverTipo(item);
        }

        private void Agregar(IObjetoDatos od)
        {
            List<IObjetoDatos> ods;

            if (_items.ContainsKey(od.Tipo))
                ods = _items[od.Tipo];
            else
                _items.Add(od.Tipo, ods = new List<IObjetoDatos>());

            if (!ods.Contains(od))
                ods.Add(od);
        }

    }
}
