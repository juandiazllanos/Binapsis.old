using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
	internal class EstadoUShort : HistorialEstado
    {
		private ushort _valor;

		public EstadoUShort(IImplementacion impl, IPropiedad propiedad, ushort valor)
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