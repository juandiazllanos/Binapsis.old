using Binapsis.Plataforma.Estructura.Impl;
using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class ConfiguracionBase : ObjetoBase
    {
        protected ConfiguracionBase(Type type)
            : this(type, FabricaImpl.Instancia)
        {
        }

        protected ConfiguracionBase(Type type, IFabricaImpl impl)
            : this(impl.Crear(Types.Instancia.Obtener(type)))
        {
        }

        public ConfiguracionBase(IImplementacion impl) 
            : base(impl)
        {
        }
        
        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return Fabrica.Instancia.Crear(impl);
        }
    }
}
