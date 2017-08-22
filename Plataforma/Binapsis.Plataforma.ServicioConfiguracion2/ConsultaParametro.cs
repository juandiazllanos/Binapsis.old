using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.ServicioConfiguracion
{
    public class ConsultaParametro
    {
        public ConsultaParametro(IPropiedad propiedad, string valor)
        {
            Propiedad = propiedad;
            Valor = Resolver(valor);
        }

        private object Resolver(string valor)
        {
            switch (Propiedad.Tipo.Nombre)
            {
                case "Boolean":
                    return Boolean.Parse(valor);
                case "Byte":
                    return Byte.Parse(valor);
                case "Char":
                    return Char.Parse(valor);
                case "Decimal":
                    return Decimal.Parse(valor);
                case "Single":
                    return Single.Parse(valor);
                case "Double":
                    return Double.Parse(valor);
                case "DateTime":
                    return DateTime.Parse(valor);
                case "Int16":
                    return Int16.Parse(valor);
                case "Int32":
                    return Int32.Parse(valor);
                case "Int64":
                    return Int64.Parse(valor);
                case "SByte":
                    return SByte.Parse(valor);
                case "String":
                    return valor;
                case "UInt16":
                    return UInt16.Parse(valor);
                case "UInt32":
                    return UInt32.Parse(valor);
                case "UInt64":
                    return UInt64.Parse(valor);
                default:
                    return null;
            }
        }

        public IPropiedad Propiedad
        {
            get;
        }

        public object Valor
        {
            get;
        }
    }
}
