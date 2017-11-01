using Binapsis.Consola.Definicion;

namespace Binapsis.Procesos.Trabajos
{
    public class Resultado
    {
        public Resultado(ResultadoInfo resultadoInfo)
        {
            ResultadoInfo = resultadoInfo;
        }

        private ResultadoInfo ResultadoInfo
        {
            get;
        }

        public string Valor
        {
            get => ResultadoInfo.Nombre;
        }
    }
}
