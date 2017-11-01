using Binapsis.Plataforma.AgenteDatos;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Comandos
{
    public class Consulta
    {
        string _url;
        string _contexto;
        IFabrica _fabrica;

        Comando _comando;
        ITipo _resultadoTipo;

        Dictionary<string, object> _parametros;

        public Consulta(Contexto contexto, string  comando)
            : this(contexto?.Url, contexto?.Nombre, comando, FabricaDatos.Instancia)
        {
        }

        public Consulta(string url, string contexto, string comando, IFabrica fabrica)
        {
            _url = url;
            _contexto = contexto;
            _fabrica = fabrica;

            _comando = HelperConfig.ObtenerComando(comando);
            _resultadoTipo = new ResultadoTipo(_comando);

            _parametros = new Dictionary<string, object>();
        }
        
        public IColeccion Ejecutar()
        {
            ServicioComando servicio = new ServicioComando(_url, _contexto, _fabrica);
            IColeccion resultado;

            if (_parametros.Count > 0)
                resultado = servicio.EjecutarConsulta(_resultadoTipo, _parametros);
            else
                resultado = servicio.EjecutarConsulta(_resultadoTipo);

            return resultado;
        }

        public void Establecer(string parametro, object valor)
        {
            if (_parametros.ContainsKey(parametro))
                _parametros[parametro] = valor;
            else
                _parametros.Add(parametro, valor);
        }
    }
}
