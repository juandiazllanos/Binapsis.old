using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    class BuilderTabla : BuilderConfiguracion<Tabla>
    {
        public BuilderTabla(HelperRecuperacion helper) 
            : base(helper)
        {
        }

        public override void Construir(Tabla objeto, ResultadoLectura lectura)
        {
            base.Construir(objeto, lectura);
            ConstruirItems(objeto);
        }

        private void ConstruirItems(Tabla obj)
        {
            Helper.RecuperarItems(new SqlBuilderSeleccionarColumnaTabla(obj), new BuilderColumna(Helper, obj));
        }
    }
}
