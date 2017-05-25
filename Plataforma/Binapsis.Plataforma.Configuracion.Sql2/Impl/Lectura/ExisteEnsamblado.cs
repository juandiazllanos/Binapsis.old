using Binapsis.Plataforma.Configuracion.Sql.Comandos;

namespace Binapsis.Plataforma.Configuracion.Sql.Impl.Lectura
{
    internal class ExisteEnsamblado : ComandoExiste
    {
        public ExisteEnsamblado(string clave)
        {
            ComandoSql = string.Format("Select top 1 Nombre From Ensamblado Where Nombre = '{0}'", clave);
        }
    }
}
