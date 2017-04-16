using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Test.Historial.Helpers
{
    class Estado
    {
        public Estado(IObjetoDatos od)
        {
            AtributoBoolean = od.ObtenerBoolean("atributoBoolean");
            AtributoByte = od.ObtenerByte("atributoByte");
            AtributoChar = od.ObtenerChar("atributoChar");
            AtributoDateTime = od.ObtenerDateTime("atributoDateTime");
            AtributoDecimal = od.ObtenerDecimal("atributoDecimal");
            AtributoDouble = od.ObtenerDouble("atributoDouble");
            AtributoFloat = od.ObtenerFloat("atributoFloat");
            AtributoInteger = od.ObtenerInteger("atributoInteger");
            AtributoLong = od.ObtenerLong("atributoLong");
            AtributoSByte = od.ObtenerSByte("atributoSByte");
            AtributoShort = od.ObtenerShort("atributoShort");
            AtributoString = od.ObtenerString("atributoString");
            AtributoUInteger = od.ObtenerUInteger("atributoUInteger");
            AtributoULong = od.ObtenerULong("atributoULong");
            AtributoUShort = od.ObtenerUShort("atributoUShort");
        }

        public bool AtributoBoolean { get; }
        public byte AtributoByte { get; }
        public char AtributoChar { get; }
        public DateTime AtributoDateTime { get; }
        public decimal AtributoDecimal { get; }
        public double AtributoDouble { get; }
        public float AtributoFloat { get; }
        public int AtributoInteger { get; }
        public long AtributoLong { get; }
        public sbyte AtributoSByte { get; }
        public short AtributoShort { get; }
        public string AtributoString { get; }
        public uint AtributoUInteger { get; }
        public ulong AtributoULong { get; }
        public ushort AtributoUShort { get; }
    }
}
