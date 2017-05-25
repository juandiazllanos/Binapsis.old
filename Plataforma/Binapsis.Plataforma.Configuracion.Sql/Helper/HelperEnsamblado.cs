using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperEnsamblado : HelperBase<Ensamblado>
    {
        public HelperEnsamblado(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Actualizar(string clave, Ensamblado obj)
        {
            Escribir(new SqlBuilderActualizarEnsamblado(clave, obj));
        }

        public override void Eliminar(Ensamblado obj)
        {
            Escribir(new SqlBuilderEliminarEnsamblado(obj));
        }

        public override bool Existe(string clave)
        {
            return Existe(new SqlBuilderSeleccionarEnsamblado(clave));
        }

        public override bool Existe(Ensamblado obj)
        {
            return Existe(obj.Nombre);            
        }

        public override void Insertar(Ensamblado obj)
        {
            Escribir(new SqlBuilderInsertarEnsamblado(obj));
        }

        public override Ensamblado Recuperar(string clave)
        {
            return new HelperRecuperacion(CadenaConexion).RecuperarEnsamblado(clave);
        }
        
    }
}
