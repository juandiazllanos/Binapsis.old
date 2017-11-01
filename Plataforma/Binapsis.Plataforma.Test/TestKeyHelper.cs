using Binapsis.Plataforma.Helper.Impl;
using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test
{
    public class TestKeyHelper : KeyHelper
    {
        IDictionary<ITipo, IPropiedad[]> _items;

        public TestKeyHelper()
        {
            _items = new Dictionary<ITipo, IPropiedad[]>();
        }
        
        public override IPropiedad[] GetProperty(ITipo tipo)
        {
            if (_items.ContainsKey(tipo))
                return _items[tipo];
            else
                return base.GetProperty(tipo);
        }

        public void Establecer(ITipo tipo, string propiedad)
        {
            Establecer(tipo, tipo[propiedad]);
        }

        public void Establecer(ITipo tipo, IPropiedad propiedad)
        {
            if (tipo == null || propiedad == null) return;

            if (!_items.ContainsKey(tipo))
                _items.Add(tipo, new IPropiedad[] { propiedad });
        }
    }
}
