using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test.Builders
{
    internal static class BuilderTipo
    {
        public static ITipo Construir(Tipo tipo)
        {
            Ensamblado ensam = FabricaConfiguracion.Instancia.CrearEnsamblado("Binapsis.Plataforma.Estructura");
            Uri uri = FabricaConfiguracion.Instancia.CrearUri(ensam, "Binapsis.Plataforma.Estructura.Impl");

            tipo.Nombre = "ObjetoDatos";
            tipo.Alias = "ObjetoDatos";
            tipo.Uri = uri;

            tipo.CrearPropiedad("atributoId", Types.Instancia.Obtener(typeof(int)));            
            tipo.CrearPropiedad("atributoBoolean", Types.Instancia.Obtener(typeof(bool)));
            tipo.CrearPropiedad("atributoByte", Types.Instancia.Obtener(typeof(byte)));
            tipo.CrearPropiedad("atributoChar", Types.Instancia.Obtener(typeof(char)));
            tipo.CrearPropiedad("atributoDateTime", Types.Instancia.Obtener(typeof(System.DateTime)));
            tipo.CrearPropiedad("atributoDecimal", Types.Instancia.Obtener(typeof(decimal)));
            tipo.CrearPropiedad("atributoDouble", Types.Instancia.Obtener(typeof(double)));
            tipo.CrearPropiedad("atributoFloat", Types.Instancia.Obtener(typeof(float)));
            tipo.CrearPropiedad("atributoInteger", Types.Instancia.Obtener(typeof(int)));
            tipo.CrearPropiedad("atributoLong", Types.Instancia.Obtener(typeof(long)));
            tipo.CrearPropiedad("atributoSByte", Types.Instancia.Obtener(typeof(sbyte)));
            tipo.CrearPropiedad("atributoShort", Types.Instancia.Obtener(typeof(short)));
            tipo.CrearPropiedad("atributoString", Types.Instancia.Obtener(typeof(string)));
            tipo.CrearPropiedad("atributoUInteger", Types.Instancia.Obtener(typeof(uint)));
            tipo.CrearPropiedad("atributoULong", Types.Instancia.Obtener(typeof(ulong)));
            tipo.CrearPropiedad("atributoUShort", Types.Instancia.Obtener(typeof(ushort)));

            Propiedad propiedad = tipo.CrearPropiedad("ReferenciaObjetoDatos", tipo);
            propiedad.Asociacion = Asociacion.Composicion;
            propiedad.Cardinalidad = Cardinalidad.Uno;

            propiedad = tipo.CrearPropiedad("ReferenciaObjetoDatosItem", tipo);
            propiedad.Asociacion = Asociacion.Composicion;
            propiedad.Cardinalidad = Cardinalidad.Cero_Muchos;

            return tipo;
        }

        public static void Construir2(Tipo tipo)
        {
            Construir2(tipo, (Tipo)HelperTipo.ObtenerTipo());
        }

        public static void Construir2(Tipo tipo, Tipo tipoReferencia2)
        {
            Construir(tipo);
            Propiedad propiedad = tipo.CrearPropiedad("ReferenciaObjetoDatos2", tipoReferencia2);
            propiedad.Asociacion = Asociacion.Agregacion;
            propiedad.Cardinalidad = Cardinalidad.Uno;
        }

        public static void Construir3(Tipo tipo)
        {
            Construir3(tipo, (Tipo)HelperTipo.ObtenerTipo());
        }

        public static void Construir3(Tipo tipo, Tipo tipoReferencia2)
        {
            Construir2(tipo, tipoReferencia2);
            Propiedad propiedad = tipo.CrearPropiedad("ReferenciaObjetoDatosItem2", tipo);
            propiedad.Asociacion = Asociacion.Agregacion;
            propiedad.Cardinalidad = Cardinalidad.Uno;
        }
    }
}
