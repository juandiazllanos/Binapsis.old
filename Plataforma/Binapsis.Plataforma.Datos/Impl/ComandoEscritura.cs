using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class ComandoEscritura : ComandoTabla
    {
        internal ComandoEscritura(Comando comando, MapeoTabla mapeoTabla) 
            : base(comando, mapeoTabla)
        {
        }

        public override void Ejecutar()
        {
            
        }
    }
}
