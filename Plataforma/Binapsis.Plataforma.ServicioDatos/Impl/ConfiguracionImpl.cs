using System.Collections;
using System.Linq;

using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.AgenteConfiguracion;

using Type = System.Type;
using System;

namespace Binapsis.Plataforma.ServicioDatos.Impl
{
    class ConfiguracionImpl : IConfiguracion
    {
        #region Constructores
        public ConfiguracionImpl(string url)
        {
            Servicio = new ServicioConfiguracion(url);
        }
        #endregion


        #region Metodos
        public Conexion ObtenerConexion(string nombre)
        {
            return Servicio.Obtener<Conexion>(nombre);
        }

        public Comando ObtenerComando(string nombre)
        {
            return Servicio.Obtener<Comando>(nombre);
        }

        public Relacion ObtenerRelacion(string uri, string tipo, string propiedad)
        {            
            return Servicio.ObtenerRelacionesPorPropiedad(uri, tipo, propiedad)?.Cast<Relacion>().FirstOrDefault();
        }

        public IList ObtenerRelaciones()
        {
            return Servicio.ObtenerRelaciones();
        }

        public IList ObtenerRelacionesPorTabla(string tablaPrincipal, string tablaSecundaria)
        {
            return Servicio.ObtenerRelacionesPorTabla(tablaPrincipal, tablaSecundaria);
        }

        public IList ObtenerRelacionesPorTipo(string uri, string tipo)
        {
            return Servicio.ObtenerRelacionesPorTipo(uri, tipo);
        }

        public Tabla ObtenerTabla(string uri, string tipo)
        {
            return Servicio.ObtenerTablas(uri, tipo)?.Cast<Tabla>().FirstOrDefault();
        }

        public Tabla ObtenerTabla(string nombreTabla)
        {
            return Servicio.ObtenerTabla(nombreTabla);
        }

        public IList ObtenerTablas()
        {
            return Servicio.ObtenerTablas();
        }

        public Tipo ObtenerTipo(Type type)
        {
            return ObtenerTipo(type.Namespace, type.Name);
        }

        public Tipo ObtenerTipo(string uri, string tipo)
        {
            return Servicio.ObtenerTipo(uri, tipo);
        }

        public IPrimaryKey ObtenerPrimaryKey(string tabla, string columna)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Propiedades
        public ServicioConfiguracion Servicio
        {
            get;
        }
        #endregion

    }
}
