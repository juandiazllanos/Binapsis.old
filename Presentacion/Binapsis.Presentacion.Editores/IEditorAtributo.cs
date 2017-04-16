namespace Binapsis.Presentacion.Editores
{

	public interface IEditorAtributo : IEditor
    {
        event NotificarHandler Notificar;
        object Valor { get; set; }
	}
}