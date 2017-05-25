using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    internal class BuilderEnsamblado : BuilderConfiguracion<Ensamblado>
    {
        public BuilderEnsamblado(HelperRecuperacion helper) 
            : base(helper)
        {
        }

        public override void Construir(Ensamblado objeto, ResultadoLectura lectura)
        {
            objeto.Nombre = (string)lectura["Nombre"];
        }
    }
}
