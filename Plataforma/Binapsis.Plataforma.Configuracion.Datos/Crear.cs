using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Builder;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion.Helper;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    public class Crear : Operacion
    {
        public Crear(IContexto contexto) 
            : base(contexto)
        {
        }

        public override void Ejecutar(IObjetoDatos obj)
        {
            IDiagramaDatos dd = new DiagramaDatos(obj.Tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
            builder.KeyHelper = new ConfiguracionKeyHelper();
            builder.Construir(obj, null as IObjetoDatos);
            Ejecutar(dd);
        }
    }
}
