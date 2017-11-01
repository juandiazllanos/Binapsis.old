using Binapsis.Plataforma.AgenteDatos.Http;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.AgenteDatos.Helper
{
    class DiagramaDatosHelper
    {
        string _url;
        string _contexto;

        public DiagramaDatosHelper(string url, string contexto)
        {
            _url = url;
            _contexto = contexto;
        }

        public void Establecer(IDiagramaDatos dd)
        {
            if (dd == null) return;
            
            byte[] data = SerializadorXmlHelper.Serializar(dd);
            
            HttpClientPost httpClient = new HttpClientPost(_url, _contexto);
            httpClient.EstablecerDiagramaDatos(dd.Tipo.Uri, dd.Tipo.Nombre, data);
        }

        public void Establecer(IList<IDiagramaDatos> items)
        {
            if (items == null || items.Count == 0) return;

            byte[] data = SerializadorXmlHelper.Serializar(items);
            ITipo tipo = items[0].Tipo;

            HttpClientPost httpClient = new HttpClientPost(_url, _contexto);
            httpClient.EstablecerDiagramaDatos(tipo.Uri, tipo.Nombre, data);
        }

        //private byte[] Serializar(object obj)
        //{
        //    Secuencia secuencia = new Secuencia();
        //    IEscritor escritor = new EscritorXml();
        //    Serializador helper = new SerializadorDiagramaDatos(secuencia, escritor);

        //    helper.Serializar(obj);

        //    return secuencia.Contenido;
        //}
    }
}
