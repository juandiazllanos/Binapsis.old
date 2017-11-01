namespace Binapsis.Plataforma.AgenteDatos.Http
{
    class HttpClientPost : HttpClientVerb
    {
        #region Constructores
        public HttpClientPost(string url, string contexto) 
            : base(url, contexto)
        {
        }
        #endregion

        public void CrearObjetoDatos(string uri, string tipo, byte[] od)
        {
            Post($"od/{uri}/{tipo}", od);
        }

        public void CrearColeccion(string uri, string tipo, byte[] col)
        {
            Post($"col/od/{uri}/{tipo}", col);
        }

        public void EstablecerDiagramaDatos(string uri, string tipo, byte[] dd)
        {
            Post($"dd/{uri}/{tipo}", dd);
        }

        public void EstablecerDiagramaDatosColeccion(string uri, string tipo, byte[] items)
        {
            Post($"col/dd/{uri}/{tipo}", items);
        }     
    }
}
