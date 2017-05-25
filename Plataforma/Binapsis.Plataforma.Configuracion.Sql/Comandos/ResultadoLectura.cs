using System.Collections.Generic;
using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal class ResultadoLectura
    {
        List<string> _columnas;
        object[] _fila;


        public ResultadoLectura(List<string> columnas, SqlDataReader reader)
        {
            _columnas = columnas;
            _fila = new object[reader.FieldCount];            
            reader.GetValues(_fila); 
        }

        public object Obtener(string columna)
        {
            if (_columnas.Contains(columna))
                return Obtener(_columnas.IndexOf(columna));
            else
                throw new System.IndexOutOfRangeException ($"{columna} no existe");
        }

        public object Obtener(int columna)
        {
            return _fila[columna];
        }
        
        public object this[string columna]
        {
            get { return Obtener(columna); }
        }

        public object this[int columna]
        {
            get { return Obtener(columna); }
        }
    }
}
