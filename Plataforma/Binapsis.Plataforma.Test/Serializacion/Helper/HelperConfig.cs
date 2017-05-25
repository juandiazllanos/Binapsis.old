using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Test.Serializacion.Modelo;
using System;

namespace Binapsis.Plataforma.Test.Serializacion.Helpers
{
    public class HelperConfig
    {
        public static HelperConfig Instancia { get; } = new HelperConfig();

        public void Construir(Config config)
        {
            config.AgregarTipo(Types.Instancia.Obtener(typeof(bool)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(byte)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(char)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(DateTime)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(decimal)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(double)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(float)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(int)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(long)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(short)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(string)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(uint)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(ulong)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(ushort)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(Ensamblado)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(Plataforma.Configuracion.Uri)));
            config.AgregarTipo(Types.Instancia.Obtener(typeof(Tipo)));
        }
    }
}
