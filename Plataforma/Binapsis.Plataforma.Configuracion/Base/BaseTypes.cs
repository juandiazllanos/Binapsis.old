using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Base
{
    internal static class BaseTypes
    {
        static Dictionary<string, Tipo> _cache;

        static BaseTypes()
        {
            _cache = new Dictionary<string, Tipo>();
            Crear();
        }

        private static void Agregar(Tipo tipo)
        {
            _cache.Add($"{tipo.Uri}.{tipo.Nombre}", tipo);
        }

        public static ITipo Obtener(Type type)
        {
            return Obtener(type.Namespace, type.Name);
        }

        public static ITipo Obtener(string uri, string tipo)
        {
            string clave = $"{uri}.{tipo}";

            if (_cache.ContainsKey(clave))
                return _cache[clave];
            else
                return null;
        }

        //public static ITipo this[Type type]
        //{
        //    get => Obtener(type);
        //}

        private static void Crear()
        {
            Agregar(new Tipo { Uri = "System", Nombre = "Boolean", Alias = "bool", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Byte", Alias = "byte", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Char", Alias = "char", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "DateTime", Alias = "DateTime", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Decimal", Alias = "decimal", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Double", Alias = "double", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Single", Alias = "float", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Int32", Alias = "int", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Int64", Alias = "long", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Object", Alias = "object", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "SByte", Alias = "sbyte", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "Int16", Alias = "short", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "String", Alias = "string", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "UInt32", Alias = "uint", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "UInt64", Alias = "ulong", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = "System", Nombre = "UInt16", Alias = "ushort", EsTipoDeDato = true });

            // ensamblado
            Tipo ensamblado = new Tipo() { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Ensamblado" };
            ensamblado.AgregarPropiedad(new Propiedad() { Nombre = "Nombre", Tipo = Obtener("System", "String") });
            Agregar(ensamblado);

            // uri
            Tipo uri = new Tipo() { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Uri" };
            uri.AgregarPropiedad(new Propiedad() { Nombre = "Nombre", Tipo = Obtener("System", "String") });
            uri.AgregarPropiedad(new Propiedad() { Nombre = "Ensamblado", Tipo = ensamblado, Alias = "Ensamblado", Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.Uno });
            Agregar(uri);
            
            // tipo
            Tipo tipo = new Tipo { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Tipo", Alias = "tipo" };
            Tipo propiedad = new Tipo { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Propiedad", Alias = "propiedad" };

            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Nombre", Alias = "nombre", Tipo = Obtener("System", "String") });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Alias", Alias = "alias", Tipo = Obtener("System", "String") });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Asociacion", Alias = "asociacion", Tipo = Obtener("System", "Byte") });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Cardinalidad", Alias = "cardinalidad", Tipo = Obtener("System", "Byte") });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Indice", Alias = "indice", Tipo = Obtener("System", "Int32") });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "Tipo", Alias = "tipo", Tipo = tipo, Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.Uno });
            propiedad.AgregarPropiedad(new Propiedad { Nombre = "ValorInicial", Alias = "valorInicial", Tipo = Obtener("System", "Object") });

            tipo.AgregarPropiedad(new Propiedad { Nombre = "Base", Alias = "base", Tipo = tipo, Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.CeroAUno });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Propiedades", Alias = "propiedades", Tipo = propiedad, Asociacion = Asociacion.Composicion, Cardinalidad = Cardinalidad.CeroAMuchos });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Alias", Alias = "alias", Tipo = Obtener("System", "String") });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Nombre", Alias = "nombre", Tipo = Obtener("System", "String") });
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Uri", Alias = "uri", Tipo = uri, Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.Uno });            
            tipo.AgregarPropiedad(new Propiedad { Nombre = "EsTipoDeDato", Alias = "esTipoDeDato", Tipo = Obtener("System", "Boolean") });

            Agregar(propiedad);
            Agregar(tipo);

            // definicion
            Tipo definicion = new Tipo { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Definicion", Alias = "definicion" };
            definicion.AgregarPropiedad( new Propiedad { Nombre = "Alias", Alias = "alias", Tipo = Obtener("System", "String") });
            definicion.AgregarPropiedad( new Propiedad { Nombre = "Definiciones", Alias = "definiciones", Tipo = definicion, Asociacion = Asociacion.Composicion, Cardinalidad = Cardinalidad.CeroAMuchos });            
            definicion.AgregarPropiedad( new Propiedad { Nombre = "Nombre", Alias = "nombre", Tipo = Obtener("System", "String") });
            definicion.AgregarPropiedad( new Propiedad { Nombre = "Valor", Alias = "valor", Tipo = Obtener("System", "String") });

            Agregar(definicion);


            
            // conexion
            Tipo conexion = new Tipo { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Conexion", Alias = "conexion" };
            conexion.AgregarPropiedad(new Propiedad { Nombre = "Nombre", Tipo = Obtener(typeof(string)), Alias = "nombre" });
            conexion.AgregarPropiedad(new Propiedad { Nombre = "CadenaConexion", Tipo = Obtener(typeof(string)), Alias = "cadenaConexion" });

            Agregar(conexion);

            // tabla
            Tipo tabla = new Tipo { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Tabla", Alias = "alias" };
            tabla.AgregarPropiedad(new Propiedad { Nombre = "Nombre", Tipo = Obtener(typeof(string)), Alias = "nombre" });
            tabla.AgregarPropiedad(new Propiedad { Nombre = "Tipo", Tipo = Obtener(typeof(string)), Alias = "tipo" });

            // columna
            Tipo columna = new Tipo { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Columna", Alias = "columna" };
            columna.AgregarPropiedad(new Propiedad { Nombre = "ClavePrincipal", Tipo = Obtener("System", "Boolean"), Alias = "clavePrincipal" });
            columna.AgregarPropiedad(new Propiedad { Nombre = "Nombre", Tipo = Obtener("System", "String"), Alias = "nombre" });            
            columna.AgregarPropiedad(new Propiedad { Nombre = "Propiedad", Tipo = Obtener(typeof(string)), Alias = "propiedad" });

            tabla.AgregarPropiedad(new Propiedad { Nombre = "Columnas", Tipo = columna, Alias = "columnas", Asociacion = Asociacion.Composicion, Cardinalidad = Cardinalidad.CeroAMuchos });

            Agregar(columna);
            Agregar(tabla);

            // relacion
            Tipo relacion = new Tipo { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Relacion", Alias = "alias" };
            relacion.AgregarPropiedad(new Propiedad { Nombre = "ColumnaPrincipal", Tipo = Obtener(typeof(string)), Alias = "columnaPrincipal" });
            relacion.AgregarPropiedad(new Propiedad { Nombre = "ColumnaSecundaria", Tipo = Obtener(typeof(string)), Alias = "columnaSecundaria" });
            relacion.AgregarPropiedad(new Propiedad { Nombre = "Nombre", Tipo = Obtener(typeof(string)), Alias = "nombre" });
            relacion.AgregarPropiedad(new Propiedad { Nombre = "Propiedad", Tipo = Obtener(typeof(string)), Alias = "propeidad" });
            relacion.AgregarPropiedad(new Propiedad { Nombre = "TablaPrincipal", Tipo = Obtener(typeof(string)), Alias = "tablaPrincipal" });
            relacion.AgregarPropiedad(new Propiedad { Nombre = "TablaSecundaria", Tipo = Obtener(typeof(string)), Alias = "tablaSecundaria" });            
            relacion.AgregarPropiedad(new Propiedad { Nombre = "Tipo", Tipo = Obtener(typeof(string)), Alias = "tipo" });
            
            Agregar(relacion);
        }

    }
}
