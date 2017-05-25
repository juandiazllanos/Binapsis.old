using Binapsis.Plataforma.Configuracion.Base;
using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion
{
    public class Types
    {
        Dictionary<string, Tipo> _cache;

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
            BaseTypes baseTypes = BaseTypes.Instancia;
            FabricaConfiguracion fabrica = new FabricaConfiguracion();

            Ensamblado ensamSystem = fabrica.CrearEnsamblado("System");
            Uri uriSystem = fabrica.CrearUri(ensamSystem, "System");  
            
            Agregar(fabrica.CrearTipo(uriSystem, "Boolean", "bool", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Byte", "byte", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Char", "char", true));
            Agregar(fabrica.CrearTipo(uriSystem, "DateTime", "DateTime", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Decimal", "decimal", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Double", "double", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Int16", "short", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Int32", "int", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Int64", "long", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Object", "object", true));
            Agregar(fabrica.CrearTipo(uriSystem, "SByte", "sbyte", true));
            Agregar(fabrica.CrearTipo(uriSystem, "Single", "float", true));
            Agregar(fabrica.CrearTipo(uriSystem, "String", "string", true));
            Agregar(fabrica.CrearTipo(uriSystem, "UInt16", "ushort", true));
            Agregar(fabrica.CrearTipo(uriSystem, "UInt32", "uint", true));
            Agregar(fabrica.CrearTipo(uriSystem, "UInt64", "long", true));

            Ensamblado ensamConfig = fabrica.CrearEnsamblado("Binapsis.Plataforma.Configuracion");
            Uri uriConfig = fabrica.CrearUri(ensamConfig, "Binapsis.Plataforma.Configuracion");

            Tipo tipoEnsamblado = fabrica.CrearTipo(uriConfig, "Ensamblado", "ensamblado");
            tipoEnsamblado.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");

            Tipo tipoUri = fabrica.CrearTipo(uriConfig, "Uri", "uri");
            tipoUri.CrearPropiedad("Ensamblado", tipoEnsamblado, "ensamblado");
            tipoUri.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");

            Tipo tipoTipo = fabrica.CrearTipo(uriConfig, "Tipo", "tipo");
            Tipo tipoPropiedad = fabrica.CrearTipo(uriConfig, "Propiedad", "propiedad");            

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

            // definicion
            Tipo tipoDefinicion = FabricaConfiguracion.Instancia.CrearTipo(uriConfig, "Definicion", "definicion");
            tipoDefinicion.CrearPropiedad("Alias", Obtener(typeof(string)), "alias");
            propiedad = tipoDefinicion.CrearPropiedad("Definiciones", tipoDefinicion, "definiciones");
            propiedad.Asociacion = Asociacion.Composicion;
            propiedad.Cardinalidad = Cardinalidad.CeroAMuchos;
            tipoDefinicion.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");
            tipoDefinicion.CrearPropiedad("Valor", Obtener(typeof(string)), "valor");

            Agregar(tipoDefinicion);
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
