using Binapsis.Plataforma.AgenteDatos.Http;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.AgenteDatos.Helper
{
    class ObjetoDatosHelper
    {
        string _url;
        string _contexto;

        public ObjetoDatosHelper(string url, string contexto)
        {
            _url = url;
            _contexto = contexto;
        }

        public IObjetoDatos Obtener(IFabrica fabrica, ITipo tipo, object id)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            string data = httpClient.ObtenerObjetoDatos(tipo.Uri, tipo.Nombre, id?.ToString());

            return Obtener(fabrica, tipo, data);
        }

        public IObjetoDatos Obtener(IFabrica fabrica, ITipo tipo, string clave, object valor)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            string data = httpClient.ObtenerObjetoDatos(tipo.Uri, tipo.Nombre, clave, valor?.ToString());

            return Obtener(fabrica, tipo, data);            
        }

        private IObjetoDatos Obtener(IFabrica fabrica, ITipo tipo, string data)
        {
            if (!string.IsNullOrEmpty(data))
                return DeserializadorXmlHelper.DeserializarObjetoDatos(fabrica, tipo, data);
            else
                return null;
        }


        public void Crear(IObjetoDatos od)
        {
            if (od == null) return;

            HttpClientPost httpClient = new HttpClientPost(_url, _contexto);
            byte[] data = SerializadorXmlHelper.Serializar(od);

            httpClient.CrearObjetoDatos(od.Tipo.Uri, od.Tipo.Nombre, data);
        }

        public void Editar(IObjetoDatos od)
        {
            if (od == null) return;

            HttpClientPut httpClient = new HttpClientPut(_url, _contexto);
            byte[] data = SerializadorXmlHelper.Serializar(od);
            
            httpClient.EditarObjetoDatos(od.Tipo.Uri, od.Tipo.Nombre, data);
        }

        public void Eliminar(IObjetoDatos od)
        {
            if (od == null) return;

            HttpClientDelete httpClient = new HttpClientDelete(_url, _contexto);
            byte[] data = SerializadorXmlHelper.Serializar(od);

            httpClient.EliminarObjetoDatos(od.Tipo.Uri, od.Tipo.Nombre, data);
        }

        //private byte[] Serializar(IObjetoDatos od)
        //{
        //    Secuencia secuencia = new Secuencia();
        //    IEscritor escritor = new EscritorXml();

        //    Serializador helper = new SerializadorObjetoDatos(secuencia, escritor);
        //    helper.Serializar(od);

        //    byte[] data = secuencia.Contenido;

        //    return data;
        //}

        //private IObjetoDatos Deserializar(IFabrica fabrica, ITipo tipo, string data)
        //{
        //    Secuencia secuencia = new Secuencia(data);
        //    ILector lector = new LectorXml();
            
        //    Deserializador helper = new DeserializadorObjetoDatos(secuencia, lector, fabrica);
        //    IObjetoDatos od = fabrica.Crear(tipo);

        //    helper.Deserializar(od);
            
        //    return od;
        //}

    }
}
