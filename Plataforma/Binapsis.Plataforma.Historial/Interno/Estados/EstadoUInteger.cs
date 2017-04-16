using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
    internal class EstadoUInteger : HistorialEstado 
    {
        uint _valor;

        public EstadoUInteger(IImplementacion impl, IPropiedad propiedad, uint valor)
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
