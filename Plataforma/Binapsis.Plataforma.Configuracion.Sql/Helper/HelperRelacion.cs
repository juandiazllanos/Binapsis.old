using Binapsis.Plataforma.Configuracion.Sql.Builder;
using Binapsis.Plataforma.Configuracion.Sql.Clave;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperRelacion : HelperBase<Relacion>
    {
        public HelperRelacion(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Actualizar(string clave, Relacion obj)
        {
            Escribir(new SqlBuilderActualizar(clave, obj));
        }

        public override void Eliminar(Relacion obj)
        {
            Escribir(new SqlBuilderEliminar(obj));
        }

        public override bool Existe(Relacion obj)
        {
            return Existe($"{new ClaveRelacion(obj)}");
        }

        public override bool Existe(string clave)
        {
            return Existe(new SqlBuilderSeleccionar(typeof(Relacion), clave));
        }

        public override void Insertar(Relacion obj)
        {
            Escribir(new SqlBuilderInsertar(obj));
        }

        public override Relacion Recuperar(string clave)
        {
            HelperRecuperacion helper = new HelperRecuperacion(CadenaConexion);
            return helper.Recuperar(new SqlBuilderSeleccionar(typeof(Relacion), clave), new BuilderConfiguracion<Relacion>(helper), clave);
        }
    }
}
