using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Xml;
using Binapsis.Plataforma.Serializacion.Impl;

namespace Binapsis.Plataforma.ServicioConfiguracion.Formatters
{
    public class InputFormatter : TextInputFormatter
    {
        public InputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue .Parse("application/xml"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);            
        }

        protected override bool CanReadType(Type type)
        {
            return type.GetTypeInfo().IsSubclassOf(typeof(ConfiguracionBase)); //typeof(IObjetoDatos).IsAssignableFrom(type); 
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            if (context.HttpContext.Request.ContentLength == 0) return InputFormatterResult.FailureAsync();

            var solicitud = context.HttpContext.Request;
            byte[] buffer = new byte[(int)solicitud.ContentLength];
            solicitud.Body.Read(buffer, 0, buffer.Length);

            Secuencia secuencia = new Secuencia(buffer);
            DeserializadorObjetoDatos helper = new DeserializadorObjetoDatos(secuencia, new LectorXml());

            Type type = context.ModelType;
            ITipo tipo = Types.Instancia.Obtener(type);
            IObjetoDatos resultado = Fabrica.Instancia.Crear(tipo);

            helper.Fabrica = Fabrica.Instancia;
            helper.Deserializar(resultado); // no envia el encoding
            
            return InputFormatterResult.SuccessAsync(resultado);
            
        }
    }
}
