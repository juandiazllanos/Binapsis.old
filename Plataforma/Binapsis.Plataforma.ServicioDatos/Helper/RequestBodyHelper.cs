using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Impl;
using Binapsis.Plataforma.Serializacion.Xml;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    public class RequestBodyHelper
    {
        FabricaDatos _fabrica = FabricaDatos.Instancia;

        static  RequestBodyHelper()
        {
            Instancia = new RequestBodyHelper();
        }        

        private ISecuencia CrearSecuencia(HttpRequest httpRequest)
        {
            if (httpRequest.ContentLength == 0) return null;
            
            byte[] buffer = new byte[(int)httpRequest.ContentLength];
            httpRequest.Body.Read(buffer, 0, buffer.Length);

            return new Secuencia(buffer);
        }

        private ILector CrearLector()
        {
            return new LectorXml();
        }

        public ObjetoDatos ResolverObjetoDatos(HttpContext httpContext, ITipo tipo)
        {
            ISecuencia secuencia = CrearSecuencia(httpContext.Request);
            ILector lector = CrearLector();

            if (secuencia == null) return null;
            
            Deserializador helper = new DeserializadorObjetoDatos(secuencia, lector, _fabrica);                        
            ObjetoDatos resultado = _fabrica.Crear(tipo);            

            helper.Deserializar(resultado);

            return resultado;
        }

        public Coleccion ResolverObjetoDatosColeccion(HttpContext httpContext, ITipo tipo)
        {
            ISecuencia secuencia = CrearSecuencia(httpContext.Request);
            ILector lector = CrearLector();

            if (secuencia == null) return null;

            Deserializador helper = new DeserializadorObjetoDatos(secuencia, lector, _fabrica);
            Coleccion resultado = new Coleccion();

            helper.Deserializar(tipo, resultado);

            return resultado;
        }

        public DiagramaDatos ResolverDiagramaDatos(HttpContext httpContext, ITipo tipo)
        {
            ISecuencia secuencia = CrearSecuencia(httpContext.Request);
            ILector lector = CrearLector();

            if (secuencia == null) return null;

            Deserializador helper = new DeserializadorDiagramaDatos(secuencia, lector, _fabrica);
            DiagramaDatos resultado = new DiagramaDatos(tipo);

            helper.Deserializar(resultado);

            return resultado;
        }

        public IList<DiagramaDatos> ResolverDiagramaDatosColeccion(HttpContext httpContext, ITipo tipo)
        {
            ISecuencia secuencia = CrearSecuencia(httpContext.Request);
            ILector lector = CrearLector();
            if (secuencia == null) return null;

            Deserializador helper = new DeserializadorDiagramaDatos(secuencia, lector, _fabrica);
            List<DiagramaDatos> resultado = new List<DiagramaDatos>();

            helper.Deserializar(tipo, resultado);

            return resultado;            
        }

        public static RequestBodyHelper Instancia
        {
            get;
        }

    }
}
