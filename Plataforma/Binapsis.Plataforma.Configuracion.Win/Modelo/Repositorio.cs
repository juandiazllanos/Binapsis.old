using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    internal class Repositorio : IRepositorio
    {
        public Repositorio(string url)
        {
            Url = url;
        }
                
        public void Establecer(ConfiguracionBase valor)
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion(Url);
            servicio.Establecer(valor);
        }

        public void Establecer(ConfiguracionBase valor, string clave)
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion(Url);
            servicio.Establecer(valor, clave);
        }


        public ConfiguracionBase Obtener(Type type, string clave)
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion(Url);
            return servicio.Obtener(type, clave);
        }

        public ConfiguracionBase Obtener(Type type, string clave, IFabricaImpl impl)
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion(Url, impl);
            return servicio.Obtener(type, clave);            
        }

        public T Obtener<T>(string clave, IFabricaImpl impl) where T : ConfiguracionBase
        {
            return (T)Obtener(typeof(T), clave, impl);
        }

        public T Obtener<T>(string clave) where T : ConfiguracionBase
        {
            return (T)Obtener(typeof(T), clave);
        }

        public void Eliminar(Type type, string clave)
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion(Url);
            servicio.Eliminar(type, clave);
        }
        
        public string Url
        {
            get;
            set;
        }
    }
}
