using System;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    internal class BuilderPropiedad : BuilderConfiguracion<Propiedad>
    {
        Tipo _propietario;

        public BuilderPropiedad(HelperRecuperacion helper, Tipo propietario) 
            : base(helper)
        {
            _propietario = propietario;
        }

        public override Propiedad Construir(ResultadoLectura lectura)
        {
            Propiedad propiedad = _propietario.CrearPropiedad();
            Construir(propiedad, lectura);
            return propiedad;
        }

        public override void Construir(Propiedad objeto, ResultadoLectura lectura)
        {
            string FK_Tipo = Convert.ToString(lectura["FK_Tipo_Tipo"]);
            objeto.TipoAsociado = Helper.RecuperarTipo(FK_Tipo);

            objeto.Alias = Convert.ToString(lectura["Alias"]);
            objeto.Asociacion = (Asociacion)Convert.ToByte(lectura["Asociacion"]);
            objeto.Cardinalidad = (Cardinalidad)Convert.ToByte(lectura["Cardinalidad"]);
            objeto.Indice = Convert.ToInt32(lectura["Indice"]);
            objeto.Nombre = Convert.ToString(lectura["Nombre"]);
            objeto.ValorInicial = Convert.ToString(lectura["ValorInicial"]);
        }
    }
}
