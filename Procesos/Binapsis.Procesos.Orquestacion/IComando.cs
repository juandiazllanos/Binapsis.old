namespace Binapsis.Procesos.Orquestacion
{
    public interface IComando
    {
        void Ejecutar();

        IParametros Parametros
        {
            get;
        }
    }
}
