using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaString : Caracteristica
    {
        string _valor;

		public CaracteristicaString(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerString(valor?.ToString());
        }

        public override void EstablecerString(string valor)
        {
            _valor = valor;
		}

        public override object Obtener()
        {
            return ObtenerString();
        }

        public override string ObtenerString()
        {
			return _valor;
		}

        public override bool Establecido()
        {
            return (_valor != null);
        }

    }
}