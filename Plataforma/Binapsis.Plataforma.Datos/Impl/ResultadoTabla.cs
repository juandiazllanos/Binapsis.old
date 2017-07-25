using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using System;
using System.Text;

namespace Binapsis.Plataforma.Datos.Impl
{
    class ResultadoTabla
    {
        public ResultadoTabla(MapeoTabla mapeoTabla, IResultado resultado)
        {
            MapeoTabla = mapeoTabla;
            Resultado = resultado;
        }

        public MapeoTabla MapeoTabla
        {
            get;
        }

        public IResultado Resultado
        {
            get;
        }
        
        public string ObtenerClavePrincipal()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{MapeoTabla.Tipo.Uri}.{MapeoTabla.Tipo.Nombre}");

            int i = 0;

            builder.Append("[");
            foreach (MapeoColumna mapeoColumna in MapeoTabla.ObtenerMapeoColumnaClavePrincipal())
            {
                if (i++ > 0) builder.Append("&");
                builder.Append($"{mapeoColumna.Columna.Nombre}={Obtener(mapeoColumna.Columna)}");
            }
            builder.Append("]");

            return builder.ToString();
        }

        public string ObtenerClavePrincipal(MapeoRelacion mapeoRelacion)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{mapeoRelacion.TablaPrincipal.Tipo.Uri}.{mapeoRelacion.TablaPrincipal.Tipo.Nombre}");

            // leer las claves de la tabla secundaria
            int i = 0;

            builder.Append("[");
            foreach(MapeoRelacionClave claveItem in mapeoRelacion.Claves)
            {
                if (i++ > 0) builder.Append("&");
                builder.Append($"{claveItem.ClavePrincipal.Columna.Nombre}={Obtener(claveItem.ClaveSecundaria.Columna)}");
            }
            builder.Append("]");

            return builder.ToString();
        }

        public bool Siguiente()
        {
            return Resultado.Siguiente();
        }

        public object Obtener(IPropiedad propiedad)
        {
            return Obtener(MapeoTabla.ObtenerColumna(propiedad));
        }

        public bool ObtenerBoolean(IPropiedad propiedad)
        {
            return ObtenerBoolean(MapeoTabla.ObtenerColumna(propiedad));
        }

        public byte ObtenerByte(IPropiedad propiedad)
        {
            return ObtenerByte(MapeoTabla.ObtenerColumna(propiedad));
        }

        public char ObtenerChar(IPropiedad propiedad)
        {
            return ObtenerChar(MapeoTabla.ObtenerColumna(propiedad));
        }

        public DateTime ObtenerDateTime(IPropiedad propiedad)
        {
            return ObtenerDateTime(MapeoTabla.ObtenerColumna(propiedad));
        }

        public decimal ObtenerDecimal(IPropiedad propiedad)
        {
            return ObtenerDecimal(MapeoTabla.ObtenerColumna(propiedad));
        }

        public double ObtenerDouble(IPropiedad propiedad)
        {
            return ObtenerDouble(MapeoTabla.ObtenerColumna(propiedad));
        }

        public float ObtenerFloat(IPropiedad propiedad)
        {
            return ObtenerFloat(MapeoTabla.ObtenerColumna(propiedad));
        }

        public int ObtenerInteger(IPropiedad propiedad)
        {
            return ObtenerInteger(MapeoTabla.ObtenerColumna(propiedad));
        }

        public long ObtenerLong(IPropiedad propiedad)
        {
            return ObtenerInteger(MapeoTabla.ObtenerColumna(propiedad));
        }

        public object ObtenerObject(IPropiedad propiedad)
        {
            return Obtener(MapeoTabla.ObtenerColumna(propiedad));
        }

        public sbyte ObtenerSByte(IPropiedad propiedad)
        {
            return ObtenerSByte(MapeoTabla.ObtenerColumna(propiedad));
        }

        public short ObtenerShort(IPropiedad propiedad)
        {
            return ObtenerShort(MapeoTabla.ObtenerColumna(propiedad));
        }

        public string ObtenerString(IPropiedad propiedad)
        {
            return ObtenerString(MapeoTabla.ObtenerColumna(propiedad));
        }

        public uint ObtenerUInteger(IPropiedad propiedad)
        {
            return ObtenerUInteger(MapeoTabla.ObtenerColumna(propiedad));
        }

        public ulong ObtenerULong(IPropiedad propiedad)
        {
            return ObtenerULong(MapeoTabla.ObtenerColumna(propiedad));
        }

        public ushort ObtenerUShort(IPropiedad propiedad)
        {
            return ObtenerUShort(MapeoTabla.ObtenerColumna(propiedad));
        }



        public object Obtener(Columna columna)
        {
            return Resultado.Obtener(columna.Nombre);
        }

        public bool ObtenerBoolean(Columna columna)
        {
            return Resultado.ObtenerBoolean(columna.Nombre);
        }


        public byte ObtenerByte(Columna columna)
        {
            return Resultado.ObtenerByte(columna.Nombre);
        }

        public char ObtenerChar(Columna columna)
        {
            return Resultado.ObtenerChar(columna.Nombre);
        }

        public DateTime ObtenerDateTime(Columna columna)
        {
            return Resultado.ObtenerDateTime(columna.Nombre);
        }

        public decimal ObtenerDecimal(Columna columna)
        {
            return Resultado.ObtenerDecimal(columna.Nombre);
        }

        public double ObtenerDouble(Columna columna)
        {
            return Resultado.ObtenerDouble(columna.Nombre);
        }

        public float ObtenerFloat(Columna columna)
        {
            return Resultado.ObtenerFloat(columna.Nombre);
        }

        public int ObtenerInteger(Columna columna)
        {
            return Resultado.ObtenerInteger(columna.Nombre);
        }

        public long ObtenerLong(Columna columna)
        {
            return Resultado.ObtenerInteger(columna.Nombre);
        }

        public object ObtenerObject(Columna columna)
        {
            return Obtener(columna);
        }

        public sbyte ObtenerSByte(Columna columna)
        {
            return Resultado.ObtenerSByte(columna.Nombre);
        }

        public short ObtenerShort(Columna columna)
        {
            return Resultado.ObtenerShort(columna.Nombre);
        }

        public string ObtenerString(Columna columna)
        {
            return Resultado.ObtenerString(columna.Nombre);
        }

        public uint ObtenerUInteger(Columna columna)
        {
            return Resultado.ObtenerUInteger(columna.Nombre);
        }

        public ulong ObtenerULong(Columna columna)
        {
            return Resultado.ObtenerULong(columna.Nombre);
        }

        public ushort ObtenerUShort(Columna columna)
        {
            return Resultado.ObtenerUShort(columna.Nombre);
        }

    }
}
