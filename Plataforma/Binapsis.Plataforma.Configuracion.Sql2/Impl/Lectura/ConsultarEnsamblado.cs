using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Sql.Impl.Lectura
{
    internal class ConsultarEnsamblado : ComandoLectura
    {
        FabricaConfiguracion _fabrica;

        public ConsultarEnsamblado()
        {
            ComandoSql = "Select Id, Nombre From Ensamblado";
            _fabrica = FabricaConfiguracion.Instancia;
        }

        public ConsultarEnsamblado(string nombre)
            : this()
        {
            ComandoSql += string.Format(" Where Nombre='{0}'", nombre);
        }

        public ConsultarEnsamblado(int id)
            : this()
        {
            ComandoSql += string.Format(" Where Id={0}", id);
        }

        protected override IObjetoDatos Leer()
        {
            Ensamblado ensam = _fabrica.CrearEnsamblado();            
            ensam.Nombre = (string)Obtener(1);
            return ensam;
        }        
    }
}
