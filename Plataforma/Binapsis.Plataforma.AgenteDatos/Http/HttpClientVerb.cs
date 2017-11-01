using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Binapsis.Plataforma.AgenteDatos.Http
{
    class HttpClientVerb
    {
        string _url;
        string _contexto;
        string _formato;


        #region Constructores
        public HttpClientVerb(string url, string contexto)
            : this(url, contexto, "application/xml")
        {
        }

        public HttpClientVerb(string url, string contexto, string formato)
        {
            _url = url;
            _contexto = contexto;
            _formato = formato;
        }
        #endregion

        #region Metodos
        protected string Get(string uri)
        {
            string resultado = null;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri(_url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_formato));

                HttpResponseMessage response = httpClient.GetAsync($"{_url}/{_contexto}/{uri}").Result;

                if (response.IsSuccessStatusCode)
                    resultado = response.Content.ReadAsStringAsync().Result;
            }

            return resultado;
        }

        protected void Post(string uri, byte[] data)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri(_url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_formato));
                
                string content = Encoding.UTF8.GetString(data);

                HttpContent body = new StringContent(content, Encoding.UTF8, _formato); 
                HttpResponseMessage response = null;
                
                response = httpClient.PostAsync($"{_url}/{_contexto}/{uri}", body).Result;                
            }
        }

        protected void Put(string uri, byte[] data)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri(_url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_formato));

                string content = Encoding.UTF8.GetString(data);

                HttpContent body = new StringContent(content, Encoding.UTF8, _formato);
                HttpResponseMessage response = null;

                response = httpClient.PutAsync($"{_url}/{_contexto}/{uri}", body).Result;
            }
        }

        protected void Delete(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri(_url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_formato));

                HttpResponseMessage response = httpClient.DeleteAsync($"{_url}/{_contexto}/{uri}").Result;
            }
        }

        protected void Delete(string uri, byte[] data)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri(_url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_formato));

                string content = Encoding.UTF8.GetString(data);
                
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"{_url}/{_contexto}/{uri}");
                httpRequest.Content = new StringContent(content, Encoding.UTF8, _formato); 

                HttpResponseMessage response = httpClient.SendAsync(httpRequest).Result; 
            }
        }
        #endregion



    }
}
