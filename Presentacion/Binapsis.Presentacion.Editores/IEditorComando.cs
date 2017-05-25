namespace Binapsis.Presentacion.Editores
{
    public interface IEditorComando
    {
        event NotificarHandler Notificar;

        string Nombre { get; }
        void Habilitar();
        void Deshabilitar();
    }
}
