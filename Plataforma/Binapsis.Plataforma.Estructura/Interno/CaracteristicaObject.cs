namespace Binapsis.Plataforma.Estructura.Interno
{
    internal class CaracteristicaObject : Caracteristica
    {
        object _valor;

		public CaracteristicaObject(IPropiedad propiedad)
            : base(propiedad)
        {

		}

        public override void Establecer(object valor)
        {
            EstablecerObject(valor);
        }

        public override void EstablecerObject(object valor)
        {
            _valor = valor;
            _establecido = true;
        }

        public override object Obtener()
        {
            return ObtenerObject();
        }

        public override object ObtenerObject()
        {
			return _valor;
		}
        
    }
}