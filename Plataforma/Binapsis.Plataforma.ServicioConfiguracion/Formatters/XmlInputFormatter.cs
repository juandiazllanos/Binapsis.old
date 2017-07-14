using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

using Binapsis.Plataforma.Configuracion.Serializacion;
using Binapsis.Plataforma.Configuracion;

namespace Binapsis.Plataforma.ServicioConfiguracion.Formatters
{
    public class XmlInputFormatter : TextInputFormatter
    {
        public XmlInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue .Parse("application/xml"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);            
        }

        protected override bool CanReadType(Type type)
        {
            return type.GetTypeInfo().IsSubclassOf(typeof(ConfiguracionBase));
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            Type type = context.ModelType;
            DeserializacionBase helper = new DeserializacionXml(type);
            var solicitud = context.HttpContext.Request;
            ConfiguracionBase resultado = null;
            
            if (helper != null)
            {
                byte[] buffer = new byte[(int)solicitud.ContentLength];
                solicitud.Body.Read(buffer, 0, buffer.Length);
                helper.Deserializar(buffer); // no envia el encoding
                resultado = helper.Objeto;
            }

            if (resultado != null)
                return InputFormatterResult.SuccessAsync(resultado);
            else
                return InputFormatterResult.FailureAsync();
        }
    }
}
