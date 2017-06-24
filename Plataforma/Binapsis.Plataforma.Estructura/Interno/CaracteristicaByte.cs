using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
    internal class CaracteristicaByte : Caracteristica
    {
        byte _valor;

		public CaracteristicaByte(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerByte(Convert.ToByte(valor));
        }

        public override void EstablecerByte(byte valor)
        {
            _valor = valor;
            _establecido = true;
        }

        public override object Obtener()
        {
            return ObtenerByte();
        }

        public override byte ObtenerByte()
        {
			return _valor;
        }
        
    }
}