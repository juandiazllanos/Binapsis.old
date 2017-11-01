namespace Binapsis.Presentacion.Editores
{
    public interface IDialogo
    {
        void Mostrar();
        void Mostrar(TerminarHandler terminar);
        void Establecer(IEditorObjeto editorObjeto);
                
        ResultadoDialogo Resultado { get; }
    }
}
