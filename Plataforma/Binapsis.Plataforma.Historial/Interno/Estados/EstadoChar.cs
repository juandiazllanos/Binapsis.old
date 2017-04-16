using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
	internal class EstadoChar : HistorialEstado
    {
		private char _valor;

		public EstadoChar(IImplementacion impl, IPropiedad propiedad, char valor)
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