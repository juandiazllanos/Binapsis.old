using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Base
{
    internal class BaseTypes
    {
        Dictionary<string, Tipo> _cache;

        static BaseTypes()
        {
            Instancia = new BaseTypes();
        }

        public BaseTypes()
        {
            _cache = new Dictionary<string, Tipo>();
            Crear();
        }
        
        public ITipo Obtener(Type type)
        {
            return Obtener(type.Namespace, type.Name);
        }

        public ITipo Obtener(string uri, string tipo)
        {
            string clave = $"{uri}.{tipo}";

            if (_cache.ContainsKey(clave))
                return _cache[clave];
            else
                return null;
        }

        private void Crear()
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
            Tipo ensambladoTipo = new Tipo() { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Ensamblado" };
            ensambladoTipo.AgregarPropiedad(new Propiedad() { Nombre = "Nombre", Tipo = Obtener("System", "String") });
            Agregar(ensambladoTipo);

            // uri
            Tipo uriTipo = new Tipo() { Uri = "Binapsis.Plataforma.Configuracion", Nombre = "Uri" };
            uriTipo.AgregarPropiedad(new Propiedad() { Nombre = "Nombre", Tipo = Obtener("System", "String") });
            uriTipo.AgregarPropiedad(new Propiedad() { Nombre = "Ensamblado", Tipo = ensambladoTipo, Alias = "Ensamblado", Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.Uno });
            Agregar(uriTipo);
            
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
            tipo.AgregarPropiedad(new Propiedad { Nombre = "Uri", Alias = "uri", Tipo = uriTipo, Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.Uno });            
            tipo.AgregarPropiedad(new Propiedad { Nombre = "EsTipoDeDato", Alias = "esTipoDeDato", Tipo = Obtener("System", "Boolean") });
                        
            Agregar(propiedad);
            Agregar(tipo);

        }

        private void Agregar(Tipo tipo)
        {
            _cache.Add($"{tipo.Uri}.{tipo.Nombre}", tipo);
        }

        public static BaseTypes Instancia { get; }
    }
}
