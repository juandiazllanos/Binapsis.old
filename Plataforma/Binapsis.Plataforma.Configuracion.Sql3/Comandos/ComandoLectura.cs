using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal abstract class ComandoLectura : ComandoBase
    {    
        SqlDataReader _reader;
        List<IObjetoDatos> _items;

        public ComandoLectura()
        {
            _items = new List<IObjetoDatos>();
        }

        public override void Ejecutar()
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            using (SqlCommand cmd = new SqlCommand(ComandoSql, cnn))            
            {
                cnn.Open();
                _reader = cmd.ExecuteReader();

                IObjetoDatos item;

                while (_reader.Read())
                {
                    item = Leer();
                    if (item == null) continue;
                    _items.Add(item);
                }
                
                _reader.Dispose();
            }
        }

        protected object Obtener(int col)
        {
            return _reader[col];
        }

        protected abstract IObjetoDatos Leer();
        
        public IEnumerable<IObjetoDatos> Items
        {
            get { return _items; }
        }
        
    }
}
