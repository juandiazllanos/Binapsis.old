using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using System;

namespace Binapsis.Datos.Configuracion
{
    internal class Fabrica : FabricaBase<ObjetoBase>
    {
        public static Fabrica Instancia { get; } = new Fabrica();        

        public ObjetoBase Crear(Type type)
        {
            Tipo tipo = Types.Instancia.Obtener(type);
            if (tipo != null)
                return Crear(tipo);            
            else
                return null;
        }

        public ObjetoBase Crear(Type type, IFabricaImpl impl)
        {
            Tipo tipo = Types.Instancia.Obtener(type);
            if (tipo != null)
                return Crear(impl.Crear(tipo));
            else
                return null;
        }

        public override ObjetoBase Crear(IImplementacion impl)
        {
            Type type = Type.GetType(string.Format("{0}.{1}", impl.Tipo.Uri, impl.Tipo.Nombre));
            object instancia = Activator.CreateInstance(type, impl);
            return (ObjetoBase)instancia;
        }

    }
}
