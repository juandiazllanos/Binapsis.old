using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
	internal class EstadoDateTime : HistorialEstado
    {
		private DateTime _valor;

		public EstadoDateTime(IImplementacion impl, IPropiedad propiedad, DateTime valor)
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