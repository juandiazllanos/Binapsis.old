namespace Binapsis.Presentacion.Editores
{
    public interface IEditorEnumeracion : IEditorAtributo
    {
        void Agregar(object valor, string texto);
        void Remover(object valor);
    }
}
