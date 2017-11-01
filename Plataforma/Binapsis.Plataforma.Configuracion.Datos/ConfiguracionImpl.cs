using Binapsis.Plataforma.Datos;
using System.Collections;
using System.Linq;
using System;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    class ConfiguracionImpl : IConfiguracion
    {
        internal ConfiguracionImpl(ConfiguracionRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public Comando ObtenerComando(string nombre)
        {
            return Repositorio.Comandos.FirstOrDefault(item => item.Nombre == nombre);
        }

        public Relacion ObtenerRelacion(string uri, string tipo, string propiedad)
        {
            return Repositorio.Relaciones.FirstOrDefault(item => item.TipoAsociado == $"{uri}.{tipo}" && item.Propiedad == propiedad);
        }

        public IList ObtenerRelaciones()
        {
            return Repositorio.Relaciones.ToList();
        }

        public IList ObtenerRelacionesPorTabla(string tablaPrincipal, string tablaSecundaria)
        {
            return Repositorio.Relaciones.Where(item => item.TablaPrincipal == tablaPrincipal && item.TablaSecundaria == tablaSecundaria).ToList();
        }

        public IList ObtenerRelacionesPorTipo(string uri, string tipo)
        {
            return Repositorio.Relaciones.Where(item => item.TipoAsociado == $"{uri}.{tipo}").ToList();
        }

        public Tabla ObtenerTabla(string uri, string tipo)
        {
            return Repositorio.Tablas.FirstOrDefault(item => item.TipoAsociado == $"{uri}.{tipo}");
        }

        public Tabla ObtenerTabla(string nombreTabla)
        {
            return Repositorio.Tablas.FirstOrDefault(item => item.Nombre == nombreTabla);
        }

        public IList ObtenerTablas()
        {
            return Repositorio.Tablas.ToList();
        }

        public Tipo ObtenerTipo(string uri, string tipo)
        {
            return Repositorio.Tipos.FirstOrDefault(item => item.Uri.Nombre == uri && item.Nombre == tipo);
        }

        public IPrimaryKey ObtenerPrimaryKey(string tabla, string columna)
        {
            return new PrimaryKey(tabla, columna);
        }

        #region Propiedades
        private ConfiguracionRepositorio Repositorio
        {
            get;
        }
        #endregion

    }
}
