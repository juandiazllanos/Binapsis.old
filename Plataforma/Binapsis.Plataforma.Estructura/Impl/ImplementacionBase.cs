using System;

namespace Binapsis.Plataforma.Estructura.Impl
{
    public abstract class ImplementacionBase : IImplementacion
    {
        protected IImplementacion _impl;

        public ImplementacionBase(IImplementacion impl)
        {
            _impl = impl;
        }

        public IImplementacion Impl
        {
            get
            {
                return _impl;
            }
        }

        public IObjetoDatos Propietario
        {
            get
            {
                return _impl.Propietario;
            }
        }

        public ITipo Tipo
        {
            get
            {
                return _impl.Tipo;
            }
        }

        public abstract IImplementacion Crear(ITipo tipo, IObjetoDatos propietario);

        public virtual void AgregarObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            _impl.AgregarObjetoDatos(propiedad, item);
        }
        
        public virtual void Eliminar()
        {
            _impl.Eliminar();
        }

        public virtual bool Establecido(IPropiedad propiedad)
        {
            return _impl.Establecido(propiedad);
        }

        public virtual void Establecer(IPropiedad propiedad, object valor)
        {
            _impl.Establecer(propiedad, valor);
        }

        public virtual void EstablecerBoolean(IPropiedad propiedad, bool valor)
        {
            _impl.EstablecerBoolean(propiedad, valor);
        }

        public virtual void EstablecerByte(IPropiedad propiedad, byte valor)
        {
            _impl.EstablecerByte(propiedad, valor);
        }

        public virtual void EstablecerChar(IPropiedad propiedad, char valor)
        {
            _impl.EstablecerChar(propiedad, valor);
        }

        public virtual void EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        {
            _impl.EstablecerDateTime(propiedad, valor);
        }

        public virtual void EstablecerDecimal(IPropiedad propiedad, decimal valor)
        {
            _impl.EstablecerDecimal(propiedad, valor);
        }

        public virtual void EstablecerDouble(IPropiedad propiedad, double valor)
        {
            _impl.EstablecerDouble(propiedad, valor);
        }

        public virtual void EstablecerFloat(IPropiedad propiedad, float valor)
        {
            _impl.EstablecerFloat(propiedad, valor);
        }

        public virtual void EstablecerInteger(IPropiedad propiedad, int valor)
        {
            _impl.EstablecerInteger(propiedad, valor);
        }

        public virtual void EstablecerLong(IPropiedad propiedad, long valor)
        {
            _impl.EstablecerLong(propiedad, valor);
        }

        public virtual void EstablecerObject(IPropiedad propiedad, object valor)
        {
            _impl.EstablecerObject(propiedad, valor);
        }

        public virtual void EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor)
        {
            _impl.EstablecerObjetoDatos(propiedad, valor);
        }

        public virtual void EstablecerSByte(IPropiedad propiedad, sbyte valor)
        {
            _impl.EstablecerSByte(propiedad, valor);
        }

        public virtual void EstablecerShort(IPropiedad propiedad, short valor)
        {
            _impl.EstablecerShort(propiedad, valor);
        }

        public virtual void EstablecerString(IPropiedad propiedad, string valor)
        {
            _impl.EstablecerString(propiedad, valor);
        }

        public virtual void EstablecerUInteger(IPropiedad propiedad, uint valor)
        {
            _impl.EstablecerUInteger(propiedad, valor);
        }

        public virtual void EstablecerULong(IPropiedad propiedad, ulong valor)
        {
            _impl.EstablecerULong(propiedad, valor);
        }

        public virtual void EstablecerUShort(IPropiedad propiedad, ushort valor)
        {
            _impl.EstablecerUShort(propiedad, valor);
        }

        public virtual object Obtener(IPropiedad propiedad)
        {
            return _impl.Obtener(propiedad);
        }

        public virtual bool ObtenerBoolean(IPropiedad propiedad)
        {
            return _impl.ObtenerBoolean(propiedad);
        }

        public virtual byte ObtenerByte(IPropiedad propiedad)
        {
            return _impl.ObtenerByte(propiedad);
        }

        public virtual char ObtenerChar(IPropiedad propiedad)
        {
            return _impl.ObtenerChar(propiedad);
        }

        public virtual IColeccion ObtenerColeccion(IPropiedad propiedad)
        {
            return _impl.ObtenerColeccion(propiedad);
        }

        public virtual DateTime ObtenerDateTime(IPropiedad propiedad)
        {
            return _impl.ObtenerDateTime(propiedad);
        }

        public virtual decimal ObtenerDecimal(IPropiedad propiedad)
        {
            return _impl.ObtenerDecimal(propiedad);
        }

        public virtual double ObtenerDouble(IPropiedad propiedad)
        {
            return _impl.ObtenerDouble(propiedad);
        }

        public virtual float ObtenerFloat(IPropiedad propiedad)
        {
            return _impl.ObtenerFloat(propiedad);
        }

        public virtual int ObtenerInteger(IPropiedad propiedad)
        {
            return _impl.ObtenerInteger(propiedad);
        }

        public virtual long ObtenerLong(IPropiedad propiedad)
        {
            return _impl.ObtenerLong(propiedad);
        }

        public virtual object ObtenerObject(IPropiedad propiedad)
        {
            return _impl.ObtenerObject(propiedad);
        }

        public virtual IObjetoDatos ObtenerObjetoDatos(IPropiedad propiedad)
        {
            return _impl.ObtenerObjetoDatos(propiedad);
        }

        public virtual sbyte ObtenerSByte(IPropiedad propiedad)
        {
            return _impl.ObtenerSByte(propiedad);
        }

        public virtual short ObtenerShort(IPropiedad propiedad)
        {
            return _impl.ObtenerShort(propiedad);
        }

        public virtual string ObtenerString(IPropiedad propiedad)
        {
            return _impl.ObtenerString(propiedad);
        }

        public virtual uint ObtenerUInteger(IPropiedad propiedad)
        {
            return _impl.ObtenerUInteger(propiedad);
        }

        public virtual ulong ObtenerULong(IPropiedad propiedad)
        {
            return _impl.ObtenerULong(propiedad);
        }

        public virtual ushort ObtenerUShort(IPropiedad propiedad)
        {
            return _impl.ObtenerUShort(propiedad);
        }

        public virtual void RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            _impl.RemoverObjetoDatos(propiedad, item);
        }
        
    }
}
