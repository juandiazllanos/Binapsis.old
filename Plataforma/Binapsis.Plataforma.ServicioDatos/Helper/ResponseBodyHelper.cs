using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Impl;
using Binapsis.Plataforma.Serializacion.Xml;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    public class ResponseBodyHelper
    {
        HttpContext _httpContext;

        public ResponseBodyHelper(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        
        public Task Resolver(Type type, object obj)
        {
            if (type == typeof(ObjetoDatos) || type == typeof(Coleccion))
                return ResolverObjetoDatos(obj);
            else if (type == typeof(DiagramaDatos) || type == typeof(IList<DiagramaDatos>))
                return ResolverDiagramaDatos(obj);
            else
                return Task.CompletedTask;
        }

        private Task ResolverObjetoDatos(object obj)
        {
            var respuesta = _httpContext.Response;

            Secuencia secuencia = new Secuencia();
            IEscritor escritor = new EscritorXml();
            Serializador helper = new SerializadorObjetoDatos(secuencia, escritor);

            helper.Serializar(obj);

            byte[] resultado = secuencia.Contenido;

            return respuesta.Body.WriteAsync(resultado, 0, resultado.Length);
        }

        private Task ResolverDiagramaDatos(object obj)
        {
            var respuesta = _httpContext.Response;

            Secuencia secuencia = new Secuencia();
            IEscritor escritor = new EscritorXml();
            Serializador helper = new SerializadorDiagramaDatos(secuencia, escritor);

            helper.Serializar(obj);

            byte[] resultado = secuencia.Contenido;

            return respuesta.Body.WriteAsync(resultado, 0, resultado.Length);
        }

    }
}
