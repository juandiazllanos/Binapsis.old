using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaULong : Caracteristica
    {
        ulong _valor;

		public CaracteristicaULong(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerULong(Convert.ToUInt64(valor));
        }

        public override void EstablecerULong(ulong valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerULong();
        }

        public override ulong ObtenerULong()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return !default(ulong).Equals(_valor);
        }
    }
}