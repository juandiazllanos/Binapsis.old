namespace Binapsis.Procesos.Orquestacion
{
    public class Comando : IComando
    {
        public Comando()
        {
            Parametros = new Parametros();
        }

        public virtual void Ejecutar()
        {

        }

        public Parametros Parametros
        {
            get;
        }

        #region IComando
        IParametros IComando.Parametros
        {
            get => Parametros;
        }

        void IComando.Ejecutar()
        {
            Ejecutar();
        }
        #endregion
    }
}
