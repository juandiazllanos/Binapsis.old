using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class ComandoTabla : ComandoBase
    {
        internal ComandoTabla(Comando comando, MapeoTabla mapeoTabla)
            : base(comando, new ParametrosTabla(comando, mapeoTabla))
        {
            MapeoTabla = mapeoTabla;
        }

        internal MapeoTabla MapeoTabla
        {
            get;
        }

        public Tabla Tabla
        {
            get => MapeoTabla?.Tabla;
        }

    }
}
