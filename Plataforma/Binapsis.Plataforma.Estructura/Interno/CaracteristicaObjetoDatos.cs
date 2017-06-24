namespace Binapsis.Plataforma.Estructura.Interno
{
	internal class CaracteristicaObjetoDatos : Caracteristica
    {
        IObjetoDatos _valor;

		public CaracteristicaObjetoDatos(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerObjetoDatos((IObjetoDatos)valor);
        }

        public override void EstablecerObjetoDatos(IObjetoDatos valor)
        {
            _valor = valor;
            _establecido = true;
		}

        public override object Obtener()
        {
            return ObtenerObjetoDatos();
        }

        public override IObjetoDatos ObtenerObjetoDatos()
        {
			return _valor;
		}
    }
}