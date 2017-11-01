namespace Binapsis.Plataforma.AgenteDatos.Http
{
    class HttpClientPut : HttpClientVerb
    {
        public HttpClientPut(string url, string contexto) 
            : base(url, contexto)
        {
        }

        public void EditarObjetoDatos(string uri, string tipo, byte[] od)
        {
            Put($"od/{uri}/{tipo}", od);
        }

        public void EditarColeccion(string uri, string tipo, byte[] col)
        {
            Put($"col/od/{uri}/{tipo}", col);
        }        
    }
}
