using Binapsis.Plataforma.AgenteDatos.Http;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.AgenteDatos.Helper
{
    class ColeccionHelper
    {
        string _url;
        string _contexto;

        public ColeccionHelper(string url, string contexto)
        {
            _url = url;
            _contexto = contexto;
        }

        public IColeccion Obtener(IFabrica fabrica, ITipo tipo)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            string data = httpClient.ObtenerColeccion(tipo.Uri, tipo.Nombre);

            return Obtener(fabrica, tipo, data);
        }

        public IColeccion Obtener(IFabrica fabrica, ITipo tipo, string clave, object valor)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            string data = httpClient.ObtenerColeccion(tipo.Uri, tipo.Nombre, clave, valor?.ToString());

            return Obtener(fabrica, tipo, data);
        }

        public IColeccion Obtener(IFabrica fabrica, ITipo tipo, IDictionary<string, object> parametros)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            HttpClientParametros httpParametros = new HttpClientParametros(parametros);
            string data = httpClient.ObtenerColeccion(tipo.Uri, tipo.Nombre, httpParametros.ToString());

            return Obtener(fabrica, tipo, data);
        }

        private IColeccion Obtener(IFabrica fabrica, ITipo tipo, string data)
        {
            if (!string.IsNullOrEmpty(data))
                return DeserializadorXmlHelper.DeserializarColeccion(fabrica, tipo, data);
            else
                return null;
        }

        public void Crear(IColeccion coleccion)
        {
            if (coleccion == null || coleccion.Longitud == 0) return;

            HttpClientPost httpClient = new HttpClientPost(_url, _contexto);
            byte[] data = SerializadorXmlHelper.Serializar(coleccion);
            ITipo tipo = coleccion[0].Tipo;

            httpClient.CrearColeccion(tipo.Uri, tipo.Nombre, data);
        }

        public void Editar(IColeccion coleccion)
        {
            if (coleccion == null || coleccion.Longitud == 0) return;

            HttpClientPut httpClient = new HttpClientPut(_url, _contexto);
            byte[] data = SerializadorXmlHelper.Serializar(coleccion);
            ITipo tipo = coleccion[0].Tipo;

            httpClient.EditarColeccion(tipo.Uri, tipo.Nombre, data);
        }

        public void Eliminar(IColeccion coleccion)
        {
            if (coleccion == null || coleccion.Longitud == 0) return;

            HttpClientDelete httpClient = new HttpClientDelete(_url, _contexto);
            byte[] data = SerializadorXmlHelper.Serializar(coleccion);
            ITipo tipo = coleccion[0].Tipo;

            httpClient.EliminarColeccion(tipo.Uri, tipo.Nombre, data);
        }        

        //private byte[] Serializar(IColeccion col)
        //{
        //    Secuencia secuencia = new Secuencia();
        //    IEscritor escritor = new EscritorXml();
        //    Serializador serializador = new SerializadorObjetoDatos(secuencia, escritor);
        //    serializador.Serializar(col);

        //    return secuencia.Contenido;
        //}

        //private IColeccion Deserializar(IFabrica fabrica, ITipo tipo, string data)
        //{
        //    ISecuencia secuencia = new Secuencia(data);
        //    ILector lector = new LectorXml();
        //    Deserializador helper = new DeserializadorObjetoDatos(secuencia, lector, fabrica);
        //    Coleccion coleccion = new Coleccion();

        //    helper.Deserializar(tipo, coleccion);

        //    return coleccion;
        //}
    }
}
