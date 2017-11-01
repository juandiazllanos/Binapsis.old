using System;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Helper;
using Binapsis.Plataforma.Cambios.Impl;
using System.Collections.Generic;

namespace Binapsis.Plataforma.ServicioDatos.Formatters.Xml
{
    public class ObjetoDatosOutput : TextOutputFormatter
    {
        #region Constructores
        static ObjetoDatosOutput()
        {
            Instancia = new ObjetoDatosOutput();
        }

        private ObjetoDatosOutput()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/xml"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        #endregion


        #region Metodos
        protected override bool CanWriteType(Type type)
        {
            return (type == typeof(ObjetoDatos) ||
                    type == typeof(DiagramaDatos) ||
                    type == typeof(Coleccion) ||
                    type == typeof(IList<DiagramaDatos>));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            ResponseBodyHelper helper = new ResponseBodyHelper(context.HttpContext);
            return helper.Resolver(context.ObjectType, context.Object);
        }
        #endregion


        #region Propiedades
        public static ObjetoDatosOutput Instancia
        {
            get;
        }
        #endregion
    }
}
