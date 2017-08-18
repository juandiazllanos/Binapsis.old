using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class Repositorio
    {
        ServicioConfiguracion _servicio;

        #region Constructores
        public Repositorio(ServicioConfiguracion servicio)
        {
            _servicio = servicio;
        }
        #endregion 


        #region Metodos
        public void Crear(ConfiguracionBase valor)
        {
            _servicio.Establecer(valor);
        }

        public void Editar(ConfiguracionBase valor, string clave)
        {
            _servicio.Establecer(valor, clave);
        }

        public void Eliminar(Type type, string clave)
        {
            _servicio.Eliminar(type, clave);
        }

        public T Obtener<T>(string clave) where T : ConfiguracionBase
        {
            return Obtener(typeof(T), clave) as T;
        }

        public ConfiguracionBase Obtener(Type type, string clave)
        {
            return _servicio.Obtener(type, clave);
        }

        //public Comando ObtenerComando(string nombre)
        //{

        //}

        public ComandoHelper CrearComando(string nombre)
        {
            Comando comando = _servicio.Obtener<Comando>("consulta/definicion", nombre);
            if (comando != null) 
                return new ComandoHelper(_servicio, comando);                        
            else
                return null;
        }

        //public IColeccion Consultar(string consulta, string parametro, object valor)
        //{
        //    return null;
        //}
        #endregion

    }
}
