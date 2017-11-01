using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.ServicioDatos.Operaciones
{
    class Ejecutar
    {
        IConfiguracion _configuracion;
        IContexto _contexto;
        Comando _comando;
        ComandoHelper _comandoHelper;

        public Ejecutar(IConfiguracion configuracion, IContexto contexto, string comando)
        {
            _configuracion = configuracion;
            _contexto = contexto;
            _comando = _configuracion.ObtenerComando(comando);

            if (_comando == null) return;

            IDAS das = new DAS(configuracion, contexto);
            IComando cmd = das.CrearComando(_comando);

            _comandoHelper = new ComandoHelper(cmd);
        }

        public object Obtener(string parametro)
        {
            return _comandoHelper?.ObtenerParametro(parametro);
        }

        public void Establecer(string nombre, object valor)
        {
            _comandoHelper?.EstablecerParametro(nombre, valor);
        }

        public void EjecutarComando()
        {
            _comandoHelper?.Ejecutar();
        }

        public Coleccion EjecutarConsulta()
        {
            return _comandoHelper?.EjecutarConsulta() as Coleccion;
        }

    }
}
