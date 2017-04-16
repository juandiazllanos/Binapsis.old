using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Estructura.Helpers
{
    public static class Primarios
    {
        static Primarios()
        {
            Boolean = new Tipo { Nombre = "Boolean", Alias = "bool", EsTipoDeDato = true, Uri = "System" };
            Byte = new Tipo { Nombre = "Byte", Alias = "byte", EsTipoDeDato = true, Uri = "System" };
            Char = new Tipo { Nombre = "Char", Alias = "char", EsTipoDeDato = true, Uri = "System" };
            DateTime = new Tipo { Nombre = "DateTime", Alias = "DateTime", EsTipoDeDato = true, Uri = "System" };
            Decimal = new Tipo { Nombre = "Decimal", Alias = "decimal", EsTipoDeDato = true, Uri = "System" };
            Double = new Tipo { Nombre = "Double", Alias = "double", EsTipoDeDato = true, Uri = "System" };
            Float = new Tipo { Nombre = "Single", Alias = "float", EsTipoDeDato = true, Uri = "System" };
            Integer = new Tipo { Nombre = "Int32", Alias = "int", EsTipoDeDato = true, Uri = "System" };
            Long = new Tipo { Nombre = "Int64", Alias = "long", EsTipoDeDato = true, Uri = "System" };
            Object = new Tipo { Nombre = "Object", Alias = "object", EsTipoDeDato = true, Uri = "System" };
            SByte = new Tipo { Nombre = "SByte", Alias = "sbyte", EsTipoDeDato = true, Uri = "System" };
            Short = new Tipo { Nombre = "Int16", Alias = "short", EsTipoDeDato = true, Uri = "System" };
            String = new Tipo { Nombre = "String", Alias = "string", EsTipoDeDato = true, Uri = "System" };
            UInteger = new Tipo { Nombre = "UInt32", Alias = "uint", EsTipoDeDato = true, Uri = "System" };
            ULong = new Tipo { Nombre = "UInt64", Alias = "ulong", EsTipoDeDato = true, Uri = "System" };
            UShort = new Tipo { Nombre = "UInt16", Alias = "ushort", EsTipoDeDato = true, Uri = "System" };

            // construir tipo
            Tipo tipo = new Tipo { Nombre = "Tipo", Alias = "tipo", Uri = "Binapsis.Plataforma.Estructura.Metadata" };
            Tipo propiedad = new Tipo { Nombre = "Propiedad", Alias = "propiedad", Uri = "Binapsis.Plataforma.Estructura.Metadata" };

            tipo.AgregarPropiedad(new Propiedad { Nombre = "Alias", Alias = "alias", Tipo = String });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Base", Alias = "base", Tipo = tipo, Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.Cero_Uno });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "EsTipoDeDatos", Alias = "esTipoDeDatos", Tipo = Boolean });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Nombre", Alias = "nombre", Tipo = String });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Uri", Alias = "uri", Tipo = String });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Propiedades", Alias = "propiedades", Tipo = propiedad, Asociacion = Asociacion.Composicion, Cardinalidad = Cardinalidad.Cero_Muchos });

            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Nombre", Alias = "nombre", Tipo = String });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Alias", Alias = "alias", Tipo = String });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Asociacion", Alias = "asociacion", Tipo = Byte });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Cardinalidad", Alias = "cardinalidad", Tipo = Byte });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Indice", Alias = "indice", Tipo = Integer });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Tipo", Alias = "tipo", Tipo = tipo, Asociacion = Asociacion.Composicion, Cardinalidad = Cardinalidad.Uno });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "ValorInicial", Alias = "valorInicial", Tipo = Object });

            Tipo = tipo;
        }


        public static ITipo Boolean { get; private set; }

        public static ITipo Byte { get; private set; }

        public static ITipo Char { get; private set; }

        public static ITipo DateTime { get; private set; }

        public static ITipo Decimal { get; private set; }

        public static ITipo Double { get; private set; }

        public static ITipo Float { get; private set; }

        public static ITipo Integer { get; private set; }

        public static ITipo Long { get; private set; }

        public static ITipo Object { get; private set; }

        public static ITipo SByte { get; private set; }

        public static ITipo Short { get; private set; }

        public static ITipo String { get; private set; }

        public static ITipo UInteger { get; private set; }

        public static ITipo ULong { get; private set; }

        public static ITipo UShort { get; private set; }

        public static ITipo Tipo { get; private set; }
        
    }
    
}
