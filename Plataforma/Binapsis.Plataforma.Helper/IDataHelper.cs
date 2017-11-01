using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Helper
{
    public interface IDataHelper
    {
        DateTime ToDateTime(string dateString);
        
        string ToDateTime(DateTime date);
        string ToDuration(DateTime date);
        string ToTime(DateTime date);
        string ToDay(DateTime date);
        string ToMonth(DateTime date);
        string ToMonthDay(DateTime date);
        string ToYear(DateTime date);
        string ToYearMonth(DateTime date);
        string ToYearMonthDay(DateTime date);

        object Convert(Type type, object value);
        object Convert(ITipo tipo, object value);
        object Convert(IPropiedad propiedad, object value);        
    }
}
