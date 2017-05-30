using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Threading.Tasks;
using System.Text;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Serializacion;
using Microsoft.Net.Http.Headers;
using System.Reflection;

namespace Binapsis.Plataforma.ServicioConfiguracion.Formatters
{
    public class XmlOutputFormatter : TextOutputFormatter
    {        
        public XmlOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/xml"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);            
        }

        protected override bool CanWriteType(Type type)
        {
            return type.GetTypeInfo().IsSubclassOf(typeof(ConfiguracionBase));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            Type type = context.ObjectType;
            var respuesta = context.HttpContext.Response;
            ConfiguracionBase obj = (ConfiguracionBase)context.Object;

            ISerializador helper = new SerializacionXml(obj);
            byte[] resultado = null;
            
            if (helper != null)
            {
                helper.Serializar();
                resultado = helper.Contenido;
            }

            return respuesta.Body.WriteAsync(resultado, 0, resultado.Length);
        }
    }
}
