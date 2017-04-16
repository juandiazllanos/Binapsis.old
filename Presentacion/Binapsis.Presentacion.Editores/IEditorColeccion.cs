namespace Binapsis.Presentacion.Editores
{
	public interface IEditorColeccion : IEditor
    {
		IEditorFila Crear();
		void Remover(IEditorFila fila);
		void RemoverTodo();
	}
}