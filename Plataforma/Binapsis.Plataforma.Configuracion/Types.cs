using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion
{
    public class Types
    {
        Dictionary<string, Tipo> _cache;
        //BaseTypes _types;

        static Types()
        {
            Instancia = new Types();
        }

        public Types()
        {
            _cache = new Dictionary<string, Tipo>();

            Crear();
        }

        private void Crear()
        {      
            Ensamblado ensamSystem = new Ensamblado { Nombre = "System" };
            Uri uriSystem = new Uri { Ensamblado = ensamSystem, Nombre = "System" };  
            
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Boolean", Alias = "bool", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Byte", Alias = "byte", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Char", Alias = "char", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "DateTime", Alias = "DateTime", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Decimal", Alias = "decimal", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Double", Alias = "double", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Int16", Alias = "short", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Int32", Alias = "int", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Int64", Alias = "long", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Object", Alias = "object", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "SByte", Alias = "sbyte", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "Single", Alias = "float", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "String", Alias = "string", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "UInt16", Alias = "ushort", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "UInt32", Alias = "uint", EsTipoDeDato = true });
            Agregar(new Tipo { Uri = uriSystem, Nombre = "UInt64", Alias = "long", EsTipoDeDato = true });

            Ensamblado ensamConfig = new Ensamblado { Nombre = "Binapsis.Plataforma.Configuracion" };
            Uri uriConfig = new Uri { Ensamblado = ensamConfig, Nombre = "Binapsis.Plataforma.Configuracion" };

            Tipo tipoEnsamblado = new Tipo { Uri = uriConfig, Nombre = "Ensamblado", Alias = "ensamblado" };
            tipoEnsamblado.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");

            Tipo tipoUri = new Tipo { Uri = uriConfig, Nombre = "Uri", Alias = "uri" };
            tipoUri.CrearPropiedad("Ensamblado", tipoEnsamblado, "ensamblado");
            tipoUri.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");

            Tipo tipoTipo = new Tipo { Uri = uriConfig, Nombre = "Tipo", Alias = "tipo" };
            Tipo tipoPropiedad = new Tipo { Uri = uriConfig, Nombre = "Propiedad", Alias = "propiedad" };

            // agregar propiedades del tipo 'Propiedad'
            tipoPropiedad.CrearPropiedad("Alias", Obtener(typeof(string)), "alias");
            tipoPropiedad.CrearPropiedad("Asociacion", Obtener(typeof(byte)), "asociacion");
            tipoPropiedad.CrearPropiedad("Cardinalidad", Obtener(typeof(byte)), "cardinalidad");
            tipoPropiedad.CrearPropiedad("Indice", Obtener(typeof(int)), "indice");
            tipoPropiedad.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");
            tipoPropiedad.CrearPropiedad("ValorInicial", Obtener(typeof(string)), "valorInicial");

            Propiedad propiedad = tipoPropiedad.CrearPropiedad("Tipo", tipoTipo, "tipo");
            propiedad.Asociacion = Asociacion.Agregacion;
            propiedad.Cardinalidad = Cardinalidad.Uno;

            // agregar propiedades del tipo 'Tipo'
            propiedad = tipoTipo.CrearPropiedad("Base", tipoTipo, "base");            
            propiedad.Asociacion = Asociacion.Agregacion;
            propiedad.Cardinalidad = Cardinalidad.CeroAUno;

            propiedad = tipoTipo.CrearPropiedad("Propiedades", tipoPropiedad, "propiedades");
            propiedad.Asociacion = Asociacion.Composicion;
            propiedad.Cardinalidad = Cardinalidad.CeroAMuchos;

            propiedad = tipoTipo.CrearPropiedad("Uri", tipoUri, "uri");
            propiedad.Asociacion = Asociacion.Agregacion;
            propiedad.Cardinalidad = Cardinalidad.Uno;

            tipoTipo.CrearPropiedad("Alias", Obtener(typeof(string)), "alias");            
            tipoTipo.CrearPropiedad("EsTipoDeDato", Obtener(typeof(bool)), "esTipoDeDato");
            tipoTipo.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");


            Agregar(tipoEnsamblado);
            Agregar(tipoUri);            
            Agregar(tipoPropiedad);
            Agregar(tipoTipo);
            
        }
        
        private void Agregar(Tipo tipo)
        {
            _cache.Add($"{tipo.Uri.Nombre}.{tipo.Nombre}", tipo);
        }

        public Tipo Obtener(Type type)
        {
            return Obtener(type.Namespace, type.Name);
        }

        public Tipo Obtener(string uri, string tipo)
        {
            string clave = $"{uri}.{tipo}";

            if (_cache.ContainsKey(clave))
                return _cache[clave];
            else
                return null;
        }

        public static Types Instancia { get; private set; }
    }
}
