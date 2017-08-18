using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    public class Recuperar 
    {
        protected Recuperar(IContexto contexto)
        {
            Contexto = contexto;
            Configuracion = new ConfiguracionImpl(ConfiguracionRepositorio.Instancia);
        }

        public Recuperar(IContexto contexto, ITipo tipo)             
            : this (contexto)
        {            
            // crear comando
            IComando comando = CrearComando(tipo);
            ComandoHelper = new ComandoHelper(comando);
        }

        public Recuperar(IContexto contexto, string nombreComando)
            : this(contexto)
        {            
            // crear comando
            IComando comando = CrearComando(nombreComando);
            ComandoHelper = new ComandoHelper(comando);
        }

        public Recuperar(IContexto contexto, Comando comando)
            : this(contexto)
        {
            IComando cmd = CrearComando(comando);
            ComandoHelper = new ComandoHelper(cmd);
        }

        #region Metodos
        protected IComando CrearComando(string nombreComando)
        {
            IDAS das = new DAS(Configuracion, Contexto);
            IComando comando = das.ObtenerComando(nombreComando);
            return comando;
        }

        protected IComando CrearComando(Comando comando)
        {
            IDAS das = new DAS(Configuracion, Contexto);
            IComando cmd = das.CrearComando(comando);
            return cmd;
        }

        protected virtual IComando CrearComando(ITipo tipo)
        {
            IDAS das = new DAS(Configuracion, Contexto);
            IComando comando = das.CrearComando(tipo);
            return comando;
        }

        public void EstablecerParametro(IPropiedad propiedad, object valor)
        {
            ComandoHelper.EstablecerParametro(propiedad, valor);
        }

        public void EstablecerParametro(string nombre, object valor)
        {
            ComandoHelper.EstablecerParametro(nombre, valor);
        }

        public void EstablecerParametro(int indice, object valor)
        {
            ComandoHelper.EstablecerParametro(indice, valor);
        }

        public IObjetoDatos EjecutarConsultaSimple()
        {
            return ComandoHelper.EjecutarConsultaSimple();
        }

        public IColeccion EjecutarConsulta()
        {
            return ComandoHelper.EjecutarConsulta();
        }
        #endregion


        #region Propiedades
        protected ComandoHelper ComandoHelper
        {
            get;
        }

        private IConfiguracion Configuracion
        {
            get;
        }

        public IContexto Contexto
        {
            get;
        }

        public ITipo Tipo
        {
            get;
        }
        #endregion

    }
}
