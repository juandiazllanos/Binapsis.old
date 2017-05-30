using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public interface IRepositorio
    {
        void Establecer(ConfiguracionBase valor);
        void Establecer(ConfiguracionBase valor, string clave);
        void Eliminar(Type type, string clave);
        ConfiguracionBase Obtener(Type type, string clave);
        ConfiguracionBase Obtener(Type type, string clave, IFabricaImpl impl);

        string Url { get; set; }

        
    }
}