using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Http;

using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class ParametroHelper
    {
        IQueryCollection _query;
        ITipo _tipo;

        Dictionary<IPropiedad, object> _items;

        public ParametroHelper(ITipo tipo, IQueryCollection query)
        {
            _tipo = tipo;
            _query = query;

            Construir();
        }

        private void Construir()
        {
            _items = new Dictionary<IPropiedad, object>();

            foreach (var kvp in _query)
                Construir(kvp.Key, kvp.Value);
        }

        private void Construir(string clave, object valor)
        {
            IPropiedad propiedad;

            if (_tipo.ContienePropiedad(clave))
                propiedad = _tipo.ObtenerPropiedad(clave);
            else 
                propiedad = _tipo.Propiedades.FirstOrDefault(item => item.Nombre.Equals(clave, StringComparison.OrdinalIgnoreCase));

            if (propiedad != null && !_items.ContainsKey(propiedad))
                _items.Add(propiedad, valor);
        }

        public void Establecer(ComandoHelper comandoHelper)
        {
            foreach (var kvp in _items)
                comandoHelper.EstablecerParametro(kvp.Key, kvp.Value);
        }

        public IPropiedad[] Propiedades
        {
            get => _items.Keys.ToArray();
        }

        public object[] Valores
        {
            get => _items.Values.ToArray();
        }
    }
}
