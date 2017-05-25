using Binapsis.Plataforma.Configuracion.Sql.Comandos;

namespace Binapsis.Plataforma.Configuracion.Sql.Impl.Escritura
{
    internal class ActualizarEnsamblado : ComandoEscritura
    {
        public ActualizarEnsamblado(Ensamblado ensamblado)
            : base()
        {
            //Comando = string.Format("Update Ensamblado Set Nombre = '{0}' Where Id = {1}", ensamblado.Nombre, ensamblado.Id);
        }
    }
}
