using System;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;
using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    internal class BuilderTipo : BuilderConfiguracion<Tipo>
    {
        public BuilderTipo(HelperRecuperacion helper) 
            : base(helper)
        {
        }

        public override void Construir(Tipo objeto, ResultadoLectura lectura)
        {
            string FK_Uri = Convert.ToString(lectura["FK_Uri"]);
            string FK_Base = Convert.ToString(lectura["FK_Tipo_Base"]);

            if (!string.IsNullOrEmpty(FK_Base))
                objeto.Base = Helper.RecuperarTipo(FK_Base);

            objeto.Uri = Helper.RecuperarUri(FK_Uri);
            objeto.Alias = (string)lectura["Alias"];
            objeto.EsTipoDeDato = Convert.ToBoolean(lectura["EsTipoDeDato"]);
            objeto.Nombre = Convert.ToString(lectura["Nombre"]);

            ConstuirItems(objeto);
            
        }        

        private void ConstuirItems(Tipo obj)
        {
            Helper.RecuperarItems(new SqlBuilderSeleccionarPropiedadTipo(new ClaveTipo(obj).ToString()), new BuilderPropiedad(Helper, obj));
        }
    }
}
