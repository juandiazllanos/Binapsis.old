using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaSByte : Caracteristica
    {
        sbyte _valor;

		public CaracteristicaSByte(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerSByte(Convert.ToSByte(valor));
        }

        public override void EstablecerSByte(sbyte valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerSByte();
        }

        public override sbyte ObtenerSByte()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return !default(sbyte).Equals(_valor);
        }

    }
}