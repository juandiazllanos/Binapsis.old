using System.Text;

namespace Binapsis.Plataforma.AgenteConfiguracion
{
    public class Filtro
    {
        StringBuilder _filtro;
        public Filtro()
        {
            _filtro = new StringBuilder();
        }

        public void Agregar(string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            if (_filtro.Length != 0) _filtro.Append("&");
            _filtro.Append($"{key}={value}");
        }

        public override string ToString()
        {
            return _filtro.ToString();
        }
    }
}
