using Binapsis.Plataforma.Datos;
using System;
using Binapsis.Plataforma.Configuracion;
using System.Collections;
using System.Linq;

namespace Binapsis.Plataforma.Test.Datos.Impl
{
    public class Configuracion : IConfiguracion
    {
        ConfiguracionRepositorio _repositorio;

        public Configuracion()
        {
            _repositorio = ConfiguracionRepositorio.Instancia;
        }

        public Comando ObtenerComando(string nombre)
        {
            return _repositorio.Comandos.FirstOrDefault(item => item.Nombre == nombre);
        }

        public Relacion ObtenerRelacion(string uri, string tipo, string propiedad)
        {
            return _repositorio.Relaciones.FirstOrDefault(item => item.TipoAsociado == $"{uri}.{tipo}" && item.Propiedad == propiedad);
        }

        public IList ObtenerRelaciones()
        {
            return _repositorio.Relaciones.ToList();
        }

        public IList ObtenerRelacionesPorTabla(string tablaPrincipal, string tablaSecundaria)
        {
            return _repositorio.Relaciones.Where(item => item.TablaPrincipal == tablaPrincipal && item.TablaSecundaria == tablaSecundaria).ToList();
        }

        public IList ObtenerRelacionesPorTipo(string uri, string tipo)
        {
            return _repositorio.Relaciones.Where(item => item.TipoAsociado == $"{uri}.{tipo}").ToList();
        }

        public Tabla ObtenerTabla(string uri, string tipo)
        {
            return _repositorio.Tablas.FirstOrDefault(item => item.TipoAsociado == $"{uri}.{tipo}");
        }

        public Tabla ObtenerTabla(string nombreTabla)
        {
            return _repositorio.Tablas.FirstOrDefault(item => item.Nombre == nombreTabla);
        }

        public IList ObtenerTablas()
        {
            return _repositorio.Tablas.ToList();
        }

        public Tipo ObtenerTipo(string uri, string tipo)
        {
            return _repositorio.Tipos.FirstOrDefault(item => item.Uri.Nombre == uri && item.Nombre == tipo);
        }
    }
}
