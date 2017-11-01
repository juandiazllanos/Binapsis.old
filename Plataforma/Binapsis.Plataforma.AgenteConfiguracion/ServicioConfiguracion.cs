using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Serializacion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Xml;

using System;
using System.Collections.Generic;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using EspacioNombre = Binapsis.Plataforma.Configuracion.Uri;
using Binapsis.Plataforma.Configuracion.Caching;

namespace Binapsis.Plataforma.AgenteConfiguracion
{
    public class ServicioConfiguracion
    {
        Fabrica _fabrica;
        CacheConfiguracion _cache;

        public ServicioConfiguracion()
        {

        }

        public ServicioConfiguracion(string url)
            : this(url, Fabrica.Instancia)
        {            
        }

        public ServicioConfiguracion(IFabricaImpl impl)
            : this(null, impl)
        {

        }

        public ServicioConfiguracion(string url, IFabricaImpl impl)
            : this(url, new Fabrica(impl))
        {            
        }

        public ServicioConfiguracion(string url, Fabrica fabrica)
        {
            Url = url;
            _fabrica = fabrica;
            _cache = new CacheConfiguracion();
        }


        public T Obtener<T>(string clave) where T : ConfiguracionBase
        {
            return (T)Obtener(typeof(T), clave);
        }

        public T Obtener<T>(string configuracion, string clave) where T : ConfiguracionBase
        {
            return (T)Obtener(typeof(T), configuracion, clave);
        }

        public IList ObtenerColeccion<T>()
        {
            return ObtenerColeccion(typeof(T));
        }

        public IList ObtenerColeccion<T>(string parametros)
        {
            return ObtenerColeccion(typeof(T), parametros);
        }

        public IList ObtenerColeccion<T>(string configuracion, string parametros) where T : ConfiguracionBase
        {
            return ObtenerColeccion(typeof(T), configuracion, parametros);
        }



        public ConfiguracionBase Obtener(Type type, string clave)
        {
            return Obtener(type, type.Name, clave);
        }

        public ConfiguracionBase Obtener(Type type, string configuracion, string clave)
        {
            // recuperar de cache
            if (_cache.Exists(type, clave))
                return _cache.Get(type, clave);

            // recuperar xml
            string valor = Obtener(configuracion, clave);
            if (valor == null) throw new Exception($"La configuración '{configuracion}:{clave}' no existe");

            if (valor.Length == 0) return null;

            // crear instancia
            ConfiguracionBase instancia = _fabrica.Crear(type);
            // crear secuencia
            Secuencia secuencia = new Secuencia(valor);
            // crear helper
            Deserializador deserializador = new DeserializadorObjetoDatos(secuencia, new LectorXml());
            // deserializar
            deserializador.Fabrica = _fabrica;
            deserializador.Deserializar(instancia);

            // agregar en cache
            _cache.Set(instancia);

            return instancia;
        }

        public IList ObtenerColeccion(Type type)
        {
            return ObtenerColeccion(type, null as string);
        }
        
        public IList ObtenerColeccion(Type type, string filtro)
        {
            return ObtenerColeccion(type, type.Name, filtro);
        }

        public IList ObtenerColeccion(Type type, string configuracion, string parametros)
        {
            IList items = new List<IObjetoDatos>();
            Recuperar(type, items, configuracion, parametros);
            return items;
        }
                
        public void Recuperar(Type type, IList items, string configuracion, string parametros)
        {
            // recuperar xml
            string valor = ObtenerColeccion(configuracion, parametros);
            if (valor == null) throw new Exception($"La configuración '{configuracion}:{parametros}' no existe");

            IDeserializador deserializador = null;
            
            // crear helper
            deserializador = new DeserializacionColeccionXml(type, items);
            
            // deserializar
            deserializador.Deserializar(valor);
        }

        internal IColeccion EjecutarConsulta(ComandoHelper consulta)
        {
            Coleccion coleccion = new Coleccion();
            StringBuilder builder = new StringBuilder();

            object valor = null;

            foreach (Parametro parametro in consulta.Comando.Parametros)
            {
                valor = consulta.Obtener(parametro.Nombre);
                if (valor == null) continue;

                if (builder.Length > 0) builder.Append("&");
                builder.Append($"{parametro.Nombre}={valor}");
            }

            string resultado = ObtenerColeccion($"consulta/{consulta.Comando.Nombre}", builder.ToString());
            if (string.IsNullOrEmpty(resultado)) return coleccion;

            Secuencia secuencia = new Secuencia(resultado);
            ITipo tipo = new ResultadoTipo(consulta.Comando);
            Deserializador helper = new DeserializadorObjetoDatos(secuencia, new LectorXml());
            helper.Deserializar(tipo, coleccion);

            return coleccion;
        }
        
        public Ensamblado ObtenerEnsamblado(string nombre)
        {
            return Obtener<Ensamblado>(nombre);
        }
        
        public EspacioNombre ObtenerUri(string nombre)
        {
            return Obtener<EspacioNombre>(nombre);
        }
        
        public Tipo ObtenerTipo(string uri, string nombre)
        {
            return Obtener<Tipo>($"{uri}.{nombre}");
        }

        public Tabla ObtenerTabla(string nombre)
        {
            return Obtener<Tabla>(nombre);
        }
        
        public IList ObtenerTablas()
        {
            return ObtenerColeccion<Tabla>();
        }

        public IList ObtenerTablas(string uri, string tipo)
        {
            Filtro filtro = new Filtro();

            //filtro.Agregar(nameof(uri), uri);
            filtro.Agregar("tipo", $"{uri}.{tipo}");

            return ObtenerColeccion<Tabla>(filtro.ToString());
        }


        public Relacion ObtenerRelacion(string nombre)
        {
            return Obtener<Relacion>(nombre);
        }

        public IList ObtenerRelaciones()
        {
            return ObtenerColeccion<Relacion>();
        }

        public IList ObtenerRelacionesPorUri(string uri)
        {
            if (string.IsNullOrEmpty(uri)) return null;

            Filtro filtro = new Filtro();
            filtro.Agregar("uri", uri);            

            return ObtenerColeccion<Relacion>(filtro.ToString());
        }

        public IList ObtenerRelacionesPorTipo(string uri, string tipo)
        {
            if (string.IsNullOrEmpty(uri) || string.IsNullOrEmpty(tipo)) return null;

            Filtro filtro = new Filtro();
            filtro.Agregar("uri", uri);
            filtro.Agregar("tipo", tipo);

            return ObtenerColeccion<Relacion>(filtro.ToString());
        }

        public IList ObtenerRelacionesPorPropiedad(string uri, string tipo, string propiedad)
        {
            if (string.IsNullOrEmpty(uri) || string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(propiedad)) return null;

            Filtro filtro = new Filtro();
            filtro.Agregar("uri", uri);
            filtro.Agregar("tipo", tipo);
            filtro.Agregar("propiedad", propiedad);

            return ObtenerColeccion<Relacion>(filtro.ToString());
        }

        public IList ObtenerRelacionesPorTabla(string tablaPrincipal, string tablaSecundaria)
        {
            if (string.IsNullOrEmpty(tablaPrincipal) && string.IsNullOrEmpty(tablaSecundaria)) return null;

            Filtro filtro = new Filtro();
            filtro.Agregar("tablaPrincipal", tablaPrincipal);
            filtro.Agregar("tablaSecundaria", tablaSecundaria);

            return ObtenerColeccion<Relacion>(filtro.ToString());            
        }
        
        private string Obtener(string configuracion, string clave)
        {
            if (string.IsNullOrEmpty(Url)) throw new Exception("Url no es válida.");
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

        private string ObtenerColeccion(string configuracion, string parametros)
        {
            return ObtenerColeccion(Url, configuracion, parametros);
        }

        private string ObtenerColeccion(string url, string configuracion, string parametros)
        {
            string body = null;
            string ruta = null;

            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new System.Uri(url);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                if (!string.IsNullOrEmpty(parametros))
                    ruta = $"{url}/{configuracion}?{parametros}";
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
