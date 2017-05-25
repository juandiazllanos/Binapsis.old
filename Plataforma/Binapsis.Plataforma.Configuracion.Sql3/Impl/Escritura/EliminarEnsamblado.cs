using Binapsis.Plataforma.Configuracion.Sql.Comandos;

namespace Binapsis.Plataforma.Configuracion.Sql.Impl.Escritura
{
    internal class EliminarEnsamblado : ComandoEscritura
    {
        public EliminarEnsamblado(Ensamblado ensamblado)
            : base()
        {
            ComandoSql = string.Format("Delete Ensamblado Where Nombre = '{0}'", ensamblado.Nombre);
        }
    }
}
