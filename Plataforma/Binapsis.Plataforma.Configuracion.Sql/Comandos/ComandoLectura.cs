using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal class ComandoLectura : ComandoBase
    {           
        List<ResultadoLectura> _items;
        List<string> _columnas;

        public ComandoLectura()
        {
            _items = new List<ResultadoLectura>();
            _columnas = new List<string>();
        }

        public ComandoLectura(ISqlBuilder builder) 
            : base(builder)
        {
            _items = new List<ResultadoLectura>();
            _columnas = new List<string>();
        }

        //public override void Ejecutar()
        //{
        //    if (string.IsNullOrEmpty(ComandoSql)) return;

        //    using (SqlConnection cnn = new SqlConnection(CadenaConexion))
        //    using (SqlCommand cmd = new SqlCommand(ComandoSql, cnn))            
        //    {
        //        SqlDataReader reader;

        //        cnn.Open();
        //        reader = cmd.ExecuteReader();

        //        // leer columnas
        //        for (int col = 0; col < reader.FieldCount; col++)
        //            _columnas.Add(reader.GetName(col));
                
        //        // leer filas
        //        while (reader.Read())
        //            _items.Add(new ResultadoLectura(_columnas, reader));

        //        reader.Dispose();
        //    }
        //}
        
        public override void Ejecutar(SqlConnection conexion, SqlTransaction transaccion)
        {
            if (string.IsNullOrEmpty(ComandoSql)) return;

            using (SqlCommand cmd = new SqlCommand(ComandoSql, conexion, transaccion))
            {
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                // leer columnas
                for (int col = 0; col < reader.FieldCount; col++)
                    _columnas.Add(reader.GetName(col));

                // leer filas
                while (reader.Read())
                    _items.Add(new ResultadoLectura(_columnas, reader));

                reader.Dispose();
            }
        }

        public ResultadoLectura[] Resultado
        {
            get { return _items.ToArray(); }
        }
        
    }
}
