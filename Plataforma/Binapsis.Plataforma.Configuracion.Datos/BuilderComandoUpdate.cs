using Binapsis.Plataforma.Datos.Impl;
using System.Text;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    class BuilderComandoUpdate
    {
        public BuilderComandoUpdate(Comando comando)
        {
            Comando = comando;
        }

        public void Construir(ComandoTabla comandoTabla)
        {
            Columna columna = comandoTabla.Tabla.Columnas.Cast<Columna>().FirstOrDefault(item => item.ClavePrimaria);
            ConstruirSql(comandoTabla.Sql, columna.Nombre);
            ConstruirParametros(comandoTabla);

            // agregar parametro clave
            Comando.CrearParametro("clave", typeof(string));
        }

        private void ConstruirSql(string sql, string columna)
        {
            StringBuilder builder = new StringBuilder(sql.Substring(0, sql.IndexOf("WHERE")));
            builder.Append($", {columna}=@{columna} WHERE {columna}=@clave");
            Comando.Sql = builder.ToString();
        }

        private void ConstruirParametros(ComandoTabla comandoTabla)
        {
            foreach (ParametroComando parametro in comandoTabla.Parametros)
                ConstruirParametro(parametro);
        }

        private void ConstruirParametro(ParametroComando parametroComando)
        {
            Parametro parametro = Comando.CrearParametro();
            parametro.Nombre = parametroComando.Nombre;
            parametro.Direccion = parametroComando.Direccion;
            parametro.Indice = parametroComando.Indice;
            parametro.Longitud = parametroComando.Longitud;
            parametro.TipoDato = parametroComando.Type?.FullName;
        }

        public Comando Comando
        {
            get;
        }
    }
}
