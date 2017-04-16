
using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaChar : Caracteristica
    {
        char _valor;

		public CaracteristicaChar(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerChar(Convert.ToChar(valor));
        }

        public override void EstablecerChar(char valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerChar();
        }

        public override char ObtenerChar()
        {
            return _valor;
		}

        public override bool Establecido()
        {
            return !default(char).Equals(_valor);
        }
    }
}