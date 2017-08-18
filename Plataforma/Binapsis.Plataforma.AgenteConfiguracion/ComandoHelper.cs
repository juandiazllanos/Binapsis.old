using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.AgenteConfiguracion
{
    public class ComandoHelper
    {
        Dictionary<string, object> _parametros;

        public ComandoHelper(ServicioConfiguracion servicio, Comando comando)
        {
            Servicio = servicio;
            Comando = comando;

            ConstruirParametros();
        }

        private void ConstruirParametros()
        {
            _parametros = new Dictionary<string, object>();

            foreach (Parametro parametro in Comando.Parametros)
                _parametros.Add(parametro.Nombre, null);
        }

        public IColeccion EjecutarConsulta()
        {
            return Servicio.EjecutarConsulta(this);
        }
        
        public void Establecer(string nombre, object valor)
        {
            if (_parametros.ContainsKey(nombre))
                _parametros[nombre] = valor;
        }

        public void Establecer(int indice, object valor)
        {
            if (indice >= 0 && indice < _parametros.Count)
                _parametros[_parametros.Keys.ElementAt(indice)] = valor;
        }

        public object Obtener(string nombre)
        {
            if (_parametros.ContainsKey(nombre))
                return _parametros[nombre];
            else
                return null;
        }

        public object Obtener(int indice)
        {
            if (indice >= 0 && indice < _parametros.Count)
                return _parametros.Values.ElementAt(indice);
            else
                return null;
        }
        
        public Comando Comando
        {
            get;
        }

        private ServicioConfiguracion Servicio
        {
            get;
        }

    }
}
