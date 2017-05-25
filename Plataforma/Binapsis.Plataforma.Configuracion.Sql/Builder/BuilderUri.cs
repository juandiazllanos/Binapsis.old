using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    internal class BuilderUri : BuilderConfiguracion<Uri>
    {
        public BuilderUri(HelperRecuperacion helper) 
            : base(helper)
        {
        }

        public override void Construir(Uri objeto, ResultadoLectura lectura)
        {
            objeto.Ensamblado = Helper.RecuperarEnsamblado((string)lectura["FK_Ensamblado"]);
            objeto.Nombre = (string)lectura["Nombre"];
        }
    }
}
