using Binapsis.Consola.Definicion;

namespace Binapsis.Consola
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
