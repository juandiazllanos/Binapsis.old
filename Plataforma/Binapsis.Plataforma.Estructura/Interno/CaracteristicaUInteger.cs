using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaUInteger : Caracteristica
    {
        uint _valor;

		public CaracteristicaUInteger(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerUInteger(Convert.ToUInt32(valor));
        }

        public override void EstablecerUInteger(uint valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerUInteger();
        }

        public override uint ObtenerUInteger()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return !default(uint).Equals(_valor);
        }

    }
}