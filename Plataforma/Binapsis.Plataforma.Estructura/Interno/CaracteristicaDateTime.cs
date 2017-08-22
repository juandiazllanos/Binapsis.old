using System;

namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaDateTime : Caracteristica
    {
        DateTime _valor;

		public CaracteristicaDateTime(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerDateTime(Convert.ToDateTime(valor));
        }

        public override void EstablecerDateTime(DateTime valor)
        {
            // eliminar milisegundos
            //_valor = valor.Millisecond == 0 ? valor : valor.AddTicks(-(valor.Ticks % TimeSpan.TicksPerSecond));
            _valor = valor;
            _establecido = true;
        }

        public override object Obtener()
        {
            return ObtenerDateTime();
        }

        public override DateTime ObtenerDateTime()
        {
			return _valor;
		}

    }
}