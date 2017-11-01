using Binapsis.Consola.Definicion;

namespace Binapsis.Consola.Espacios
{
    public class Modelo
    {
        public Modelo(ModeloInfo modeloInfo, object objeto)
        {
            ModeloInfo = modeloInfo;
            Objeto = objeto;
        }

        public ModeloInfo ModeloInfo
        {
            get;
        }

        public object Objeto
        {
            get;
        }
    }
}
