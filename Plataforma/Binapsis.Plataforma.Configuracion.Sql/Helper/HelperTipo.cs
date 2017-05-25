using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperTipo : HelperBase<Tipo>
    {
        public HelperTipo(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Actualizar(string clave, Tipo obj)
        {
            using (Transaccion transaccion = new Transaccion(CadenaConexion))
            {
                Escribir(new SqlBuilderActualizarTipo(clave, obj), transaccion);
                new HelperPropiedad(transaccion).Actualizar(obj);

                transaccion.Terminar();
            }                
        }

        public override void Eliminar(Tipo obj)
        {
            using (Transaccion transaccion = new Transaccion(CadenaConexion))
            {
                Escribir(new SqlBuilderEliminarTipo(obj), transaccion);
                new HelperPropiedad(transaccion).Eliminar(obj);

                transaccion.Terminar();
            }                
        }

        public override void Insertar(Tipo obj)
        {
            using (Transaccion transaccion = new Transaccion(CadenaConexion))
            {
                Escribir(new SqlBuilderInsertarTipo(obj), transaccion);
                new HelperPropiedad(transaccion).Insertar(obj);

                transaccion.Terminar();
            }
        }

        public override bool Existe(Tipo obj)
        {
            return Existe($"{obj.Uri.Nombre}.{obj.Nombre}");
        }

        public override bool Existe(string clave)
        {
            return Existe(new SqlBuilderSeleccionarTipo(clave));
        }

        public override Tipo Recuperar(string clave)
        {
            return new HelperRecuperacion(CadenaConexion).RecuperarTipo(clave);
        }
    }
}
