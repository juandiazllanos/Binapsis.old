using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Threading.Tasks;
using System.Text;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Serializacion;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

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
            bool resul = type.GetTypeInfo().IsSubclassOf(typeof(ConfiguracionBase));
            if (resul) return resul;

            return EsColeccion(type);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            Type type = context.ObjectType;
            var respuesta = context.HttpContext.Response;
            ISerializador helper;

            if (!EsColeccion(type))
                helper = new SerializacionXml(context.Object as ConfiguracionBase);
            else
                helper = new SerializacionColeccionXml(context.Object as IList); //?.Cast<ConfiguracionBase>().ToList());
                        
            byte[] resultado = null;
            
            if (helper != null)
            {
                helper.Serializar();
                resultado = helper.Contenido;
            }

            return respuesta.Body.WriteAsync(resultado, 0, resultado.Length);
        }


        private bool EsColeccion(Type type)
        {
            TypeInfo info = type.GetTypeInfo();

            if (type.GetTypeInfo().IsInterface)
                return info.IsGenericType && 
                       info.GetGenericTypeDefinition() == typeof(IList<>) &&
                       info.GetGenericArguments().Length == 1 && 
                       info.GetGenericArguments()[0].GetTypeInfo().IsSubclassOf(typeof(ConfiguracionBase));
            else
                return info.GetInterfaces()
                    .FirstOrDefault(i => i.GetTypeInfo().IsGenericType &&
                                         i.GetTypeInfo().GetGenericTypeDefinition() == typeof(IList<>) &&
                                         i.GetGenericArguments().Length == 1)?
                    .GetGenericArguments()[0].GetTypeInfo().IsSubclassOf(typeof(ConfiguracionBase)) ?? false;
        }
    }
}
