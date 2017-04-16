using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno.Estados
{
    class EstadoObjetoDatosItem : EstadoObjetoDatos
    {
        int _indice;

        public EstadoObjetoDatosItem(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor, int indice)
            : base(impl, propiedad, valor)
        {
            _indice = indice;
        }

        public override void Deshacer(HistorialComando comando)
        {
            comando.Deshacer(_impl, _propiedad, _valor, _indice);
        }
    }
}
