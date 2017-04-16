using System;
using System.IO;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Interno;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Serializacion.Impl
{
    public abstract class LectorBase : ILector
    {
        Stream _stream;
        HeapId _oid;

        public LectorBase()        
        {
            _oid = new HeapId();
        }
        
        protected LectorBase(LectorBase lector)
        {
            _oid = lector._oid;
            _stream = lector._stream;
        }
        
        public ITipo Tipo { get; private set; }

        public Stream Stream
        {
            get { return _stream; }
            set { EstablecerStream(value); }
        }
        
        protected virtual void EstablecerStream(Stream stream)
        {
            _stream = stream;
        }

        public virtual void Leer(IObjetoDatos od)
        {
            if (od == null) return;

            int id = LeerId();

            if (!_oid.Existe(id))
                _oid.Agregar(od, id);

            Tipo = od.Tipo;
            IPropiedad propiedad = Leer();
            
            while (propiedad != null)
            {
                //System.Diagnostics.Debug.WriteLine(string.Format("[id={0}] - {1}", id, propiedad.Nombre));

                Leer(od, propiedad);
                propiedad = Leer();
            }

        }
        
        void Leer(IObjetoDatos od, IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                LeerAtributo(od, propiedad);
            else
                LeerReferencia(od, propiedad);
        }

        void LeerReferencia(IObjetoDatos od, IPropiedad propiedad)
        {
            ILector lector = Crear();
            int id = lector.LeerId();

            IObjetoDatos valor = CrearObjetoDatos(od, propiedad, id);

            if (propiedad.Asociacion == Asociacion.Agregacion)
                od.EstablecerObjetoDatos(propiedad, valor);
            
            lector.Leer(valor);
        }

        private IObjetoDatos CrearObjetoDatos(IObjetoDatos od, IPropiedad propiedad, int id)
        {
            IObjetoDatos valor = null;

            if (propiedad.Asociacion == Asociacion.Composicion)
                valor = od.CrearObjetoDatos(propiedad);
            else if (_oid.Existe(id))
                valor = _oid.Obtener(id);
            else
                valor = CrearObjetoDatos(propiedad.Tipo);
            
            return valor;
        }
        
        protected virtual IObjetoDatos CrearObjetoDatos(ITipo tipo)
        {
            return Fabrica.Instancia.Crear(tipo);
        }

        protected abstract ILector Crear();

        void LeerAtributo(IObjetoDatos od, IPropiedad atributo)
        {
            switch(atributo.Tipo.Nombre)
            {
                case "Boolean":
                    od.EstablecerBoolean(atributo, LeerBoolean());
                    break;
                case "Byte":
                    od.EstablecerByte(atributo, LeerByte());
                    break;
                case "Char":
                    od.EstablecerChar(atributo, LeerChar());
                    break;
                case "DateTime":
                    od.EstablecerDateTime(atributo, LeerDateTime());
                    break;
                case "Decimal":
                    od.EstablecerDecimal(atributo, LeerDecimal());
                    break;
                case "Double":
                    od.EstablecerDouble(atributo, LeerDouble());
                    break;
                case "Single":
                    od.EstablecerFloat(atributo, LeerFloat());
                    break;
                case "Int32":
                    od.EstablecerInteger(atributo, LeerInteger());
                    break;
                case "Int64":
                    od.EstablecerLong(atributo, LeerLong());
                    break;
                case "SByte":
                    od.EstablecerSByte(atributo, LeerSByte());
                    break;
                case "Int16":
                    od.EstablecerShort(atributo, LeerShort());
                    break;
                case "String":
                    od.EstablecerString(atributo, LeerString());
                    break;
                case "UInt32":
                    od.EstablecerUInteger(atributo, LeerUInteger());
                    break;
                case "UInt64":
                    od.EstablecerULong(atributo, LeerULong());
                    break;
                case "UInt16":
                    od.EstablecerUShort(atributo, LeerUShort());
                    break;
            }
        }

        public abstract int LeerId();

        public abstract IPropiedad Leer();
        public abstract bool LeerBoolean();
        public abstract byte LeerByte();
        public abstract char LeerChar();
        public abstract DateTime LeerDateTime();
        public abstract decimal LeerDecimal();
        public abstract double LeerDouble();
        public abstract float LeerFloat();        
        public abstract int LeerInteger();
        public abstract long LeerLong();
        public abstract object LeerObject();
        public abstract sbyte LeerSByte();
        public abstract short LeerShort();
        public abstract string LeerString();
        public abstract uint LeerUInteger();
        public abstract ulong LeerULong();
        public abstract ushort LeerUShort();

        
    }
}
