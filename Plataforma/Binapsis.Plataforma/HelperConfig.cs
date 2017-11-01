using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Configuracion;

namespace Binapsis.Plataforma
{
    public static class HelperConfig
    {
        static string _url;
        static ServicioConfiguracion _servicio;

        public static void Establecer(string url)
        {
            _url = url;
            _servicio = new ServicioConfiguracion(url);
        }

        public static Comando ObtenerComando(string nombre)
        {
            return _servicio.Obtener<Comando>(nombre);
        }

        public static Contexto ObtenerContexto(string nombre)
        {
            return _servicio.Obtener<Contexto>(nombre);
        }

        public static Ensamblado ObtenerEnsamblado(string nombre)
        {
            return _servicio.ObtenerEnsamblado(nombre);
        }

        public static Tipo ObtenerTipo(string uri, string tipo)
        {
            return _servicio.ObtenerTipo(uri, tipo);
        }
        
        public static Uri ObtenerUri(string nombre)
        {
            return _servicio.ObtenerUri(nombre);
        }

    }
}
