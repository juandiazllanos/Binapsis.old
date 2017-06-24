using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaShort : Caracteristica
    {
        short _valor;

		public CaracteristicaShort(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerShort(Convert.ToInt16(valor));
        }

        public override void EstablecerShort(short valor)
        {
            _valor = valor;
            _establecido = true;
        }

        public override object Obtener()
        {
            return ObtenerShort();
        }

        public override short ObtenerShort()
        {
			return _valor;
		}
        
    }
}