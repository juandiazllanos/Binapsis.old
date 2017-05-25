using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Configuracion.Sql.Comandos
{
    internal abstract class ComandoBase : IComando
    {
        public ComandoBase()
        {
            //CadenaConexion = ConfigurationManager.AppSettings["cadenaConexion"];
        }

        public abstract void Ejecutar();

        public string CadenaConexion
        {
            get;
            set;
        }

        protected string ComandoSql
        {
            get;
            set;
        }
    }
}
