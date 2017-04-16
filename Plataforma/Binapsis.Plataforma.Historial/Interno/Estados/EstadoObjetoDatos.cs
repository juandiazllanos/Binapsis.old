using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
	internal class EstadoObjetoDatos : HistorialEstado
    {
		protected IObjetoDatos _valor;
        
		public EstadoObjetoDatos(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor)
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