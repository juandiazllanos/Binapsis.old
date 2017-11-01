using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Helper.Impl
{
    public class DefaultValueHelper : IDefaultValueHelper
    {
        const string TYPE_BOOLEAN = "Boolean";
        const string TYPE_BYTE = "Byte";
        const string TYPE_CHAR = "Char";
        const string TYPE_DATETIME = "DateTime";
        const string TYPE_DECIMAL = "Decimal";
        const string TYPE_DOUBLE = "Double";
        const string TYPE_INT16 = "Int16";
        const string TYPE_INT32 = "Int32";
        const string TYPE_INT64 = "Int64";
        const string TYPE_SBYTE = "SByte";
        const string TYPE_SINGLE = "Single";
        const string TYPE_STRING = "String";
        const string TYPE_UINT16 = "UInt16";
        const string TYPE_UINT32 = "UInt32";
        const string TYPE_UINT64 = "UInt64";


        #region Estático
        static DefaultValueHelper()
        {
            Instancia = new DefaultValueHelper();
        }

        public static DefaultValueHelper Instancia
        {
            get;
        }
        #endregion


        #region Metodos
        public object GetDefaultValue(IPropiedad propiedad)
        {
            if (propiedad == null) return null;

            string valorInicial = propiedad.ValorInicial?.ToString();

            if (string.IsNullOrEmpty(valorInicial))
                return GetDefaultValue(propiedad.Tipo);
            else
                return DataHelper.Instancia.Convert(propiedad.Tipo, valorInicial);
        }

        public object GetDefaultValue(ITipo tipo)
        {
            switch (tipo.Nombre)
            {
                case TYPE_BOOLEAN:
                    return default(Boolean);
                case TYPE_BYTE:
                    return default(Byte);
                case TYPE_CHAR:
                    return default(Char);
                case TYPE_DATETIME:
                    return default(DateTime);
                case TYPE_DECIMAL:
                    return default(Decimal);
                case TYPE_DOUBLE:
                    return default(Double);
                case TYPE_INT16:
                    return default(Int16);
                case TYPE_INT32:
                    return default(Int32);
                case TYPE_INT64:
                    return default(Int64);
                case TYPE_SBYTE:
                    return default(SByte);
                case TYPE_SINGLE:
                    return default(Single);
                case TYPE_STRING:
                    return string.Empty;
                    //return default(String);
                case TYPE_UINT16:
                    return default(UInt16);
                case TYPE_UINT32:
                    return default(UInt32);
                case TYPE_UINT64:
                    return default(UInt64);
                default:
                    return null;
            }
        }

        public bool IsDefaultValue(IPropiedad propiedad, object value)
        {
            if (value != null)
                return GetDefaultValue(propiedad)?.Equals(value) ?? false;
            else
                return false;
        }
        #endregion
    }
}
