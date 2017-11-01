namespace Binapsis.Plataforma.AgenteDatos.Http
{
    class HttpClientGet : HttpClientVerb
    {        
        #region Constructores
        public HttpClientGet(string url, string contexto)
            : base(url, contexto)
        {
        }
        #endregion


        #region Metodos
        public string ObtenerObjetoDatos(string uri, string tipo, string id)
        {
            return Get($"od/{uri}/{tipo}/{id}");
        }

        public string ObtenerObjetoDatos(string uri, string tipo, string clave, string valor)
        {
            return Get($"od/{uri}/{tipo}/{clave}/{valor}");
        }

        public string ObtenerObjetoDatosComando(string comando)
        {
            return Get($"cmd/{comando}");
        }

        public string ObtenerObjetoDatosComando(string comando, string parametros)
        {
            return Get($"cmd/{comando}?{parametros}");
        }

        public string ObtenerColeccion(string uri, string tipo)
        {
            return Get($"col/od/{uri}/{tipo}");
        }

        public string ObtenerColeccion(string uri, string tipo, string clave, string valor)
        {
            return Get($"col/od/{uri}/{tipo}/{clave}/{valor}");
        }
        
        public string ObtenerColeccion(string uri, string tipo, string parametros)
        {
            return Get($"col/od/{uri}/{tipo}?{parametros}");
        }

        public string ObtenerColeccionConsulta(string consulta)
        {
            return Get($"qry/{consulta}");
        }

        public string ObtenerColeccionConsulta(string consulta, string parametros)
        {
            return Get($"qry/{consulta}?parametros");
        }

        public string ObtenerKey(string uri, string tipo, string clave)
        {
            return Get($"key/{uri}/{tipo}/{clave}");
        }

        public string ObtenerKey(string uri, string tipo, string clave, int cobertura)
        {
            return Get($"key/{uri}/{tipo}/{clave}?{cobertura}");
        }
        #endregion

    }
}
