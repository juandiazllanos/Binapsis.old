using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderSeleccionarEnsamblado : SqlBuilderSeleccion
    {
        public SqlBuilderSeleccionarEnsamblado(string clave) 
            : base(clave)
        {
        }
        
        protected override string ConstruirSelect()
        {
            return "Select PK_Ensamblado, Nombre From Ensamblado";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            return $"Select Top 1 PK_Ensamblado, Nombre From Ensamblado Where PK_Ensamblado = '{clave}'";
        }
    }
}
