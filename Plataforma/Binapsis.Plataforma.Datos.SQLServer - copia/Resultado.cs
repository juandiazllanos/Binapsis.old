using System;
using System.Data.SqlClient;

namespace Binapsis.Plataforma.Datos.SQLServer
{
    class Resultado : IResultado
    {
        SqlDataReader _reader;

        public Resultado(SqlDataReader reader)
        {
            _reader = reader;
        }
        
        public object Obtener(string nombre)
        {
            return _reader.GetValue(ObtenerIndiceColumna(nombre));
        }

        public bool ObtenerBoolean(string nombre)
        {
            return _reader.GetBoolean(ObtenerIndiceColumna(nombre));
        }

        public byte ObtenerByte(string nombre)
        {
            return _reader.GetByte(ObtenerIndiceColumna(nombre));
        }

        public char ObtenerChar(string nombre)
        {
            return _reader.GetChar(ObtenerIndiceColumna(nombre));
        }

        public DateTime ObtenerDateTime(string nombre)
        {
            return _reader.GetDateTime(ObtenerIndiceColumna(nombre));
        }

        public decimal ObtenerDecimal(string nombre)
        {
            return _reader.GetDecimal(ObtenerIndiceColumna(nombre));
        }

        public double ObtenerDouble(string nombre)
        {
            return _reader.GetDouble(ObtenerIndiceColumna(nombre));
        }

        public float ObtenerFloat(string nombre)
        {
            return _reader.GetFloat(ObtenerIndiceColumna(nombre));
        }

        public int ObtenerInteger(string nombre)
        {
            return _reader.GetInt32(ObtenerIndiceColumna(nombre));
        }

        public long ObtenerLong(string nombre)
        {
            return _reader.GetInt64(ObtenerIndiceColumna(nombre));
        }

        public object ObtenerObject(string nombre)
        {
            return Obtener(nombre);
        }

        public sbyte ObtenerSByte(string nombre)
        {
            return _reader.GetFieldValue<sbyte>(ObtenerIndiceColumna(nombre));
        }

        public short ObtenerShort(string nombre)
        {
            return _reader.GetFieldValue<short>(ObtenerIndiceColumna(nombre));
        }

        public string ObtenerString(string nombre)
        {
            return _reader.GetString(ObtenerIndiceColumna(nombre));
        }

        public uint ObtenerUInteger(string nombre)
        {
            return _reader.GetFieldValue<uint>(ObtenerIndiceColumna(nombre));
        }

        public ulong ObtenerULong(string nombre)
        {
            return _reader.GetFieldValue<ulong>(ObtenerIndiceColumna(nombre));
        }

        public ushort ObtenerUShort(string nombre)
        {
            return _reader.GetFieldValue<ushort>(ObtenerIndiceColumna(nombre));
        }

        private int ObtenerIndiceColumna(string nombre)
        {
            return _reader.GetOrdinal(nombre?.ToUpper());
        }

        public bool Siguiente()
        {
            bool leido = _reader != null && _reader.Read();
            if (!leido && !_reader.IsClosed) _reader.Dispose();
            return leido;
        }
    }
}
