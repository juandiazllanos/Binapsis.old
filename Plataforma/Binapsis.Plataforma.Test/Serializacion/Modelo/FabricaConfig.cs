using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion;
using EspacioNombres = Binapsis.Plataforma.Configuracion.Uri;

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
            Ensamblado ensam = Fabrica.Instancia.Crear<Ensamblado>();
            ensam.Nombre = "Binapsis.Plataforma.Test";

            EspacioNombres uri = Fabrica.Instancia.Crear<EspacioNombres>();
            uri.Ensamblado = ensam;
            uri.Nombre = "Binapsis.Plataforma.Test.Serializacion.Modelo";
            Tipo tipo = Fabrica.Instancia.Crear<Tipo>();
            tipo.Uri = uri;
            tipo.Nombre = "Config";
            tipo.Alias = "config";

            Propiedad propiedad = tipo.CrearPropiedad("Tipos", Types.Instancia.Obtener(typeof(Tipo)));
            propiedad.Asociacion = Asociacion.Agregacion;
            propiedad.Cardinalidad = Cardinalidad.CeroAMuchos;

            return Crear(tipo);
        }
        
        public override Config Crear(IImplementacion impl)
        {
            return new Config(impl);
        }

        public static FabricaConfig Instancia { get; } = new FabricaConfig();
    }
}
