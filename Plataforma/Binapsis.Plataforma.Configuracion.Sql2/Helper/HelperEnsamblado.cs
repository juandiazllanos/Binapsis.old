using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Impl.Escritura;
using Binapsis.Plataforma.Configuracion.Sql.Impl.Lectura;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperEnsamblado : HelperBase<Ensamblado>
    {
        public HelperEnsamblado(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Actualizar(Ensamblado obj)
        {
            Ejecutar(new ActualizarEnsamblado(obj));
        }

        public override void Eliminar(Ensamblado obj)
        {
            Ejecutar(new EliminarEnsamblado(obj));
        }

        public override bool Existe(string clave)
        {
            ComandoExiste comando = new ExisteEnsamblado(clave);
            Ejecutar(comando);
            return comando.Resultado;
        }

        public override bool Existe(Ensamblado obj)
        {
            return Existe(obj.Nombre);            
        }

        public override void Insertar(Ensamblado obj)
        {
            Ejecutar(new InsertarEnsamblado(obj));
        }

        public override void Recuperar(Ensamblado obj, string clave)
        {
            Ejecutar(new RecuperarEnsamblado(obj, clave));
        }

        private void Ejecutar(ComandoBase comando)
        {
            comando.CadenaConexion = CadenaConexion;
            comando.Ejecutar();
        }
    }
}
