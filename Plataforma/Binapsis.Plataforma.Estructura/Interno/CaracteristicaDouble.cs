using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaDouble : Caracteristica
    {
        double _valor;

		public CaracteristicaDouble(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerDouble(Convert.ToDouble(valor));
        }

        public override void EstablecerDouble(double valor)
        {
            _valor = valor;
            _establecido = true;
        }

        public override object Obtener()
        {
            return ObtenerDouble();
        }

        public override double ObtenerDouble()
        {
			return _valor;
		}
        
    }
}