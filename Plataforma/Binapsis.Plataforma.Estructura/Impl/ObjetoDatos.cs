using System;

namespace Binapsis.Plataforma.Estructura.Impl
{
    public class ObjetoDatos : ObjetoBase
    {

        public ObjetoDatos(IImplementacion impl)
            : base(impl)
        {            
        }
        
        public new IObjetoDatos Propietario
        {
            get
            {
                return base.Propietario;
            }
        }

        public new ITipo Tipo
        {
            get
            {
                return base.Tipo;
            }
        }
        

        public new IObjetoDatos CrearObjetoDatos(int indice)
        {
            return CrearObjetoDatos(indice);            
        }

        public new IObjetoDatos CrearObjetoDatos(IPropiedad propiedad)
        {
            return base.CrearObjetoDatos(propiedad);
        }

        public new IObjetoDatos CrearObjetoDatos(string ruta)
        {
            return CrearObjetoDatos(ruta);
        }

        

        public new void Eliminar()
        {
            base.Eliminar();
        }

        public new void Establecer(int indice, object valor)
        {
            base.Establecer(indice, valor);
        }

        public new void Establecer(IPropiedad propiedad, object valor)
        {
            base.Establecer(propiedad, valor);
        }

        public new void Establecer(string ruta, object valor)
        {
            base.Establecer(ruta, valor);
        }

        public new void EstablecerBoolean(int indice, bool valor)
        {
            base.EstablecerBoolean(indice, valor);
        }

        public new void EstablecerBoolean(IPropiedad propiedad, bool valor)
        {
            base.EstablecerBoolean(propiedad, valor);
        }

        public new void EstablecerBoolean(string ruta, bool valor)
        {
            base.EstablecerBoolean(ruta, valor);
        }

        public new void EstablecerByte(int indice, byte valor)
        {
            base.EstablecerByte(indice, valor);
        }

        public new void EstablecerByte(IPropiedad propiedad, byte valor)
        {
            base.EstablecerByte(propiedad, valor);
        }

        public new void EstablecerByte(string ruta, byte valor)
        {
            base.EstablecerByte(ruta, valor);
        }

        public new void EstablecerChar(int indice, char valor)
        {
            base.EstablecerChar(indice, valor);
        }

        public new void EstablecerChar(IPropiedad propiedad, char valor)
        {
            base.EstablecerChar(propiedad, valor);
        }

        public new void EstablecerChar(string ruta, char valor)
        {
            base.EstablecerChar(ruta, valor);
        }

        public new void EstablecerDateTime(int indice, DateTime valor)
        {
            base.EstablecerDateTime(indice, valor);
        }

        public new void EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        {
            base.EstablecerDateTime(propiedad, valor);
        }

        public new void EstablecerDateTime(string ruta, DateTime valor)
        {
            base.EstablecerDateTime(ruta, valor);
        }

        public new void EstablecerDecimal(int indice, decimal valor)
        {
            base.EstablecerDecimal(indice, valor);
        }

        public new void EstablecerDecimal(IPropiedad propiedad, decimal valor)
        {
            base.EstablecerDecimal(propiedad, valor);
        }

        public new void EstablecerDecimal(string ruta, decimal valor)
        {
            base.EstablecerDecimal(ruta, valor);
        }

        public new void EstablecerDouble(int indice, double valor)
        {
            base.EstablecerDouble(indice, valor);
        }

        public new void EstablecerDouble(IPropiedad propiedad, double valor)
        {
            base.EstablecerDouble(propiedad, valor);
        }

        public new void EstablecerDouble(string ruta, double valor)
        {
            base.EstablecerDouble(ruta, valor);
        }

        public new void EstablecerFloat(int indice, float valor)
        {
            base.EstablecerFloat(indice, valor);
        }

        public new void EstablecerFloat(IPropiedad propiedad, float valor)
        {
            base.EstablecerFloat(propiedad, valor);
        }

        public new void EstablecerFloat(string ruta, float valor)
        {
            base.EstablecerFloat(ruta, valor);
        }

        public new void EstablecerInteger(int indice, int valor)
        {
            base.EstablecerInteger(indice, valor);
        }

        public new void EstablecerInteger(IPropiedad propiedad, int valor)
        {
            base.EstablecerInteger(propiedad, valor);
        }

        public new void EstablecerInteger(string ruta, int valor)
        {
            base.EstablecerInteger(ruta, valor);
        }

        public new void EstablecerLong(int indice, long valor)
        {
            base.EstablecerLong(indice, valor);
        }

        public new void EstablecerLong(IPropiedad propiedad, long valor)
        {
            base.EstablecerLong(propiedad, valor);
        }

        public new void EstablecerLong(string ruta, long valor)
        {
            base.EstablecerLong(ruta, valor);
        }

        public new void EstablecerObject(int indice, object valor)
        {
            base.EstablecerObject(indice, valor);
        }

        public new void EstablecerObject(IPropiedad propiedad, object valor)
        {
            base.EstablecerObject(propiedad, valor);
        }

        public new void EstablecerObject(string ruta, object valor)
        {
            base.EstablecerObject(ruta, valor);
        }

        public new void EstablecerObjetoDatos(int indice, IObjetoDatos valor)
        {
            base.EstablecerObjetoDatos(indice, valor);
        }

        public new void EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor)
        {
            base.EstablecerObjetoDatos(propiedad, valor);
        }

        public new void EstablecerObjetoDatos(string ruta, IObjetoDatos valor)
        {
            base.EstablecerObjetoDatos(ruta, valor);
        }

        public new void EstablecerSByte(int indice, sbyte valor)
        {
            base.EstablecerSByte(indice, valor);
        }

        public new void EstablecerSByte(IPropiedad propiedad, sbyte valor)
        {
            base.EstablecerSByte(propiedad, valor);
        }

        public new void EstablecerSByte(string ruta, sbyte valor)
        {
            base.EstablecerSByte(ruta, valor);
        }

        public new void EstablecerShort(int indice, short valor)
        {
            base.EstablecerShort(indice, valor);
        }

        public new void EstablecerShort(IPropiedad propiedad, short valor)
        {
            base.EstablecerShort(propiedad, valor);
        }

        public new void EstablecerShort(string ruta, short valor)
        {
            base.EstablecerShort(ruta, valor);
        }

        public new void EstablecerString(int indice, string valor)
        {
            base.EstablecerString(indice, valor);
        }

        public new void EstablecerString(IPropiedad propiedad, string valor)
        {
            base.EstablecerString(propiedad, valor);
        }

        public new void EstablecerString(string ruta, string valor)
        {
            base.EstablecerString(ruta, valor);
        }

        public new void EstablecerUInteger(int indice, uint valor)
        {
            base.EstablecerUInteger(indice, valor);
        }

        public new void EstablecerUInteger(IPropiedad propiedad, uint valor)
        {
            base.EstablecerUInteger(propiedad, valor);
        }

        public new void EstablecerUInteger(string ruta, uint valor)
        {
            base.EstablecerUInteger(ruta, valor);
        }

        public new void EstablecerULong(int indice, ulong valor)
        {
            base.EstablecerULong(indice, valor);
        }

        public new void EstablecerULong(IPropiedad propiedad, ulong valor)
        {
            base.EstablecerULong(propiedad, valor);
        }

        public new void EstablecerULong(string ruta, ulong valor)
        {
            base.EstablecerULong(ruta, valor);
        }

        public new void EstablecerUShort(int indice, ushort valor)
        {
            base.EstablecerUShort(indice, valor);
        }

        public new void EstablecerUShort(IPropiedad propiedad, ushort valor)
        {
            base.EstablecerUShort(propiedad, valor);
        }

        public new void EstablecerUShort(string ruta, ushort valor)
        {
            base.EstablecerUShort(ruta, valor);
        }

        public new bool Establecido(int indice)
        {
            return base.Establecido(indice);
        }

        public new bool Establecido(IPropiedad propiedad)
        {
            return base.Establecido(propiedad);
        }

        public new bool Establecido(string ruta)
        {
            return base.Establecido(ruta);
        }

        public new object Obtener(int indice)
        {
            return base.Obtener(indice);
        }

        public new object Obtener(IPropiedad propiedad)
        {
            return base.Obtener(propiedad);
        }

        public new object Obtener(string ruta)
        {
            return base.Obtener(ruta);
        }

        public new bool ObtenerBoolean(int indice)
        {
            return base.ObtenerBoolean(indice);
        }

        public new bool ObtenerBoolean(IPropiedad propiedad)
        {
            return base.ObtenerBoolean(propiedad);
        }

        public new bool ObtenerBoolean(string ruta)
        {
            return base.ObtenerBoolean(ruta);
        }

        public new byte ObtenerByte(int indice)
        {
            return base.ObtenerByte(indice);
        }

        public new byte ObtenerByte(IPropiedad propiedad)
        {
            return base.ObtenerByte(propiedad);
        }

        public new byte ObtenerByte(string ruta)
        {
            return base.ObtenerByte(ruta);
        }

        public new char ObtenerChar(int indice)
        {
            return base.ObtenerChar(indice);
        }

        public new char ObtenerChar(IPropiedad propiedad)
        {
            return base.ObtenerChar(propiedad);
        }

        public new char ObtenerChar(string ruta)
        {
            return base.ObtenerChar(ruta);
        }

        public new IColeccion ObtenerColeccion(int indice)
        {
            return base.ObtenerColeccion(indice);
        }

        public new IColeccion ObtenerColeccion(IPropiedad propiedad)
        {
            return base.ObtenerColeccion(propiedad);
        }

        public new IColeccion ObtenerColeccion(string ruta)
        {
            return base.ObtenerColeccion(ruta);
        }

        public new DateTime ObtenerDateTime(int indice)
        {
            return base.ObtenerDateTime(indice);
        }

        public new DateTime ObtenerDateTime(IPropiedad propiedad)
        {
            return base.ObtenerDateTime(propiedad);
        }

        public new DateTime ObtenerDateTime(string ruta)
        {
            return base.ObtenerDateTime(ruta);
        }

        public new decimal ObtenerDecimal(int indice)
        {
            return base.ObtenerDecimal(indice);
        }

        public new decimal ObtenerDecimal(IPropiedad propiedad)
        {
            return base.ObtenerDecimal(propiedad);
        }

        public new decimal ObtenerDecimal(string ruta)
        {
            return base.ObtenerDecimal(ruta);
        }

        public new double ObtenerDouble(int indice)
        {
            return base.ObtenerDouble(indice);
        }

        public new double ObtenerDouble(IPropiedad propiedad)
        {
            return base.ObtenerDouble(propiedad);
        }

        public new double ObtenerDouble(string ruta)
        {
            return base.ObtenerDouble(ruta);
        }

        public new float ObtenerFloat(int indice)
        {
            return base.ObtenerFloat(indice);
        }

        public new float ObtenerFloat(IPropiedad propiedad)
        {
            return base.ObtenerFloat(propiedad);
        }

        public new float ObtenerFloat(string ruta)
        {
            return base.ObtenerFloat(ruta);
        }

        public new int ObtenerInteger(int indice)
        {
            return base.ObtenerInteger(indice);
        }

        public new int ObtenerInteger(IPropiedad propiedad)
        {
            return base.ObtenerInteger(propiedad);
        }

        public new int ObtenerInteger(string ruta)
        {
            return base.ObtenerInteger(ruta);
        }

        public new long ObtenerLong(int indice)
        {
            return base.ObtenerLong(indice);
        }

        public new long ObtenerLong(IPropiedad propiedad)
        {
            return base.ObtenerLong(propiedad);
        }

        public new long ObtenerLong(string ruta)
        {
            return base.ObtenerLong(ruta);
        }

        public new object ObtenerObject(int indice)
        {
            return base.ObtenerObject(indice);
        }

        public new object ObtenerObject(IPropiedad propiedad)
        {
            return base.ObtenerObject(propiedad);
        }

        public new object ObtenerObject(string ruta)
        {
            return base.ObtenerObject(ruta);
        }

        public new IObjetoDatos ObtenerObjetoDatos(int indice)
        {
            return base.ObtenerObjetoDatos(indice);
        }

        public new IObjetoDatos ObtenerObjetoDatos(IPropiedad propiedad)
        {
            return base.ObtenerObjetoDatos(propiedad);
        }

        public new IObjetoDatos ObtenerObjetoDatos(string ruta)
        {
            return base.ObtenerObjetoDatos(ruta);
        }

        public new sbyte ObtenerSByte(int indice)
        {
            return base.ObtenerSByte(indice);
        }

        public new sbyte ObtenerSByte(IPropiedad propiedad)
        {
            return base.ObtenerSByte(propiedad);
        }

        public new sbyte ObtenerSByte(string ruta)
        {
            return base.ObtenerSByte(ruta);
        }

        public new short ObtenerShort(int indice)
        {
            return base.ObtenerShort(indice);
        }

        public new short ObtenerShort(IPropiedad propiedad)
        {
            return base.ObtenerShort(propiedad);
        }

        public new short ObtenerShort(string ruta)
        {
            return base.ObtenerShort(ruta);
        }

        public new string ObtenerString(int indice)
        {
            return base.ObtenerString(indice);
        }

        public new string ObtenerString(IPropiedad propiedad)
        {
            return base.ObtenerString(propiedad);
        }

        public new string ObtenerString(string ruta)
        {
            return base.ObtenerString(ruta);
        }

        public new uint ObtenerUInteger(int indice)
        {
            return base.ObtenerUInteger(indice);
        }

        public new uint ObtenerUInteger(IPropiedad propiedad)
        {
            return base.ObtenerUInteger(propiedad);
        }

        public new uint ObtenerUInteger(string ruta)
        {
            return base.ObtenerUInteger(ruta);
        }

        public new ulong ObtenerULong(int indice)
        {
            return base.ObtenerULong(indice);
        }

        public new ulong ObtenerULong(IPropiedad propiedad)
        {
            return base.ObtenerULong(propiedad);
        }

        public new ulong ObtenerULong(string ruta)
        {
            return base.ObtenerULong(ruta);
        }

        public new ushort ObtenerUShort(int indice)
        {
            return base.ObtenerUShort(indice);
        }

        public new ushort ObtenerUShort(IPropiedad propiedad)
        {
            return base.ObtenerUShort(propiedad);
        }

        public new ushort ObtenerUShort(string ruta)
        {
            return base.ObtenerUShort(ruta);
        }

        public new void RemoverObjetoDatos(int indice, IObjetoDatos item)
        {
            base.RemoverObjetoDatos(indice, item);
        }

        public new void RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            base.RemoverObjetoDatos(propiedad, item);
        }

        public new void RemoverObjetoDatos(string nombre, IObjetoDatos item)
        {
            base.RemoverObjetoDatos(nombre, item);
        }

    }    
}
