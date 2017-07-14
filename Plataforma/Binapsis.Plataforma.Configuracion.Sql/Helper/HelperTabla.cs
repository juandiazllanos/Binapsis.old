using Binapsis.Plataforma.Configuracion.Sql.Builder;
using Binapsis.Plataforma.Configuracion.Sql.Clave;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperTabla : HelperBase<Tabla>
    {
        public HelperTabla(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Actualizar(string clave, Tabla obj)
        {
            using (Contexto contexto = new Contexto(CadenaConexion))
            {
                Escribir(new SqlBuilderActualizar(clave, obj));
                new HelperColumna(contexto).Actualizar(obj);
            }                
        }

        public override void Eliminar(Tabla obj)
        {
            using (Contexto contexto = new Contexto(CadenaConexion))
            {
                Escribir(new SqlBuilderEliminar(obj));
                new HelperColumna(contexto).Eliminar(obj);
            }
        }

        public override bool Existe(Tabla obj)
        {
            return Existe($"{new ClaveTabla(obj)}");
        }

        public override bool Existe(string clave)
        {
            return Existe(new SqlBuilderSeleccionar(typeof(Tabla), clave));
        }

        public override void Insertar(Tabla obj)
        {
            using (Contexto contexto = new Contexto(CadenaConexion))
            {
                Escribir(new SqlBuilderInsertar(obj));
                new HelperColumna(contexto).Insertar(obj);
            }
        }

        public IList<Tabla> RecuperarTodo()
        {
            return new HelperRecuperacion(CadenaConexion).RecuperarTablas();
        }

        public override Tabla Recuperar(string clave)
        {
            return new HelperRecuperacion(CadenaConexion).RecuperarTabla(clave);
        }

        public IList<Tabla> Recuperar(string uri, string tipo)
        {
            return new HelperRecuperacion(CadenaConexion).RecuperarTabla(uri, tipo);
        }
    }
}
