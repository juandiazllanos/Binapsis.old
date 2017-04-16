using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaDateTime : Caracteristica
    {
        DateTime _valor;

		public CaracteristicaDateTime(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerDateTime(Convert.ToDateTime(valor));
        }

        public override void EstablecerDateTime(DateTime valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerDateTime();
        }

        public override DateTime ObtenerDateTime()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return !default(DateTime).Equals(_valor);
        }
    }
}