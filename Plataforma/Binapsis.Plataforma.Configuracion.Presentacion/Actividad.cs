namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class Actividad
    {

        public const string RESULTADO_OK = "OK";
        public const string RESULTADO_CANCEL = "CANCEL";

        #region Metodos
        public virtual void Terminar()
        {
            Resultado = RESULTADO_OK;
            Operacion.Siguiente();
        }

        public virtual void Cancelar()
        {
            Resultado = RESULTADO_CANCEL;
            Operacion.Siguiente();
        }

        public virtual void Iniciar()
        {

        }
        #endregion


        #region Propiedades
        protected IContexto Contexto
        {
            get => Operacion?.Contexto;            
        }

        internal Operacion Operacion
        {
            get;
            set;
        }

        public Parametros Parametros
        {
            get => Operacion?.Parametros;
        }

        public string Resultado
        {
            get;
            set;
        }
        #endregion

    }
}