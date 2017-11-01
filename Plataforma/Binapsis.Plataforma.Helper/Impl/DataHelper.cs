using System;
using Binapsis.Plataforma.Estructura;
using System.Globalization;
using DataTypeHelper = System.Convert;

namespace Binapsis.Plataforma.Helper.Impl
{
    public class DataHelper : IDataHelper
    {
        const string TYPE_BOOLEAN   = "Boolean";
        const string TYPE_BYTE      = "Byte";
        const string TYPE_CHAR      = "Char";
        const string TYPE_DATETIME  = "DateTime";
        const string TYPE_DECIMAL   = "Decimal";
        const string TYPE_DOUBLE    = "Double";
        const string TYPE_INT16     = "Int16";
        const string TYPE_INT32     = "Int32";
        const string TYPE_INT64     = "Int64";
        const string TYPE_SBYTE     = "SByte";
        const string TYPE_SINGLE    = "Single";
        const string TYPE_STRING    = "String";
        const string TYPE_UINT16    = "UInt16";
        const string TYPE_UINT32    = "UInt32";
        const string TYPE_UINT64    = "UInt64";

        #region Constructores
        private DataHelper()
        {
            FormatProvider = CultureInfo.CurrentCulture;
        }

        static DataHelper()
        {
            Instancia = new DataHelper();
        }
        #endregion


        #region Metodos
        private object Convert(string type, object value)
        {
            switch(type)
            {
                case TYPE_BOOLEAN:
                    return DataTypeHelper.ToBoolean(value);
                case TYPE_BYTE:
                    return DataTypeHelper.ToByte(value);
                case TYPE_CHAR:
                    return DataTypeHelper.ToChar(value);
                case TYPE_DATETIME:
                    return DataTypeHelper.ToDateTime(value);
                case TYPE_DECIMAL:
                    return DataTypeHelper.ToDecimal(value);
                case TYPE_DOUBLE:
                    return DataTypeHelper.ToDouble(value);
                case TYPE_INT16:
                    return DataTypeHelper.ToInt16(value);
                case TYPE_INT32:
                    return DataTypeHelper.ToInt32(value);
                case TYPE_INT64:
                    return DataTypeHelper.ToInt64(value);
                case TYPE_SBYTE:
                    return DataTypeHelper.ToSByte(value);
                case TYPE_SINGLE:
                    return DataTypeHelper.ToSingle(value);
                case TYPE_STRING:
                    return DataTypeHelper.ToString(value);
                case TYPE_UINT16:
                    return DataTypeHelper.ToUInt16(value);
                case TYPE_UINT32:
                    return DataTypeHelper.ToUInt32(value);
                case TYPE_UINT64:
                    return DataTypeHelper.ToUInt64(value);
                default:
                    return value;
            }
        }

        public object Convert(Type type, object value)
        {
            return Convert(type.Name, value);
        }

        public object Convert(ITipo tipo, object value)
        {
            if (tipo.EsTipoDeDato)
                return Convert(tipo.Nombre, value);
            else
                return value;
        }

        public object Convert(IPropiedad propiedad, object value)
        {
            return Convert(propiedad.Tipo, value);
        }

        public DateTime ToDateTime(string dateString)
        {
            return DateTime.Parse(dateString);
        }

        public string ToDateTime(DateTime date)
        {
            return null;
        }

        public string ToDay(DateTime date)
        {
            return DateTimeFormatInfo.GetInstance(FormatProvider).GetDayName(date.DayOfWeek);
        }

        public string ToDuration(DateTime date)
        {
            return null;
        }

        public string ToMonth(DateTime date)
        {
            return null;
        }

        public string ToMonthDay(DateTime date)
        {
            return null;
        }

        public string ToTime(DateTime date)
        {
            return null;
        }

        public string ToYear(DateTime date)
        {
            return null;
        }

        public string ToYearMonth(DateTime date)
        {
            return null;
        }

        public string ToYearMonthDay(DateTime date)
        {
            return null;
        }
        #endregion


        #region Propiedades
        public static DataHelper Instancia
        {
            get;
        }

        public IFormatProvider FormatProvider
        {
            get;
        }
        #endregion
    }
}
