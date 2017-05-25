using System.Configuration;

namespace Binapsis.Plataforma.Configuracion.Win
{
    static class Config
    {
        public static string Url => ConfigurationManager.AppSettings["url"];
    }
}
