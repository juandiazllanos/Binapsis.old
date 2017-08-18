namespace Binapsis.Plataforma.Configuracion.Presentacion.Actividades
{
    public class Mostrar : Actividad, IResultado
    {
        public Mostrar(string vista)
        {
            Vista = vista;
        }

        public override void Iniciar()
        {            
            ConfiguracionBase instancia = Parametros["instancia"] as ConfiguracionBase;
            IVista vista = Contexto.ObtenerFabrica(Vista)?.Crear() as IVista;

            if (vista != null && instancia != null)
            {
                vista.Resultado = this;
                vista.Mostrar(instancia);
            }                
            else
                Cancelar();
        }

        protected string Vista
        {
            get;
        }


        #region IResultado
        void IResultado.Cancelar()
        {
            Cancelar();
        }

        void IResultado.OK()
        {
            Terminar();
        }

        void IResultado.OK(object resultado)
        {
            Terminar();
        }
        #endregion
    }
}
