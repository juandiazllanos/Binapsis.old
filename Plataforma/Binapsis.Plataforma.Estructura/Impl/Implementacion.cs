using System;
using Binapsis.Plataforma.Estructura.Interno;

namespace Binapsis.Plataforma.Estructura.Impl
{
    internal class Implementacion : IImplementacion
    {
        private IObjetoDatos _propietario;
        private Contenido _impl;

        internal Implementacion(ITipo tipo)
        {
            _impl = new Contenido(tipo);
        }

        internal Implementacion(ITipo tipo, IObjetoDatos propietario)
            : this(tipo)
        {
            _propietario = propietario;
        }
        

        public IImplementacion Crear(ITipo tipo, IObjetoDatos propietario)
        {
            return FabricaImplementacion.Instancia.Crear(tipo, propietario);            
        }
        
        public void Eliminar()
        {
            //_propietario = null;
        }

        public bool Establecido(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).Establecido();
        }

        public void Establecer(IPropiedad propiedad, object valor)
        {
            _impl.ObtenerCaracteristica(propiedad).Establecer(valor);
        }
        
        public void EstablecerBoolean(IPropiedad propiedad, bool valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerBoolean(valor);
        }
        
        public void EstablecerByte(IPropiedad propiedad, byte valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerByte(valor);
        }
        
        public void EstablecerChar(IPropiedad propiedad, char valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerChar(valor);
        }
        
        public void EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerDateTime(valor);
        }
        
        public void EstablecerDecimal(IPropiedad propiedad, decimal valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerDecimal(valor);
        }
        
        public void EstablecerDouble(IPropiedad propiedad, double valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerDouble(valor);
        }
        
        public void EstablecerFloat(IPropiedad propiedad, float valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerFloat(valor);
        }
        
        public void EstablecerInteger(IPropiedad propiedad, int valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerInteger(valor);
        }
        
        public void EstablecerLong(IPropiedad propiedad, long valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerLong(valor);
        }
        
        public void EstablecerObject(IPropiedad propiedad, object valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerObject(valor);
        }
        
        public void EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerObjetoDatos(valor);
        }
        
        public void EstablecerSByte(IPropiedad propiedad, sbyte valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerSByte(valor);
        }
        
        public void EstablecerShort(IPropiedad propiedad, short valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerShort(valor);
        }
        
        public void EstablecerString(IPropiedad propiedad, string valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerString(valor);
        }
        
        public void EstablecerUInteger(IPropiedad propiedad, uint valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerUInteger(valor);
        }
        
        public void EstablecerULong(IPropiedad propiedad, ulong valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerULong(valor);
        }
        
        public void EstablecerUShort(IPropiedad propiedad, ushort valor)
        {
            _impl.ObtenerCaracteristica(propiedad).EstablecerUShort(valor);
        }
        
        public object Obtener(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).Obtener();
        }
        
        public bool ObtenerBoolean(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerBoolean();
        }
        
        public byte ObtenerByte(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerByte();
        }
        
        public char ObtenerChar(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerChar();
        }
        
        public IColeccion ObtenerColeccion(IPropiedad propiedad)
        {
            return (IColeccion)_impl.ObtenerCaracteristica(propiedad);
        }
        
        public DateTime ObtenerDateTime(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerDateTime();
        }
        
        public decimal ObtenerDecimal(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerDecimal();
        }
        
        public double ObtenerDouble(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerDouble();
        }
        
        public float ObtenerFloat(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerFloat();
        }
        
        public int ObtenerInteger(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerInteger();
        }
        
        public long ObtenerLong(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerLong();
        }
        
        public object ObtenerObject(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerObject();
        }
        
        public IObjetoDatos ObtenerObjetoDatos(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerObjetoDatos();
        }
        
        public sbyte ObtenerSByte(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerSByte();
        }

        public short ObtenerShort(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerShort();
        }

        public string ObtenerString(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerString();
        }
        
        public uint ObtenerUInteger(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerUInteger();
        }
        
        public ulong ObtenerULong(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerULong();
        }
        
        public ushort ObtenerUShort(IPropiedad propiedad)
        {
            return _impl.ObtenerCaracteristica(propiedad).ObtenerUShort();
        }

        public void AgregarObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            _impl.ObtenerCaracteristica(propiedad).AgregarObjetoDatos(item); 
        }

        public void RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            _impl.ObtenerCaracteristica(propiedad).RemoverObjetoDatos(item);
        }

        

        public ITipo Tipo
        {
            get
            {
                return _impl.Tipo;
            }
        }

        public IObjetoDatos Propietario
        {
            get
            {
                return _propietario;
            }
        }
    }
}
