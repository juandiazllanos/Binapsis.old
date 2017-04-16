using System;

namespace Binapsis.Plataforma.Estructura
{
    public interface IImplementacion 
    {
        IImplementacion Crear(ITipo tipo, IObjetoDatos propietario);

        ITipo Tipo { get; }
        IObjetoDatos Propietario { get; }

        bool Establecido(IPropiedad propiedad);

        void Establecer(IPropiedad propiedad, object valor);
        void EstablecerBoolean(IPropiedad propiedad, bool valor);
        void EstablecerByte(IPropiedad propiedad, byte valor);
        void EstablecerChar(IPropiedad propiedad, char valor);
        void EstablecerDateTime(IPropiedad propiedad, DateTime valor);
        void EstablecerDecimal(IPropiedad propiedad, decimal valor);
        void EstablecerDouble(IPropiedad propiedad, double valor);
        void EstablecerFloat(IPropiedad propiedad, float valor);
        void EstablecerInteger(IPropiedad propiedad, int valor);
        void EstablecerLong(IPropiedad propiedad, long valor);
        void EstablecerObject(IPropiedad propiedad, object valor);
        void EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor);
        void EstablecerSByte(IPropiedad propiedad, sbyte valor);
        void EstablecerShort(IPropiedad propiedad, short valor);
        void EstablecerString(IPropiedad propiedad, string valor);
        void EstablecerUInteger(IPropiedad propiedad, uint valor);
        void EstablecerULong(IPropiedad propiedad, ulong valor);
        void EstablecerUShort(IPropiedad propiedad, ushort valor);

        object Obtener(IPropiedad propiedad);
        bool ObtenerBoolean(IPropiedad propiedad);
        byte ObtenerByte(IPropiedad propiedad);
        char ObtenerChar(IPropiedad propiedad);
        IColeccion ObtenerColeccion(IPropiedad propiedad);
        DateTime ObtenerDateTime(IPropiedad propiedad);
        decimal ObtenerDecimal(IPropiedad propiedad);
        double ObtenerDouble(IPropiedad propiedad);
        float ObtenerFloat(IPropiedad propiedad);
        int ObtenerInteger(IPropiedad propiedad);
        long ObtenerLong(IPropiedad propiedad);
        object ObtenerObject(IPropiedad propiedad);
        IObjetoDatos ObtenerObjetoDatos(IPropiedad propiedad);
        sbyte ObtenerSByte(IPropiedad propiedad);
        short ObtenerShort(IPropiedad propiedad);
        string ObtenerString(IPropiedad propiedad);
        uint ObtenerUInteger(IPropiedad propiedad);
        ulong ObtenerULong(IPropiedad propiedad);
        ushort ObtenerUShort(IPropiedad propiedad);
        
        void AgregarObjetoDatos(IPropiedad propiedad, IObjetoDatos item);
        void RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item);

        void Eliminar();
    }
}