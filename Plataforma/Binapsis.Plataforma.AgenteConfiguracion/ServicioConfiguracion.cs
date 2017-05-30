using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Serializacion;
using Binapsis.Plataforma.Estructura;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System;
using EspacioNombre = Binapsis.Plataforma.Configuracion.Uri;

namespace Binapsis.Plataforma.AgenteConfiguracion
{
    public class ServicioConfiguracion
    {
        Fabrica _fabrica;

        public ServicioConfiguracion()
        {
            _fabrica = Fabrica.Instancia;
        }

        public ServicioConfiguracion(string url)
            : this()
        {
            Url = url;
        }

        public ServicioConfiguracion(IFabricaImpl impl)
        {
            _fabrica = new Fabrica(impl);
        }

        public ServicioConfiguracion(string url, IFabricaImpl impl)
            : this(impl)
        {
            Url = url;
        }


        public T Obtener<T>(string clave) where T : ConfiguracionBase
        {
            return (T)Obtener(typeof(T), clave);
        }

        public T Obtener<T>(string configuracion, string clave) where T : ConfiguracionBase
        {
            return (T)Obtener(typeof(T), configuracion, clave);            
        }
                
        public ConfiguracionBase Obtener(System.Type type, string clave)
        {
            return Obtener(type, type.Name, clave);
        }

        public ConfiguracionBase Obtener(System.Type type, string configuracion, string clave)
        {
            ConfiguracionBase instancia = null;
            
            // crear instancia
            instancia = _fabrica.Crear(type);
            
            // recuperar
            Recuperar(instancia, configuracion, clave);

            return instancia;
        }
                
        public void Recuperar(ConfiguracionBase instancia, string clave)
        {
            Recuperar(instancia, instancia.Tipo.Nombre, clave);
        }

        public void Recuperar(ConfiguracionBase instancia, string configuracion, string clave)
        {
            // recuperar xml
            string valor = Obtener(configuracion, clave);
            if (valor == null) throw new System.Exception($"La configuración '{configuracion}:{clave}' no existe");
                       
            IDeserializador deserializador = null;
                        
            // crear helper
            deserializador = new DeserializacionXml(instancia);
            // deserializar
            deserializador.Deserializar(valor);
        }

        public Definicion ObtenerDefinicion()
        {
            return Obtener<Definicion>("Definicion", null);
        }

        public Definicion ObtenerDefinicion(string ruta)
        {
            return Obtener<Definicion>("Definicion", ruta);
        }

        public Definicion ObtenerDefinicion(string configuracion, string clave)
        {
            return ObtenerDefinicion($"{configuracion}/{clave}");
        }

        public Ensamblado ObtenerEnsamblado(string nombre)
        {
            return Obtener<Ensamblado>("Ensamblado", nombre);
        }
        
        public EspacioNombre ObtenerUri(string nombre)
        {
            return Obtener<EspacioNombre>("Uri", nombre);
        }
        
        public Tipo ObtenerTipo(string uri, string nombre)
        {
            return Obtener<Tipo>("Tipo", $"{uri}.{nombre}");
        }

        private string Obtener(string configuracion, string clave)
        {
            if (string.IsNullOrEmpty(Url)) throw new System.Exception("Url no es válida.");
            return Obtener(Url, configuracion, clave);
        }

        private string Obtener(string url, string configuracion, string clave)
        {            
            string body = null;
            string ruta = null;

            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new System.Uri(url);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                if (!string.IsNullOrEmpty(clave))
                    ruta = $"{url}/{configuracion}/{clave}";
                else
                    ruta = $"{url}/{configuracion}";

                HttpResponseMessage response = cliente.GetAsync(ruta).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    body = response.Content.ReadAsStringAsync().Result;
                }
            }                

            return body;
        }

        public void Establecer(ConfiguracionBase valor)
        {
            Establecer(valor.Tipo.Nombre, clave: null, valor: valor);
        }
        
        public void Establecer(ConfiguracionBase valor, string clave)
        {
            Establecer(valor.Tipo.Nombre, clave, valor);
        }

        public void Establecer(string configuracion, string clave, ConfiguracionBase valor)
        {
            if (valor == null) return;

            ISerializador serializador = new SerializacionXml(valor);
            serializador.Serializar();
            byte[] contenido = serializador.Contenido;

            if (contenido == null) return;
            string data = Encoding.UTF8.GetString(contenido);

            Establecer(configuracion, clave, data);
        }
        
        public void Establecer(string configuracion, string clave, string valor)
        {
            if (string.IsNullOrEmpty(Url)) throw new Exception("Url no es válida.");
            Establecer(Url, configuracion, clave, valor);
        }
        
        private void Establecer(string url, string configuracion, string clave, string valor)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new System.Uri(url);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                HttpContent body = new StringContent(valor, Encoding.UTF8, "application/xml");
                HttpResponseMessage response = null;

                if (string.IsNullOrEmpty(clave))
                    response = cliente.PostAsync($"{url}/{configuracion}", body).Result;
                else
                    response = cliente.PutAsync($"{url}/{configuracion}/{clave}", body).Result;
            }
        }

        public void Eliminar(Type type, string clave)
        {
            Eliminar(type.Name, clave);
        }

        private void Eliminar(string configuracion, string clave)
        {
            Eliminar(Url, configuracion, clave);
        }

        public void Eliminar(string url, string configuracion, string clave)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new System.Uri(url);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                                
                HttpResponseMessage response = cliente.DeleteAsync($"{url}/{configuracion}/{clave}").Result;
            }
        }
        
        public string Url
        {
            get;
            set;
        }
    }
}
