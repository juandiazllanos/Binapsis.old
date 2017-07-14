using Binapsis.Plataforma.Configuracion;
using System.Text;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderSentencia 
    {
        StringBuilder _sentencia;
        string _ultimo;

        public BuilderSentencia()
        {
            _sentencia = new StringBuilder();
        }

        public BuilderSentencia Agregar(string valor)
        {
            _sentencia.Append(valor);
            _ultimo = valor;
            return this;
        }
        
        public override string ToString()
        {
            return _sentencia.ToString();
        }

    }
}
