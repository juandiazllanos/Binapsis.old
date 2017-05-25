using Binapsis.Plataforma.Configuracion.Sql.Comandos;

namespace Binapsis.Plataforma.Configuracion.Sql.Impl.Escritura
{
    internal class InsertarEnsamblado : ComandoEscritura
    {
        public InsertarEnsamblado(Ensamblado ensamblado) 
            : base()
        {            
            ComandoSql = string.Format("Insert into Ensamblado (PK_Ensamblado, Nombre) values ('{0}', '{0}')", ensamblado.Nombre);
        }
        
    }
}
