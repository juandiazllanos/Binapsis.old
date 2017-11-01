using Binapsis.Plataforma.AgenteDatos.Http;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.AgenteDatos.Helper
{
    class ComandoHelper
    {
        string _url;
        string _contexto;

        public ComandoHelper(string url, string contexto)
        {
            _url = url;
            _contexto = contexto;
        }

        public IColeccion EjecutarConsulta(IFabrica fabrica, ITipo consulta)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            string data = httpClient.ObtenerColeccionConsulta(consulta.Nombre);

            if (!string.IsNullOrEmpty(data))
                return DeserializadorXmlHelper.DeserializarColeccion(fabrica, consulta, data);
            else
                return null;
        }

        public IColeccion EjecutarConsulta(IFabrica fabrica, ITipo consulta, IDictionary<string, object> parametros)
        {
            HttpClientGet httpClient = null;
            HttpClientParametros httpParametros = new HttpClientParametros(parametros);
            string httpParametroString = httpParametros.ToString();
            
            // validar parametro
            if (string.IsNullOrEmpty(httpParametroString))
                return EjecutarConsulta(fabrica, consulta);

            // ejecutar consulta
            httpClient = new HttpClientGet(_url, _contexto);
            string data = httpClient.ObtenerColeccionConsulta(consulta.Nombre, httpParametros.ToString());
            
            // deserializar resultado
            if (!string.IsNullOrEmpty(data))
                return DeserializadorXmlHelper.DeserializarColeccion(fabrica, consulta, data);
            else
                return null;
        }

        public IObjetoDatos EjecutarComando(IFabrica fabrica, ITipo comando)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            string data = httpClient.ObtenerObjetoDatosComando(comando.Nombre);

            if (!string.IsNullOrEmpty(data))
                return DeserializadorXmlHelper.DeserializarObjetoDatos(fabrica, comando, data);
            else
                return null;
        }

        public IObjetoDatos EjecutarComando(IFabrica fabrica, ITipo comando, IDictionary<string, object> parametros)
        {
            HttpClientGet httpClient = null;
            HttpClientParametros httpParametro = new HttpClientParametros(parametros);

            string httpParametroString = httpParametro.ToString();
            string data = null;

            // validar parametros
            if (string.IsNullOrEmpty(httpParametroString))
                return EjecutarComando(fabrica, comando);
            
            // ejecutar comando
            httpClient = new HttpClientGet(_url, _contexto);
            data = httpClient.ObtenerObjetoDatosComando(comando.Nombre);

            // deserializar resultado
            if (!string.IsNullOrEmpty(data))
                return DeserializadorXmlHelper.DeserializarObjetoDatos(fabrica, comando, data);
            else
                return null;
        }

        public void EjecutarComando(string comando)
        {
            HttpClientGet httpClient = new HttpClientGet(_url, _contexto);
            httpClient.ObtenerObjetoDatosComando(comando);
        }

        public void EjecutarComando(string comando, IDictionary<string, object> parametros)
        {
            HttpClientGet httpClient = null;
            HttpClientParametros httpParametro = new HttpClientParametros(parametros);
            string httpParametroString = httpParametro.ToString();

            if (!string.IsNullOrEmpty(httpParametroString))
            {
                httpClient = new HttpClientGet(_url, _contexto);
                httpClient.ObtenerObjetoDatosComando(comando, httpParametroString);
            }
            else
                EjecutarComando(comando);
        }
        
    }
}
