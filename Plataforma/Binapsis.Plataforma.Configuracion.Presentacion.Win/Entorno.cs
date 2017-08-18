using Binapsis.Plataforma.AgenteConfiguracion;
using System.Configuration;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    static class Entorno
    {
        static Entorno()
        {
            Inicializar();
        }

        private static void Inicializar()
        {
            string url = ConfigurationManager.AppSettings.Get("url");
            ServicioConfiguracion servicio = new ServicioConfiguracion(url, ControladorEntidad.Instancia.Fabrica);
            Repositorio repositorio = new Repositorio(servicio);
            Consola consola = new Consola(repositorio);
            BuilderConsola builder = new BuilderConsola(consola);

            builder.Construir();

            Main = new Main(consola);
            Consola = consola;
        }

        public static Consola Consola
        {
            get;
            private set;
        }

        public static Main Main
        {
            get;
            private set;
        }
    }
}
