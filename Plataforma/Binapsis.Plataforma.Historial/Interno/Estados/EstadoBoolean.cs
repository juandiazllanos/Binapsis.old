using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
	internal class EstadoBoolean : HistorialEstado
    {
		private bool _valor;
        
		public EstadoBoolean(IImplementacion impl, IPropiedad propiedad, bool valor)
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