using System;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    internal class BuilderDefinicion : BuilderConfiguracion<Definicion>
    {
        Definicion _definicion;

        public BuilderDefinicion(HelperRecuperacion helper) 
            : base(helper)
        {
        }

        public BuilderDefinicion(HelperRecuperacion helper, Definicion definicion) 
            : base(helper)
        {
            _definicion = definicion;
        }

        public override Definicion Construir(ResultadoLectura lectura)
        {
            if (_definicion == null)
                return base.Construir(lectura);
                
            Definicion item = _definicion.CrearDefinicion();
            Construir(item, lectura);
            return item;
        }

        public override void Construir(Definicion objeto, ResultadoLectura lectura)
        {
            objeto.Alias = Convert.ToString(lectura["Alias"]);
            objeto.Nombre = Convert.ToString(lectura["Nombre"]);
            objeto.Valor = Convert.ToString(lectura["Valor"]);

            ConstruirItems(objeto);
        }

        private void ConstruirItems(Definicion definicion)
        {
            Helper.RecuperarItems(new SqlBuilderSeleccionarDefinicionItem(definicion.Nombre, definicion.Valor), new BuilderDefinicion(Helper, definicion));
            //foreach (Definicion definicionItem in definicion.Definiciones)
            //    ConstruirItems(definicionItem);
        }
    }
}
