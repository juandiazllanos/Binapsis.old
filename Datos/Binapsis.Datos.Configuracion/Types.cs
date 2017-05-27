using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;
using EspacioNombre = Binapsis.Plataforma.Configuracion.Uri;
using TypesConfiguracion = Binapsis.Plataforma.Configuracion.Types;

namespace Binapsis.Datos.Configuracion
{
    internal class Types
    {
        FabricaConfiguracion _fabrica;
        Dictionary<Type, Tipo> _tipos;
        TypesConfiguracion _types;

        private Types()
        {
            _fabrica = new FabricaConfiguracion();
            _tipos = new Dictionary<Type, Tipo>();
            _types = TypesConfiguracion.Instancia;

            Crear();
        }

        public static Types Instancia { get; } = new Types();

        void Crear()
        {
            Ensamblado ensam = _fabrica.CrearEnsamblado("Binapsis.Datos.Configuracion");
            EspacioNombre uri = _fabrica.CrearUri(ensam, "Binapsis.Datos.Configuracion");
            Tipo tipoConexion = _fabrica.CrearTipo(uri, "Conexion");

            tipoConexion.CrearPropiedad("Nombre", Obtener(typeof(string)), "nombre");
            tipoConexion.CrearPropiedad("CadenaConexion", Obtener(typeof(string)));

            Tipo tipoTabla = _fabrica.CrearTipo(uri, "Tabla");
            tipoTabla.CrearPropiedad("Nombre", Obtener(typeof(string)));
            tipoTabla.CrearPropiedad("Tipo", Obtener(typeof(string)));

            Tipo tipoColumna = _fabrica.CrearTipo(uri, "Columna");
            tipoColumna.CrearPropiedad("Nombre", Obtener(typeof(string)));
            tipoColumna.CrearPropiedad("Propiedad", Obtener(typeof(string)));

            Propiedad propiedad = tipoTabla.CrearPropiedad("Columnas", tipoColumna);
            propiedad.Asociacion = Asociacion.Composicion;
            propiedad.Cardinalidad = Cardinalidad.Muchos;

            Tipo tipoRelacion = _fabrica.CrearTipo(uri, "Relacion");
            tipoRelacion.CrearPropiedad("ColumnaPrincipal", Obtener(typeof(string)));
            tipoRelacion.CrearPropiedad("ColumnaSecundaria", Obtener(typeof(string)));
            tipoRelacion.CrearPropiedad("Nombre", Obtener(typeof(string)));
            tipoRelacion.CrearPropiedad("Propiedad", Obtener(typeof(string)));                        
            tipoRelacion.CrearPropiedad("TablaPrincipal", Obtener(typeof(string)));
            tipoRelacion.CrearPropiedad("TablaSecundaria", Obtener(typeof(string)));
            tipoRelacion.CrearPropiedad("Tipo", Obtener(typeof(string)));

            _tipos.Add(typeof(Conexion), tipoConexion);
            _tipos.Add(typeof(Tabla), tipoTabla);
            _tipos.Add(typeof(Columna), tipoColumna);
            _tipos.Add(typeof(Relacion), tipoRelacion);

        }

        public Tipo Obtener(Type type)
        {
            Tipo item = _types.Obtener(type);

            if (item != null)
                return item;
            else if (_tipos.ContainsKey(type))
                return _tipos[type];
            else
                return null;
        }
    }
}
