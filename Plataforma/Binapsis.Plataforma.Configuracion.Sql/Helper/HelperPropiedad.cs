using Binapsis.Plataforma.Configuracion.Sql.Clave;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;
using System;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    internal class HelperPropiedad : HelperBase<Propiedad>
    {
        Contexto _contexto;

        public HelperPropiedad(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public HelperPropiedad(Contexto contexto)
            : base(contexto.CadenaConexion)
        {
            _contexto = contexto;
        }

        public void Actualizar(Tipo tipo)
        {
            Tipo eliminado = new HelperRecuperacion(_contexto).RecuperarTipo(new ClaveTipo(tipo).ToString());
            Actualizar(tipo, eliminado);
        }

        private void Actualizar(Tipo nuevo, Tipo eliminado)
        {
            var eliminados = from propiedad in eliminado.Propiedades.Select(item => item.Nombre)
                             where !nuevo.ContienePropiedad(propiedad)
                             select propiedad;

            var nuevos = from propiedad in nuevo.Propiedades.Select(item => item.Nombre)
                         where !eliminado.ContienePropiedad(propiedad)
                         select propiedad;

            var actualizados = from propiedad in nuevo.Propiedades.Select(item => item.Nombre)
                               where !eliminado.ContienePropiedad(propiedad)
                               select propiedad;

            // eliminar
            foreach (string propiedad in eliminados)
                Eliminar(eliminado.ObtenerPropiedad(propiedad));

            // insertar 
            foreach (string propiedad in nuevos)
                Insertar(nuevo.ObtenerPropiedad(propiedad));

            // actualizar
            foreach (string propiedad in actualizados)
                Actualizar(propiedad, nuevo.ObtenerPropiedad(propiedad));
            
        }

        public void Eliminar(Tipo tipo)
        {
            foreach (Propiedad propiedad in tipo.Propiedades)
                Eliminar(propiedad);
        }

        public void Insertar(Tipo tipo)
        {
            foreach (Propiedad propiedad in tipo.Propiedades)
                Insertar(propiedad);
        }

        public override void Actualizar(string clave, Propiedad obj)
        {
            Escribir(new SqlBuilderActualizarPropiedad(obj), _contexto);
        }

        public override void Eliminar(Propiedad obj)
        {
            Escribir(new SqlBuilderEliminarPropiedad(obj), _contexto);
        }

        public override bool Existe(Propiedad obj)
        {
            return Existe($"{obj.Propietario.Uri.Nombre}.{obj.Propietario.Nombre}.{obj.Nombre}");
        }

        public override bool Existe(string clave)
        {
            return Existe(new SqlBuilderSeleccionarPropiedad(clave));
        }

        public override void Insertar(Propiedad obj)
        {
            Escribir(new SqlBuilderInsertarPropiedad(obj), _contexto);
        }

        public override Propiedad Recuperar(string clave)
        {
            throw new NotImplementedException();
        }
    }
}
