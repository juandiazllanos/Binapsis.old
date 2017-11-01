using System.Collections.Generic;
using System.Linq;
using Binapsis.Consola.Definicion;

namespace Binapsis.Procesos.Trabajos
{
    public class Resultados
    {
        List<Resultado> _items = new List<Resultado>();

        public Resultado Crear(ResultadoInfo resultadoInfo)
        {
            Resultado resultado = new Resultado(resultadoInfo);
            _items.Add(resultado);
            return resultado;
        }

        public Resultado Obtener(string resultado)
        {
            return _items.FirstOrDefault(item => item.Valor == resultado);
        }

        public Resultado this[string nombre]
        {
            get => Obtener(nombre);
        }
    }
}
