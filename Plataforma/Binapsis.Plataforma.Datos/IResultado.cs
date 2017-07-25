using System;

namespace Binapsis.Plataforma.Datos
{
    public interface IResultado
    {
        object Obtener(string nombre);
        bool ObtenerBoolean(string nombre);        
        byte ObtenerByte(string nombre);        
        char ObtenerChar(string nombre);        
        DateTime ObtenerDateTime(string nombre);
        decimal ObtenerDecimal(string nombre);
        double ObtenerDouble(string nombre);
        float ObtenerFloat(string nombre);
        int ObtenerInteger(string nombre);
        long ObtenerLong(string nombre);
        object ObtenerObject(string nombre);
        sbyte ObtenerSByte(string nombre);
        string ObtenerString(string nombre);
        short ObtenerShort(string nombre);
        uint ObtenerUInteger(string nombre);
        ulong ObtenerULong(string nombre);
        ushort ObtenerUShort(string nombre);

        bool Siguiente();

        //int FilasAfectadas
        //{
        //    get;
        //}
    }
}
