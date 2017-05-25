using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Helper;
using Binapsis.Presentacion.MVVM.Definicion;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM.Builder
{
    class BuilderVistaModelo
    {
        HelperModelo _helper;

        public BuilderVistaModelo(VistaModelo vistaModelo)
        {
            _helper = new HelperModelo(vistaModelo.Modelo);
            VistaModelo = vistaModelo;
        }

        public void Construir()
        {
            foreach (PropiedadInfo propiedad in VistaModelo.TipoInfo.Propiedades.Where(item => !item.TipoInfo.EsTipoDeDato))
                Construir(propiedad);
        }

        public void Construir(PropiedadInfo propiedad)
        {
            if (propiedad.TipoInfo.EsTipoDeDato) return;

            object valor = _helper.Obtener(propiedad);
            if (valor == null) return;

            if (!propiedad.EsColeccion && typeof(IObjetoDatos).GetTypeInfo().IsAssignableFrom(valor.GetType().GetTypeInfo()))
                VistaModelo.EstablecerVistaModelo(propiedad, (IObjetoDatos)valor);

            else if (propiedad.EsColeccion && typeof(IEnumerable<IObjetoDatos>).GetTypeInfo().IsAssignableFrom(valor.GetType().GetTypeInfo()))
                foreach (IObjetoDatos item in (IEnumerable<IObjetoDatos>)valor)
                    VistaModelo.AgregarVistaModelo(propiedad, item);
        }
        
        public VistaModelo VistaModelo
        {
            get;
        }
    }
}
