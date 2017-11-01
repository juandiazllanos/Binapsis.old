using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.ServicioDatos.Operaciones
{
    public class Consultar 
    {
        IConfiguracion _configuracion;
        IContexto _contexto;
        Comando _comando;
        ComandoHelper _comandoHelper;

        public Consultar(IContexto contexto, IConfiguracion configuracion, string consulta)
        {
            _configuracion = configuracion;
            _contexto = contexto;
            _comando = _configuracion.ObtenerComando(consulta);

            if (_comando == null) return;

            IDAS das = new DAS(configuracion, contexto);            
            IComando cmd = das.CrearComando(_comando);

            _comandoHelper = new ComandoHelper(cmd);
        }

        public void Establecer(string nombre, object valor)
        {
            _comandoHelper?.EstablecerParametro(nombre, valor);
        }

        public Coleccion EjecutarConsulta()
        {
            return _comandoHelper?.EjecutarConsulta() as Coleccion;
        }
        
    }
}
