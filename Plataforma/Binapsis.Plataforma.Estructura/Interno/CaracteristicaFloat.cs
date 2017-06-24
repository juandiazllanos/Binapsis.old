using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
    internal class CaracteristicaFloat : Caracteristica
    {
        float _valor;

		public CaracteristicaFloat(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerFloat(Convert.ToSingle(valor));
        }

        public override void EstablecerFloat(float valor)
        {
            _valor = valor;
            _establecido = true;
        }

        public override object Obtener()
        {
            return ObtenerFloat();
        }

        public override float ObtenerFloat()
        {
			return _valor;
		}

    }
}