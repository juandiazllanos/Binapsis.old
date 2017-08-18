using System;
using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Configuracion;
using System.Linq;
using System.Collections;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class Configuracion : IConfiguracion
    {
        static ServicioConfiguracion _servicio;

        public Configuracion(string url)
        {
            _servicio = new ServicioConfiguracion(url);
        }
        
        public Tabla ObtenerTabla(string uri, string tipo)
        {
            return _servicio.ObtenerTablas(uri, tipo)?.OfType<Tabla>().FirstOrDefault();
        }
        
        public Tabla ObtenerTabla(string nombreTabla)
        {
            throw new NotImplementedException();
        }

        public Relacion ObtenerRelacion(string uri, string tipo, string propiedad)
        {
            return _servicio.Obtener<Relacion>($"{uri}.{tipo}.{propiedad}");
        }

        public Tipo ObtenerTipo(string uri, string tipo)
        {
            return _servicio.Obtener<Tipo>($"{uri}.{tipo}");
        }

        public IList ObtenerTablas()
        {
            return _servicio.ObtenerColeccion<Tabla>();
        }

        public IList ObtenerRelaciones()
        {
            return _servicio.ObtenerColeccion<Relacion>();
        }

        public IList ObtenerRelacionesPorTipo(string uri, string tipo)
        {
            return _servicio.ObtenerRelacionesPorTipo(uri, tipo);
        }

        public IList ObtenerRelacionesPorTabla(string tablaPrincipal, string tablaSecundaria)
        {
            return _servicio.ObtenerRelacionesPorTabla(tablaPrincipal, tablaSecundaria);
        }

        public Comando ObtenerComando(string nombre)
        {
            return null;
        }
    }
}
