using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    class ContextoUpdate : ContextoBase
    {
        public ContextoUpdate(IContexto contexto) 
            : base(contexto)
        {            
        }


        #region Metodos
        public override void EjecutarComando(IComando comando)
        {
            if (comando is ComandoTabla comandoTabla && 
                comandoTabla.ComandoTipo == ComandoTipo.UPDATE && 
                comandoTabla.Tabla.Nombre == Tabla.Nombre)
                EjecutarComando(comandoTabla);
            else 
                base.EjecutarComando(comando);
        }

        private void EjecutarComando(ComandoTabla comandoTabla)
        {
            Comando comando = Fabrica.Instancia.Crear<Comando>();
            BuilderComandoUpdate builder = new BuilderComandoUpdate(comando);
            builder.Construir(comandoTabla);

            ComandoBase comandoUpdate = new ComandoBase(comando);

            foreach (ParametroComando parametroComando in comandoTabla.Parametros)
                comandoUpdate.EstablecerParametro(parametroComando.Nombre, parametroComando.Valor);

            comandoUpdate.EstablecerParametro("clave", Clave);

            base.EjecutarComando(comandoUpdate);
        }

        //public override IClave ObtenerClave(ITipo tipo)
        //{
        //    if (Antiguo == null)
        //        return base.ObtenerClave(tipo);
        //    else
        //        return new ClaveAntiguo(tipo, Antiguo);
        //}
        #endregion


        #region Propiedades
        public IObjetoDatos Antiguo
        {
            get;
            set;
        }

        public string Clave
        {
            get;
            set;
        }

        public Tabla Tabla
        {
            get;
            set;
        }
        #endregion

    }
}
