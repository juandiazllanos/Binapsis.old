using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
	internal class EstadoDecimal : HistorialEstado
    {
		private decimal _valor;

		public EstadoDecimal(IImplementacion impl, IPropiedad propiedad, decimal valor)
            : base(impl, propiedad)
        {
            _valor = valor;
		}
        
		public override void Deshacer(HistorialComando comando)
        {
            comando.Deshacer(_impl, _propiedad, _valor);
        }
        
    }

}