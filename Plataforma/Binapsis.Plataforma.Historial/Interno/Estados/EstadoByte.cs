using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
	internal class EstadoByte : HistorialEstado
    {
		private byte _valor;

		public EstadoByte(IImplementacion impl, IPropiedad propiedad, byte valor)
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