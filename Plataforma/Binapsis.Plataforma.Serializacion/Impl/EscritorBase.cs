using System;
using System.IO;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Impl
{
    public abstract class EscritorBase : IEscritor
    {
        Stream _strm;

        public EscritorBase()            
        {            
        }

        public virtual Stream Stream
        {
            get { return _strm; }
            set { EstablecerStream(value); }
        }

        protected virtual void EstablecerStream(Stream stream)
        {
            _strm = stream;
            _strm.SetLength(0);
        }
        
        public virtual void Escribir(INodoObjeto objeto)
        {
            // escribir id
            EscribirId(objeto.Id);
            // escribir atributos
            foreach (IPropiedad atrib in objeto.Atributos)
                Escribir(objeto.ObjetoDatos, atrib);            
            // escribir referencias
            foreach (INodoReferencia refer in objeto.Referencias)
                Escribir(refer);
        }

        protected virtual void Escribir(INodoReferencia refer)
        {
            foreach (INodoObjeto obj in refer.Objetos)
                EscribirObjetoDatos(refer.Propiedad, obj);
        }

        protected virtual void Escribir(IObjetoDatos od, IPropiedad propiedad)
        {
            switch (propiedad.Tipo.Nombre)
            {
                case "Boolean":
                    EscribirBoolean(propiedad, od.ObtenerBoolean(propiedad));
                    break;
                case "Byte":
                    EscribirByte(propiedad, od.ObtenerByte(propiedad));
                    break;
                case "Char":
                    EscribirChar(propiedad, od.ObtenerChar(propiedad));
                    break;
                case "DateTime":
                    EscribirDateTime(propiedad, od.ObtenerDateTime(propiedad));
                    break;
                case "Decimal":
                    EscribirDecimal(propiedad, od.ObtenerDecimal(propiedad));
                    break;
                case "Double":
                    EscribirDouble(propiedad, od.ObtenerDouble(propiedad));
                    break;
                case "Single":
                    EscribirFloat(propiedad, od.ObtenerFloat(propiedad));
                    break;
                case "Int32":
                    EscribirInteger(propiedad, od.ObtenerInteger(propiedad));
                    break;
                case "Int64":
                    EscribirLong(propiedad, od.ObtenerLong(propiedad));
                    break;
                case "SByte":
                    EscribirSByte(propiedad, od.ObtenerSByte(propiedad));
                    break;
                case "Int16":
                    EscribirShort(propiedad, od.ObtenerShort(propiedad));
                    break;
                case "String":
                    EscribirString(propiedad, od.ObtenerString(propiedad));
                    break;
                case "UInt32":
                    EscribirUInteger(propiedad, od.ObtenerUInteger(propiedad));
                    break;
                case "UInt64":
                    EscribirULong(propiedad, od.ObtenerULong(propiedad));
                    break;
                case "UInt16":
                    EscribirUShort(propiedad, od.ObtenerUShort(propiedad));
                    break;
            }
        }

        public abstract void EscribirId(int id);

        public abstract void EscribirBoolean(IPropiedad propiedad, bool valor);
        public abstract void EscribirByte(IPropiedad propiedad, byte valor);
        public abstract void EscribirChar(IPropiedad propiedad, char valor);
        public abstract void EscribirDateTime(IPropiedad propiedad, DateTime valor);
        public abstract void EscribirDecimal(IPropiedad propiedad, decimal valor);
        public abstract void EscribirDouble(IPropiedad propiedad, double valor);
        public abstract void EscribirFloat(IPropiedad propiedad, float valor);        
        public abstract void EscribirInteger(IPropiedad propiedad, int valor);
        public abstract void EscribirLong(IPropiedad propiedad, long valor);
        public abstract void EscribirObject(IPropiedad propiedad, object valor);
        public abstract void EscribirObjetoDatos(IPropiedad propiedad, INodoObjeto valor);
        public abstract void EscribirSByte(IPropiedad propiedad, sbyte valor);
        public abstract void EscribirShort(IPropiedad propiedad, short valor);
        public abstract void EscribirString(IPropiedad propiedad, string valor);
        public abstract void EscribirUInteger(IPropiedad propiedad, uint valor);
        public abstract void EscribirULong(IPropiedad propiedad, ulong valor);
        public abstract void EscribirUShort(IPropiedad propiedad, ushort valor);
                
    }
}
