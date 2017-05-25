using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Threading.Tasks;
using System.Text;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Serializacion;
using Binapsis.Plataforma.Estructura.Impl;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using System.Collections.Generic;

namespace Binapsis.Plataforma.ServicioConfiguracion.Formatters
{
    public class XmlOutputFormatter : TextOutputFormatter
    {
        Dictionary<Type, Func<ObjetoBase, ISerializador>> _helper;

        public XmlOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/xml"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

            _helper = new Dictionary<Type, Func<ObjetoBase, ISerializador>>();

            _helper.Add(typeof(Ensamblado), obj => new SerializacionXml<Ensamblado>((Ensamblado)obj));
            _helper.Add(typeof(Configuracion.Uri), obj => new SerializacionXml<Configuracion.Uri>((Configuracion.Uri)obj));
            _helper.Add(typeof(Configuracion.Tipo), obj => new SerializacionXml<Configuracion.Tipo>((Configuracion.Tipo)obj));
            _helper.Add(typeof(Definicion), obj => new SerializacionXml<Definicion>((Definicion)obj));
        }

        protected override bool CanWriteType(Type type)
        {
            return _helper.ContainsKey(type);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            Type type = context.ObjectType;
            var respuesta = context.HttpContext.Response;
            ObjetoBase obj = (ObjetoBase)context.Object;

            ISerializador helper = null;
            byte[] resultado = null;

            if (_helper.ContainsKey(type))
                helper = _helper[type].Invoke(obj);

            if (helper != null)
            {
                helper.Serializar();
                resultado = helper.Contenido;
            }

            return respuesta.Body.WriteAsync(resultado, 0, resultado.Length);
        }
    }
}
