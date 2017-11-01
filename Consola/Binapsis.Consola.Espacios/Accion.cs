using Binapsis.Consola.Definicion;

namespace Binapsis.Consola.Espacios
{
    public class Accion
    {
        public Accion(AccionInfo accionInfo)
        {
            AccionInfo = accionInfo;
        }

        public AccionInfo AccionInfo
        {
            get;
        }

        public Modelo Modelo
        {
            get;
            set;
        }
    }
}
