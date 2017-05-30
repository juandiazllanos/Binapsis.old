using Binapsis.Plataforma.Configuracion.Sql.Builder;
using Binapsis.Plataforma.Configuracion.Sql.Clave;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperConexion : HelperBase<Conexion>
    {
        public HelperConexion(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Actualizar(string clave, Conexion obj)
        {
            Escribir(new SqlBuilderActualizar(clave, obj));
        }

        public override void Eliminar(Conexion obj)
        {
            Escribir(new SqlBuilderEliminar(obj));
        }

        public override bool Existe(Conexion obj)
        {
            return Existe($"{new ClaveConexion(obj)}");
        }

        public override bool Existe(string clave)
        {
            return Existe(new SqlBuilderSeleccionar(typeof(Conexion), clave));
        }

        public override void Insertar(Conexion obj)
        {
            Escribir(new SqlBuilderInsertar(obj));
        }

        public override Conexion Recuperar(string clave)
        {
            HelperRecuperacion helper = new HelperRecuperacion(CadenaConexion);
            return helper.Recuperar(new SqlBuilderSeleccionar(typeof(Conexion), clave), new BuilderConfiguracion<Conexion>(helper), clave);
        }
    }
}
