using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Configuracion.Helper
{
    public class ValorInicialHelper
    {
        static ValorInicialHelper()
        {
            Instancia = new ValorInicialHelper();
        }
                
        public static ValorInicialHelper Instancia
        {
            get;
        }

        public object Obtener(IPropiedad propiedad)
        {            
            if (!propiedad.Tipo.EsTipoDeDato) return null;

            object valor = propiedad.ValorInicial;
            string valorInicial = valor as string ?? valor?.ToString();
            
            if (string.IsNullOrEmpty(valorInicial))
                valor = Obtener(propiedad.Tipo);
            else
                valor = Resolver(propiedad.Tipo, valorInicial);

            return valor;
        }

        public object Obtener(ITipo tipo)
        {
            if (!tipo.EsTipoDeDato) return null;

            switch (tipo.Nombre)
            {
                case "Boolean":
                    return default(bool);
                case "Byte":
                    return default(byte);
                case "Char":
                    return default(char);
                case "DateTime":
                    return default(DateTime);
                case "Decimal":
                    return default(decimal);
                case "Double":
                    return default(double);
                case "Int16":
                    return default(short);
                case "Int32":
                    return default(int);
                case "Int64":
                    return default(long);
                case "Single":
                    return default(float);
                case "String":
                    return string.Empty;
                    //return default(string);
                case "UInt16":
                    return default(ushort);
                case "UInt32":
                    return default(uint);
                case "UInt64":
                    return default(ulong);
                default:
                    return null;
            }
        }
        
        public bool Validar(ITipo tipo, string valorInicial)
        {
            switch (tipo.Nombre)
            {
                case "Boolean":
                    return bool.TryParse(valorInicial, out _);
                case "Byte":
                    return byte.TryParse(valorInicial, out _);
                case "Char":
                    return char.TryParse(valorInicial, out _);
                case "DateTime":
                    return DateTime.TryParse(valorInicial, out _);
                case "Decimal":
                    return decimal.TryParse(valorInicial, out _);
                case "Double":
                    return double.TryParse(valorInicial, out _);
                case "Int16":
                    return short.TryParse(valorInicial, out _);
                case "Int32":
                    return int.TryParse(valorInicial, out _);
                case "Int64":
                    return long.TryParse(valorInicial, out _);
                case "SByte":
                    return sbyte.TryParse(valorInicial, out _);
                case "Single":
                    return float.TryParse(valorInicial, out _);
                case "String":
                    return true;
                case "UInt16":
                    return ushort.TryParse(valorInicial, out _);
                case "UInt32":
                    return uint.TryParse(valorInicial, out _);
                case "UInt64":
                    return ulong.TryParse(valorInicial, out _);
                default:
                    return false;
            }
        }

        public object Resolver(ITipo tipo, string valorInicial)
        {
            if (!Validar(tipo, valorInicial)) return null;

            switch (tipo.Nombre)
            {
                case "Boolean":
                    return Convert.ToBoolean(valorInicial);
                case "Byte":
                    return Convert.ToByte(valorInicial);
                case "Char":
                    return Convert.ToChar(valorInicial);
                case "DateTime":
                    return Convert.ToDateTime(valorInicial);
                case "Decimal":
                    return Convert.ToDecimal(valorInicial);
                case "Double":
                    return Convert.ToDouble(valorInicial);
                case "Int16":
                    return Convert.ToInt16(valorInicial);
                case "Int32":
                    return Convert.ToInt32(valorInicial);
                case "Int64":
                    return Convert.ToInt64(valorInicial);
                case "SByte":
                    return Convert.ToSByte(valorInicial);
                case "Single":
                    return Convert.ToSingle(valorInicial);
                case "String":
                    return valorInicial;
                case "UInt16":
                    return Convert.ToUInt16(valorInicial);
                case "UInt32":
                    return Convert.ToUInt32(valorInicial);
                case "UInt64":
                    return Convert.ToUInt64(valorInicial);
                default:
                    return null;
            }
        }
        
    }
}
