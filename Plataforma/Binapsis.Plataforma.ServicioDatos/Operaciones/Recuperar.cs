using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Helper;

namespace Binapsis.Plataforma.ServicioDatos.Operaciones
{
    class Recuperar 
    {
        IConfiguracion _configuracion;
        IContexto _contexto;

        ComandoHelper _comandoHelper;
        //ITipo _tipo;

        #region Constructores        
        private Recuperar(IContexto contexto, IConfiguracion configuracion)
        {
            _contexto = contexto;
            _configuracion = configuracion;
        }

        public Recuperar(IContexto contexto, IConfiguracion configuracion, ITipo tipo)  
            : this(contexto, configuracion)
        {
            IDAS das = new DAS(_configuracion, _contexto);
            IComando comando = das.CrearComando(tipo);
            _comandoHelper = new ComandoHelper(comando);
        }

        public Recuperar(IContexto contexto, IConfiguracion configuracion, ITipo tipo, IPropiedad[] propiedades)
            : this(contexto, configuracion)
        {
            IDAS das = new DAS(_configuracion, _contexto);
            IComando comando = das.CrearComando(tipo, propiedades);
            _comandoHelper = new ComandoHelper(comando);
        }
        #endregion


        #region Metodos        
        public void Establecer(IPropiedad propiedad, object valor)
        {
            _comandoHelper.EstablecerParametro(propiedad, valor);
        }

        public void Establecer(string nombre, object valor)
        {
            _comandoHelper.EstablecerParametro(nombre, valor);
        }

        public void Establecer(int indice, object valor)
        {
            _comandoHelper.EstablecerParametro(indice, valor);
        }

        public void Establecer(ParametroHelper parametros)
        {
            parametros.Establecer(_comandoHelper);
        }

        public ObjetoDatos EjecutarConsultaSimple()
        {
            return _comandoHelper.EjecutarConsultaSimple() as ObjetoDatos;
        }

        public IColeccion EjecutarConsultaColeccion()
        {
            return _comandoHelper.EjecutarConsulta();
        }
        #endregion
        
    }
}
