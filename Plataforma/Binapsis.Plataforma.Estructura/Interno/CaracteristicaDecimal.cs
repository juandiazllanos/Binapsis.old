using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaDecimal : Caracteristica
    {
        decimal _valor;

		public CaracteristicaDecimal(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerDecimal(Convert.ToDecimal(valor));
        }

        public override void EstablecerDecimal(decimal valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerDecimal();
        }

        public override decimal ObtenerDecimal()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return !default(decimal).Equals(_valor);
        }
    }
}