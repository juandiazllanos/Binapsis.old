using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class ResultadoPropiedad : IPropiedad
    {
        ResultadoDescriptor _resultadoDescriptor;
        ITipo _tipo;

        public ResultadoPropiedad(ResultadoDescriptor resultadoDescriptor)
        {
            _resultadoDescriptor = resultadoDescriptor;
            EstablecerTipo(resultadoDescriptor.TipoDato);
        }

        private void EstablecerTipo(string type)
        {
            string uri = type.Substring(0, type.LastIndexOf('.'));
            string tipo = type.Substring(type.LastIndexOf('.') + 1);
            _tipo = Types.Instancia.Obtener(uri, tipo);
        }

        public string Alias
        {
            get => string.Empty;
        }

        public Asociacion Asociacion
        {
            get => Asociacion.Ninguna;
        }

        public Cardinalidad Cardinalidad
        {
            get => Cardinalidad.Ninguna;
        }

        public bool EsColeccion
        {
            get => false;
        }

        public int Indice
        {
            get;
            set;
        }

        public string Nombre
        {
            get => _resultadoDescriptor.Nombre;
        }

        public ITipo Tipo
        {
            get => _tipo;
        }

        public object ValorInicial
        {
            get => null;
        }
    }
}
