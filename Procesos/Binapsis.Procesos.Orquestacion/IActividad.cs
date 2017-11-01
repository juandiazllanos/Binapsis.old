namespace Binapsis.Procesos.Orquestacion
{
    public interface IActividad : IComando
    {
        //void Iniciar();
        //void Terminar();
        //void Cancelar();
        
        string Resultado
        {
            get;
        }
    }
}
