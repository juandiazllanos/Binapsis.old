using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Historial.Interno;

namespace Binapsis.Plataforma.Historial.Interno.Comandos
{
    internal class ComandoRemover : HistorialComando
    {
		public ComandoRemover(HistorialEstado caracteristica)
            : base(caracteristica)
        {

		}

        public override void Deshacer()
        {
            _estado.Deshacer(this);
        }

        public override void Deshacer(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor, int indice)
        {

		}
        

    }

}