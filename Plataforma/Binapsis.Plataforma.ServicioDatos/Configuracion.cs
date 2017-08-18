using System;
using System.Collections;
using System.Linq;

using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.AgenteConfiguracion;
using System.Collections.Generic;

namespace Binapsis.Plataforma.ServicioDatos
{
    class Configuracion : IConfiguracion
    {
        public Configuracion(string url)
        {
            Servicio = new ServicioConfiguracion(url);
        }

        public Comando ObtenerComando(string nombre)
        {
            return Servicio.Obtener<Comando>(nombre);
        }

        public Relacion ObtenerRelacion(string uri, string tipo, string propiedad)
        {            
            return Servicio.ObtenerRelacionesPorPropiedad(uri, tipo, propiedad)?.OfType<Relacion>().FirstOrDefault();
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
            return null;
        }

        public Tabla ObtenerTabla(string nombreTabla)
        {
            return Servicio.ObtenerTabla(nombreTabla);
        }

        public IList ObtenerTablas()
        {
            return Servicio.ObtenerTablas();
        }

        public Tipo ObtenerTipo(string uri, string tipo)
        {
            return Servicio.ObtenerTipo(uri, tipo);
        }

        public ServicioConfiguracion Servicio
        {
            get;
        }
    }
}
