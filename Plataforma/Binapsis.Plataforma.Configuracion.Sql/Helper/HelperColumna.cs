using Binapsis.Plataforma.Configuracion.Sql.Clave;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    internal class HelperColumna : HelperBase<Columna>
    {
        Contexto _contexto;

        public HelperColumna(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public HelperColumna(Contexto contexto)
            : base(contexto.CadenaConexion)
        {
            _contexto = contexto;
        }

        public void Actualizar(Tabla tabla)
        {
            Tabla eliminado = new HelperRecuperacion(_contexto).RecuperarTabla($"{new ClaveTabla(tabla)}");
            Actualizar(tabla, eliminado);
        }

        private void Actualizar(Tabla nuevo, Tabla eliminado)
        {
            var eliminados = from Columna in eliminado.Columnas.Cast<Columna>().Select(item => item.Nombre)
                             where !nuevo.ContieneColumna(Columna)
                             select Columna;

            var nuevos = from Columna in nuevo.Columnas.Cast<Columna>().Select(item => item.Nombre)
                         where !eliminado.ContieneColumna(Columna)
                         select Columna;

            var actualizados = from Columna in nuevo.Columnas.Cast<Columna>().Select(item => item.Nombre)
                               where eliminado.ContieneColumna(Columna)
                               select Columna;

            // eliminar
            foreach (string Columna in eliminados)
                Eliminar(eliminado.ObtenerColumna(Columna));

            // insertar 
            foreach (string Columna in nuevos)
                Insertar(nuevo.ObtenerColumna(Columna));

            // actualizar
            foreach (string Columna in actualizados)
                Actualizar(nuevo.ObtenerColumna(Columna));
            
        }

        public void Eliminar(Tabla tabla)
        {
            foreach (Columna Columna in tabla.Columnas)
                Eliminar(Columna);
        }

        public void Insertar(Tabla tabla)
        {
            foreach (Columna Columna in tabla.Columnas)
                Insertar(Columna);
        }

        public virtual void Actualizar(Columna obj)
        {
            Actualizar(new ClaveColumna(obj).ToString(), obj);
        }

        public override void Actualizar(string clave, Columna obj)
        {
            Escribir(new SqlBuilderActualizar(clave, obj), _contexto);
        }

        public override void Eliminar(Columna obj)
        {
            Escribir(new SqlBuilderEliminar(obj), _contexto);
        }

        public override bool Existe(Columna obj)
        {
            return Existe($"{new ClaveColumna(obj)}");
        }

        public override bool Existe(string clave)
        {
            return Existe(new SqlBuilderSeleccionar(typeof(Columna), clave));
        }

        public override void Insertar(Columna obj)
        {
            Escribir(new SqlBuilderInsertarColumna(obj), _contexto);
        }

        public override Columna Recuperar(string clave)
        {
            return new HelperRecuperacion(CadenaConexion).Recuperar<Columna>(clave);
        }
    }
}
