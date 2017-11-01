using Binapsis.Plataforma.AgenteDatos;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;

using System.Collections.Generic;

namespace Binapsis.Plataforma.Operaciones
{
    class Guardar
    {
        string _url;
        string _contexto;

        public Guardar(string url, string contexto)
        {
            _url = url;
            _contexto = contexto;
        }

        public void Ejecutar(EntidadBase entidad)
        {
            bool existe = Existe(entidad);

            ResolverKeyHelper resolverKey = new ResolverKeyHelper(_url, _contexto, entidad);
            resolverKey.ResolverKey();

            ServicioDatos servicio = new ServicioDatos(_url, _contexto, HelperContext.DataFactory);

            if (!existe)
                servicio.CrearObjetoDatos(entidad);
            else
                servicio.EditarObjetoDatos(entidad);
        }

        public void Ejecutar(IEnumerable<EntidadBase> items)
        {
            Coleccion crearItems = new Coleccion();
            Coleccion editarItems = new Coleccion();

            foreach (EntidadBase item in items)
                if (!Existe(item))
                    crearItems.Agregar(item);
                else
                    editarItems.Agregar(items);

            ResolverKeyHelper resolverKey = new ResolverKeyHelper(_url, _contexto, items);
            resolverKey.ResolverKey();

            ServicioDatos servicio = new ServicioDatos(_url, _contexto, HelperContext.DataFactory);

            if (crearItems.Longitud > 0)
                servicio.CrearColeccion(crearItems);

            if (editarItems.Longitud > 0)
                servicio.EditarColeccion(editarItems);
            
        }

        private bool Existe(EntidadBase entidad)
        {
            IKey key = HelperContext.KeyHelper.GetKey(entidad);
            return (key != null);
        }
    }
}
