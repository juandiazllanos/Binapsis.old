using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Helper;

namespace Binapsis.Plataforma
{
    public class EntidadBase : ObjetoBase
    {        
        protected EntidadBase(IImplementacion impl) 
            : base(impl)
        {
        }

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return (HelperProvider.DataFactory as DataFactory)?.Crear(impl);
        }
                
        public virtual EntidadBase CrearEntidadBase(IPropiedad propiedad)
        {
            return CrearObjetoDatos(propiedad) as EntidadBase;
        }

        public object Id
        {
            get => Obtener("Id");
        }

    }
}
