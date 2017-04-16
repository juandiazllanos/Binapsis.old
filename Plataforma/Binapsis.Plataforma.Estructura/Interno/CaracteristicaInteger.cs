using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaInteger : Caracteristica
    {
        int _valor;

		public CaracteristicaInteger(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerInteger(Convert.ToInt32(valor));
        }

        public override void EstablecerInteger(int valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerInteger();
        }

        public override int ObtenerInteger()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return !default(int).Equals(_valor);
        }

    }
}