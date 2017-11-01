using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.Datos.Impl
{
    class ParametroColumna : ParametroComando
    {
        public ParametroColumna(Parametro parametro) 
            : base(parametro)
        {
        }

        protected override void Establecer(object valor)
        {
            if (MapeoColumna?.Propiedad == null)
                base.Establecer(valor);
            else
                _valor = DataHelper.Instancia.Convert(MapeoColumna.Propiedad, valor);
        }
        
        public MapeoColumna MapeoColumna
        {
            get;
            set;
        }
    }
}
