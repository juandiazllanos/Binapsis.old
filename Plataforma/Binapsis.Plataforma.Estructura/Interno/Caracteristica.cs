using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal abstract class Caracteristica
    {
        public Caracteristica(IPropiedad propiedad)
        {
            Propiedad = propiedad;
		}

        public virtual bool Establecido()
        {
            return false;
        }

        public virtual void AgregarObjetoDatos(IObjetoDatos item)
        {

		}
                
        public virtual void Establecer(object valor)
        {
            throw new NotImplementedException();
        }

		public virtual void EstablecerBoolean(bool valor)
        {

		}
        
		public virtual void EstablecerByte(byte valor)
        {

		}
        
		public virtual void EstablecerChar(char valor)
        {

		}
        
		public virtual void EstablecerDateTime(DateTime valor)
        {

		}
        
		public virtual void EstablecerDecimal(decimal valor)
        {

		}
        
		public virtual void EstablecerDouble(double valor)
        {

		}

		public virtual void EstablecerFloat(float valor)
        {

		}

		public virtual void EstablecerInteger(int valor)
        {

		}
        
		public virtual void EstablecerLong(long valor)
        {

		}

		public virtual void EstablecerObject(object valor)
        {

		}

        public virtual void EstablecerObjetoDatos(IObjetoDatos valor)
        {

		}
        
		public virtual void EstablecerObjetoDatos(int indice, IObjetoDatos item)
        {

		}
        
		public virtual void EstablecerSByte(sbyte valor)
        {

		}
        
		public virtual void EstablecerShort(short valor)
        {

		}

		public virtual void EstablecerString(string valor)
        {

		}

		public virtual void EstablecerUInteger(uint valor)
        {

		}
        
		public virtual void EstablecerULong(ulong valor)
        {

		}
        
		public virtual void EstablecerUShort(ushort valor)
        {

		}

        public virtual object Obtener()
        {
            return null;
        }

		public virtual bool ObtenerBoolean()
        {
			return false;
		}

		public virtual byte ObtenerByte()
        {
			return 0;
		}

		public virtual char ObtenerChar()
        {
			return default(Char);
		}

		public virtual DateTime ObtenerDateTime()
        {
			return default(DateTime);
		}

		public virtual decimal ObtenerDecimal()
        {
			return 0;
		}

		public virtual double ObtenerDouble()
        {
			return 0;
		}

		public virtual float ObtenerFloat()
        {
			return 0;
		}

		public virtual int ObtenerInteger()
        {
			return 0;
		}

		public virtual long ObtenerLong()
        {
			return 0;
		}

		public virtual object ObtenerObject()
        {
			return null;
		}

		public virtual IObjetoDatos ObtenerObjetoDatos()
        {
			return null;
		}
        
		public virtual IObjetoDatos ObtenerObjetoDatos(int indice)
        {
			return null;
		}

		public virtual sbyte ObtenerSByte()
        {
			return 0;
		}

		public virtual short ObtenerShort()
        {
			return 0;
		}

		public virtual string ObtenerString()
        {
			return default(String);
		}

		public virtual uint ObtenerUInteger()
        {
			return 0;
		}

		public virtual ulong ObtenerULong()
        {
			return 0;
		}

		public virtual ushort ObtenerUShort()
        {
			return 0;
		}
        
		public virtual void RemoverObjetoDatos(IObjetoDatos item)
        {

		}

        public IPropiedad Propiedad { get; private set; }

    }
}