namespace Binapsis.Plataforma.AgenteDatos.Http
{
    class HttpClientDelete : HttpClientVerb
    {
        public HttpClientDelete(string url, string contexto) 
            : base(url, contexto)
        {
        }

        public void EliminarObjetoDatos(string uri, string tipo, byte[] od)
        {
            Delete($"od/{uri}/{tipo}", od);
        }

        public void EliminarColeccion(string uri, string tipo, byte[] col)
        {
            Delete($"col/od/{uri}/{tipo}", col);
        }
    }
}
