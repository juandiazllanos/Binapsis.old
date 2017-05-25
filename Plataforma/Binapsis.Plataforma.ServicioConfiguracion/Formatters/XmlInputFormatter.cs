using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Threading.Tasks;
using System.Text;
using Binapsis.Plataforma.Configuracion.Serializacion;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura.Impl;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;

namespace Binapsis.Plataforma.ServicioConfiguracion.Formatters
{
    public class XmlInputFormatter : TextInputFormatter
    {
        Dictionary<Type, Func<IDeserializador>> _helper;

        public XmlInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue .Parse("application/xml"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

            _helper = new Dictionary<Type, Func<IDeserializador>>();

            _helper.Add(typeof(Ensamblado), () => new DeserializacionXml<Ensamblado>());
            _helper.Add(typeof(Configuracion.Uri), () => new DeserializacionXml<Configuracion.Uri>());
            _helper.Add(typeof(Tipo), () => new DeserializacionXml<Tipo>());
            _helper.Add(typeof(Definicion), () => new DeserializacionXml<Definicion>());
        }

        protected override bool CanReadType(Type type)
        {
            return _helper.ContainsKey(type);
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            Type type = context.ModelType;
            IDeserializador helper = null;
            var solicitud = context.HttpContext.Request;
            ObjetoBase resultado = null;

            if (_helper.ContainsKey(type))
                helper = _helper[type]?.Invoke();

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
