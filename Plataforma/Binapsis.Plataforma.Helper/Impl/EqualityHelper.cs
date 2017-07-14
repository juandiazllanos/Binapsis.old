using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Helper.Impl
{
    public class EqualityHelper : IEqualityHelper
    {
        #region Constructores
        private EqualityHelper()
        {
        }

        static EqualityHelper()
        {
            Instancia = new EqualityHelper();
        }
        #endregion


        #region Singleton
        public static EqualityHelper Instancia
        {
            get;
        }
        #endregion


        #region Metodos
        public bool Igual(IObjetoDatos od1, IObjetoDatos od2)
        {
            return Igual(od1, od2, false);
        }

        public bool IgualSuperficial(IObjetoDatos od1, IObjetoDatos od2)
        {
            return Igual(od1, od2, true);
        }

        private bool Igual(IObjetoDatos od1, IObjetoDatos od2, bool superficial)
        {
            if ((od1 == null && od2 == null) || ReferenceEquals(od1, od2)) return true;
            if (od1 == null || od2 == null || od1.Tipo != od2.Tipo) return false;
            
            bool resul = true;
            ITipo tipo = od1.Tipo;

            foreach(IPropiedad propiedad in tipo.Propiedades)
            {
                if (propiedad.Tipo.EsTipoDeDato)
                    resul = Igual(od1, od2, propiedad);
                else if (superficial)
                    continue;
                else if (propiedad.Cardinalidad == Cardinalidad.CeroAMuchos)
                    resul = Igual(od1.ObtenerColeccion(propiedad), od2.ObtenerColeccion(propiedad));
                else //if (propiedad.Asociacion == Asociacion.Agregacion)
                //    resul = ReferenceEquals(od1.ObtenerObjetoDatos(propiedad), od2.ObtenerObjetoDatos(propiedad));
                //else
                    resul = Igual(od1.ObtenerObjetoDatos(propiedad), od2.ObtenerObjetoDatos(propiedad));

                if (!resul) break;
            }

            return resul;
        }
        
        public bool Igual(IColeccion col1, IColeccion col2)
        {
            // validar
            if (col1 == null || col2 == null || col1.Longitud != col2.Longitud) return false;
            if (ReferenceEquals(col1, col2)) return true;

            bool resul = true;
            int items = col1.Longitud;

            for (int i = 0; i < items; i++)
            {
                resul = Igual(col1[i], col2[i]);
                if (!resul) break;
            }

            return resul;
        }

        public bool Igual(IObjetoDatos od1, IObjetoDatos od2, IPropiedad propiedad)
        {
            // verificar
            if (od1 == null || od2 == null || propiedad == null || !propiedad.Tipo.EsTipoDeDato || 
                od1.Establecido(propiedad) != od2.Establecido(propiedad)) return false;

            // verificar si no han sido establecidos
            if (!od1.Establecido(propiedad) && !od2.Establecido(propiedad)) return true;
            
            switch(propiedad.Tipo.Nombre)
            {
                case "Boolean":
                    return od1.ObtenerBoolean(propiedad) == od2.ObtenerBoolean(propiedad);

                case "Byte":
                    return od1.ObtenerByte(propiedad) == od2.ObtenerByte(propiedad);

                case "Char":
                    return od1.ObtenerChar(propiedad) == od2.ObtenerChar(propiedad);

                case "DateTime":
                    return Igual(od1.ObtenerDateTime(propiedad), od2.ObtenerDateTime(propiedad));

                case "Decimal":
                    return od1.ObtenerDecimal(propiedad) == od2.ObtenerDecimal(propiedad);

                case "Int16":
                    return od1.ObtenerShort(propiedad) == od2.ObtenerShort(propiedad);

                case "Double":
                    return od1.ObtenerDouble(propiedad) == od2.ObtenerDouble(propiedad);

                case "Int32":
                    return od1.ObtenerInteger(propiedad) == od2.ObtenerInteger(propiedad);

                case "Int64":
                    return od1.ObtenerLong(propiedad) == od2.ObtenerLong(propiedad);

                case "SByte":
                    return od1.ObtenerSByte(propiedad) == od2.ObtenerSByte(propiedad);

                case "Single":
                    return od1.ObtenerFloat(propiedad) == od2.ObtenerFloat(propiedad);

                case "String":
                    return od1.ObtenerString(propiedad) == od2.ObtenerString(propiedad);

                case "UInt16":
                    return od1.ObtenerUShort(propiedad) == od2.ObtenerUShort(propiedad);

                case "UInt32":
                    return od1.ObtenerUInteger(propiedad) == od2.ObtenerUInteger(propiedad);

                case "UInt64":
                    return od1.ObtenerULong(propiedad) == od2.ObtenerULong(propiedad);
                    
            }

            return false;
        }
        

        private bool Igual(DateTime valor1, DateTime valor2)
        {
            return  valor1.Year == valor2.Year &&
                    valor1.Month == valor2.Month &&
                    valor1.Day == valor2.Day &&
                    valor1.Hour == valor2.Hour &&
                    valor1.Minute == valor2.Minute &&
                    valor1.Second == valor2.Second;
        }
        #endregion

    }
}
