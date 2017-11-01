using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Cambios.Builder;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion.Helper;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    public class Eliminar : Operacion
    {
        public Eliminar(IContexto contexto) 
            : base(contexto)
        {
        }

        public override void Ejecutar(IObjetoDatos obj)
        {
            IDiagramaDatos dd = new DiagramaDatos(obj.Tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
            builder.KeyHelper = new ConfiguracionKeyHelper();
            builder.Construir(null, obj);

            Ejecutar(dd);
        }
        
    }
}
