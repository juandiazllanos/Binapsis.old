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
            Ensamblado ensamSystem = new Ensamblado { Nombre = "mscorlib" };
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
            tipoUri.CrearPropiedad("Ensamblado", tipoEnsamblado, "ensamblado").Asociacion = Asociacion.Agregacion;            
            tipoUri.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");

            Tipo tipoTipo = new Tipo { Uri = uriConfig, Nombre = "Tipo", Alias = "tipo" };
            Tipo tipoPropiedad = new Tipo { Uri = uriConfig, Nombre = "Propiedad", Alias = "propiedad" };

            // agregar propiedades del tipo 'Propiedad'
            tipoPropiedad.CrearPropiedad("Alias", Obtener(typeof(string)), "alias");
            tipoPropiedad.CrearPropiedad("Asociacion", Obtener(typeof(byte)), "asociacion");
            tipoPropiedad.CrearPropiedad("Cardinalidad", Obtener(typeof(byte)), "cardinalidad");
            tipoPropiedad.CrearPropiedad("Indice", Obtener(typeof(byte)), "indice");
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


            // contexto 
            Tipo tipoContexto = new Tipo { Uri = uriConfig, Nombre = "Contexto", Alias = "contexto" };
            tipoContexto.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");
            tipoContexto.CrearPropiedad("Url", Obtener(typeof(string)), "url");

            // conexion
            Tipo tipoConexion = new Tipo() { Uri = uriConfig, Nombre = "Conexion", Alias = "conexion" };
            tipoConexion.CrearPropiedad("CadenaConexion", Obtener(typeof(string)));
            tipoConexion.CrearPropiedad("Nombre", Obtener(typeof(string)));


            // columna
            Tipo tipoColumna = new Tipo { Uri = uriConfig, Nombre = "Columna", Alias = "columna" };
            tipoColumna.CrearPropiedad("ClavePrincipal", Obtener(typeof(bool)), "clavePrimaria");
            tipoColumna.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");
            tipoColumna.CrearPropiedad("Propiedad", Obtener(typeof(string)), "propiedad");


            // tabla
            Tipo tipoTabla = new Tipo { Uri = uriConfig, Nombre = "Tabla", Alias = "tabla" };
            Propiedad propiedadColumna = tipoTabla.CrearPropiedad("Columnas", tipoColumna, "columnas");
            propiedadColumna.Asociacion = Asociacion.Composicion;
            propiedadColumna.Cardinalidad = Cardinalidad.CeroAMuchos;
            tipoTabla.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");
            tipoTabla.CrearPropiedad("Tipo", Obtener(typeof(string)), "tipo");


            // relacion
            Tipo tipoRelacion = new Tipo { Uri = uriConfig, Nombre = "Relacion", Alias = "relacion" };
            tipoRelacion.CrearPropiedad("ColumnaPrincipal", Obtener(typeof(string)), "columnaPrincipal");
            tipoRelacion.CrearPropiedad("ColumnaSecundaria", Obtener(typeof(string)), "columnaSecundaria");
            tipoRelacion.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");
            tipoRelacion.CrearPropiedad("Propiedad", Obtener(typeof(string)), "propiedad");
            tipoRelacion.CrearPropiedad("TablaPrincipal", Obtener(typeof(string)), "tablaPrincipal");
            tipoRelacion.CrearPropiedad("TablaSecundaria", Obtener(typeof(string)), "tablaSecundaria");            
            tipoRelacion.CrearPropiedad("Tipo", Obtener(typeof(string)), "tipo");


            // parametro 
            Tipo tipoParametro = new Tipo { Uri = uriConfig, Nombre = "Parametro", Alias = "parametro" };
            tipoParametro.CrearPropiedad("Direccion", Obtener(typeof(string)), "direccion");
            tipoParametro.CrearPropiedad("Indice", Obtener(typeof(int)), "indice");
            tipoParametro.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre" );
            tipoParametro.CrearPropiedad("Longitud", Obtener(typeof(int)), "longitud" );
            tipoParametro.CrearPropiedad("Tipo", Obtener(typeof(string)), "tipo" );
            
            // resultadoDescriptor 
            Tipo tipoResultadoDescriptor = new Tipo { Uri = uriConfig, Nombre = "ResultadoDescriptor", Alias = "resultadoDescriptor" };
            tipoResultadoDescriptor.CrearPropiedad("Columna", Obtener(typeof(string)), "columna" );
            tipoResultadoDescriptor.CrearPropiedad("Indice", Obtener(typeof(int)), "indice" );
            tipoResultadoDescriptor.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre" );
            tipoResultadoDescriptor.CrearPropiedad("Tabla", Obtener(typeof(string)), "tabla" );
            tipoResultadoDescriptor.CrearPropiedad("Tipo", Obtener(typeof(string)), "tipo" );
            
            // comando 
            Tipo tipoComando = new Tipo { Uri = uriConfig, Nombre = "Comando", Alias = "comando" };
            tipoComando.CrearPropiedad("ComandoTipo", Obtener(typeof(byte)), "comandoTipo" );
            tipoComando.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");
            tipoComando.CrearPropiedad("Sql", Obtener(typeof(string)), "sql");
            Propiedad propiedadParametros = tipoComando.CrearPropiedad("Parametros", tipoParametro, "parametros");
            propiedadParametros.Asociacion = Asociacion.Composicion;
            propiedadParametros.Cardinalidad = Cardinalidad.CeroAMuchos;
            Propiedad propiedadResultadoDescriptores = tipoComando.CrearPropiedad("ResultadoDescriptores", tipoResultadoDescriptor, "resultadoDescriptores");
            propiedadResultadoDescriptores.Asociacion = Asociacion.Composicion;
            propiedadResultadoDescriptores.Cardinalidad = Cardinalidad.CeroAMuchos;


            Agregar(tipoEnsamblado);
            Agregar(tipoUri);            
            Agregar(tipoPropiedad);
            Agregar(tipoTipo);

            Agregar(tipoContexto);
            Agregar(tipoConexion);
            Agregar(tipoColumna);
            Agregar(tipoTabla);
            Agregar(tipoRelacion);

            Agregar(tipoParametro);
            Agregar(tipoResultadoDescriptor);
            Agregar(tipoComando);
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
