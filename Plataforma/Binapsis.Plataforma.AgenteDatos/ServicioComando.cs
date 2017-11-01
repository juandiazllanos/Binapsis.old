using Binapsis.Plataforma.AgenteDatos.Helper;
using Binapsis.Plataforma.Estructura;

using System.Collections.Generic;

namespace Binapsis.Plataforma.AgenteDatos
{
    public class ServicioComando
    {
        string _url;
        string _contexto;
        IFabrica _fabrica;

        public ServicioComando(string url, string contexto, IFabrica fabrica)
        {
            _url = url;
            _contexto = contexto;
            _fabrica = fabrica;
        }

        public IColeccion EjecutarConsulta(ITipo consulta)
        {
            ComandoHelper helper = new ComandoHelper(_url, _contexto);
            return helper.EjecutarConsulta(_fabrica, consulta);
        }

        public IColeccion EjecutarConsulta(ITipo consulta, IDictionary<string, object> parametros)
        {
            ComandoHelper helper = new ComandoHelper(_url, _contexto);
            return helper.EjecutarConsulta(_fabrica, consulta, parametros);
        }

        public IObjetoDatos EjecutarComando(ITipo comando)
        {
            ComandoHelper helper = new ComandoHelper(_url, _contexto);
            return helper.EjecutarComando(_fabrica, comando);
        }

        public IObjetoDatos EjecutarComando(ITipo comando, IDictionary<string, object> parametros)
        {
            ComandoHelper helper = new ComandoHelper(_url, _contexto);
            return helper.EjecutarComando(_fabrica, comando, parametros);
        }

        public void EjecutarComando(string comando)
        {
            ComandoHelper helper = new ComandoHelper(_url, _contexto);
            helper.EjecutarComando(comando);
        }

        public void EjecutarComando(string comando, IDictionary<string, object> parametros)
        {
            ComandoHelper helper = new ComandoHelper(_url, _contexto);
            helper.EjecutarComando(comando, parametros);
        }

    }
}
