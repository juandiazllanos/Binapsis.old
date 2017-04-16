
using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaBoolean : Caracteristica
    {
        private bool _valor;

		public CaracteristicaBoolean(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerBoolean(Convert.ToBoolean(valor));
        }

        public override void EstablecerBoolean(bool valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerBoolean();
        }

        public override bool ObtenerBoolean()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return !default(bool).Equals(_valor);
        }

    }
}