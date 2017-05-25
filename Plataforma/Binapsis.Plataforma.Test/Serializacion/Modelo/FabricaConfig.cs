using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion;
using System;

namespace Binapsis.Plataforma.Test.Serializacion.Modelo
{
    class FabricaConfig : FabricaBase<Config>
    {
        public FabricaConfig()
        {
        }

        public FabricaConfig(IFabricaImpl fabrica) 
            : base(fabrica)
        {
        }

        public Config Crear()
        {
            Ensamblado ensam = FabricaConfiguracion.Instancia.CrearEnsamblado("Binapsis.Plataforma.Test");
            Plataforma.Configuracion.Uri uri = FabricaConfiguracion.Instancia.CrearUri(ensam, "Binapsis.Plataforma.Test.Serializacion.Modelo");
            Plataforma.Configuracion.Tipo tipo = FabricaConfiguracion.Instancia.CrearTipo(uri, "Config", "config");
            Plataforma.Configuracion.Propiedad propiedad = tipo.CrearPropiedad("Tipos", Types.Instancia.Obtener(typeof(Plataforma.Configuracion.Tipo)));
            propiedad.Asociacion = Asociacion.Agregacion;
            propiedad.Cardinalidad = Cardinalidad.Cero_Muchos;

            return Crear(tipo);
        }
        
        public override Config Crear(IImplementacion impl)
        {
            return new Config(impl);
        }

        public static FabricaConfig Instancia { get; } = new FabricaConfig();
    }
}
