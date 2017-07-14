using System.Text;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class Sentencia
    {
        StringBuilder _valor;

        public Sentencia(string valor)
        {
            _valor = new StringBuilder(valor);
        }
        
        public string Valor
        {
            get => ToString();
        }
        
        public override string ToString()
        {
            return _valor.ToString();
        }
    }
}
