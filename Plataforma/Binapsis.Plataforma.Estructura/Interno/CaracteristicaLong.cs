using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaLong : Caracteristica
    {
        long _valor;

		public CaracteristicaLong(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerLong(Convert.ToInt64(valor));
        }

        public override void EstablecerLong(long valor)
        {
            _valor = valor;
            _establecido = true;
        }

        public override object Obtener()
        {
            return ObtenerLong();
        }

        public override long ObtenerLong()
        {
			return _valor;
		}
        
    }
}