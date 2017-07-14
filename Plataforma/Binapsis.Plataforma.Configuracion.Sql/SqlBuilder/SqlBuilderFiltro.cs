using System;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderFiltro
    {
        StringBuilder _filtro;

        public SqlBuilderFiltro()
        {
            _filtro = new StringBuilder();
        }

        public void Agregar(string campo, string valor)
        {
            if (string.IsNullOrEmpty(valor)) return;
            Agregar("and", campo, "=", $"'{valor}'");
        }
        
        public void Agregar(string campo, int valor)
        {
            Agregar("and", campo, "=", $"{valor}");
        }

        public void Agregar(string campo, bool valor)
        {
            Agregar("and", campo, "=", $"{Convert.ToByte(valor)}");
        }
        
        private void Agregar(string andor, string campo, string operador, string valor)
        {
            if (string.IsNullOrEmpty(valor)) return;

            if (_filtro.Length != 0) _filtro.Append($" {andor} ");
            _filtro.Append($"{campo}{operador}{valor}");
        }

        public override string ToString()
        {
            return _filtro.ToString();
        }

    }
}
