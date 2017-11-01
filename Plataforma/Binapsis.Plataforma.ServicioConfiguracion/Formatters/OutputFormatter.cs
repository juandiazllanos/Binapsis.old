using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Xml;
using Binapsis.Plataforma.Serializacion.Impl;

namespace Binapsis.Plataforma.ServicioConfiguracion.Formatters
{
    public class OutputFormatter : TextOutputFormatter
    {        
        public OutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/xml"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);            
        }

        protected override bool CanWriteType(Type type)
        {
            bool resul = typeof(IObjetoDatos).IsAssignableFrom(type) || 
                         typeof(IColeccion).IsAssignableFrom(type);

            if (resul) return resul;

            return EsColeccion(type);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            Type type = context.ObjectType;
            var respuesta = context.HttpContext.Response;
            
            Secuencia secuencia = new Secuencia();
            Serializador helper = new SerializadorObjetoDatos(secuencia, new EscritorXml());
            
            helper.Serializar(context.Object);
                        
            byte[] resultado = secuencia.Contenido;
            
            return respuesta.Body.WriteAsync(resultado, 0, resultado.Length);
        }


        private bool EsColeccion(Type type)
        {
            TypeInfo info = type.GetTypeInfo();
                       

            if (type.GetTypeInfo().IsInterface)
                return info.IsGenericType &&
                       info.GetGenericTypeDefinition() == typeof(IList<>) &&
                       info.GetGenericArguments().Length == 1 &&
                       typeof(IObjetoDatos).IsAssignableFrom(info.GetGenericArguments()[0]); // info.GetGenericArguments()[0].GetTypeInfo().IsSubclassOf(typeof(ConfiguracionBase));
            else
                return typeof(IObjetoDatos).IsAssignableFrom(
                        info.GetInterfaces()
                        .FirstOrDefault(i => i.GetTypeInfo().IsGenericType &&
                                                i.GetTypeInfo().GetGenericTypeDefinition() == typeof(IList<>) &&
                                                i.GetGenericArguments().Length == 1)?
                        .GetGenericArguments()[0]);                    
            //.GetGenericArguments()[0].GetTypeInfo().IsSubclassOf(typeof(ConfiguracionBase)) ?? false;
        }
    }
}
