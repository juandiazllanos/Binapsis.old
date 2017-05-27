namespace Binapsis.Presentacion.Editores
{
    public interface IDialogo
    {
        void Mostrar();
        void Mostrar(TerminarHandler terminar);
                
        ResultadoDialogo Resultado { get; }
    }
}
