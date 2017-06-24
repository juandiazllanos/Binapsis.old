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
            _establecido = true;
        }

        public override object Obtener()
        {
            return ObtenerULong();
        }

        public override ulong ObtenerULong()
        {
			return _valor;
		}
        
    }
}