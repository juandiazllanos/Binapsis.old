using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Comandos
{
	internal class ComandoEstablecer : HistorialComando
    {
		public ComandoEstablecer(HistorialEstado caracteristica)
            : base(caracteristica)
        {

		}

        public override void Deshacer()
        {
            _estado.Deshacer(this);
        }

        public override void Deshacer(IImplementacion impl, IPropiedad propiedad, bool valor)
        {
            impl.EstablecerBoolean(propiedad, valor);
		}
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, byte valor)
        {
            impl.EstablecerByte(propiedad, valor);
		}
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, char valor)
        {
            impl.EstablecerChar(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, DateTime valor)
        {
            impl.EstablecerDateTime(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, decimal valor)
        {
            impl.EstablecerDecimal(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, double valor)
        {
            impl.EstablecerDouble(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, float valor)
        {
            impl.EstablecerFloat(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, int valor)
        {
            impl.EstablecerInteger(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, long valor)
        {
            impl.EstablecerLong(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, object valor)
        {
            impl.Establecer(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor)
        {
            impl.EstablecerObjetoDatos(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, sbyte valor)
        {
            impl.EstablecerSByte(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, short valor)
        {
            impl.EstablecerShort(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, string valor)
        {
            impl.EstablecerString(propiedad, valor);
        }

        public override void Deshacer(IImplementacion impl, IPropiedad propiedad, uint valor)
        {
            impl.EstablecerUInteger(propiedad, valor);
        }

        public override void Deshacer(IImplementacion impl, IPropiedad propiedad, ulong valor)
        {
            impl.EstablecerULong(propiedad, valor);
        }
        
		public override void Deshacer(IImplementacion impl, IPropiedad propiedad, ushort valor)
        {
            impl.EstablecerUShort(propiedad, valor);
        }
        
    }

}