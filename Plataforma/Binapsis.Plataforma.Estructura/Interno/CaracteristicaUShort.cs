using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaUShort : Caracteristica
    {
        ushort _valor;

		public CaracteristicaUShort(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerUShort(Convert.ToUInt16(valor));
        }

        public override void EstablecerUShort(ushort valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerUShort();
        }

        public override ushort ObtenerUShort()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return !default(ushort).Equals(_valor);
        }

    }
}