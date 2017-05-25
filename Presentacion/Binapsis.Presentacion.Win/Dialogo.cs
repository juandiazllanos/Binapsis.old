using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.Win
{
    public class Dialogo : IDialogo
    {
        EditorObjeto _editor;
        TerminarHandler _terminar;
        FormDialogo _form;

        public Dialogo()
        {
            _form = new FormDialogo();
            _form.ConfirmarDialogo = true;
        }

        private void EstablecerEditor(EditorObjeto editor)
        {
            _form.Editor = editor;
            _editor = editor;
        }

        public void Mostrar()
        {
            _form.Mostrar();
            Resultado = _form.Resultado;
        }

        public void Mostrar(TerminarHandler terminar)
        {
            _terminar = terminar;
            _form.Mostrar(Terminar);
        }

        private void Terminar(FormDialogo form)
        {
            Resultado = form.Resultado;
            _terminar?.Invoke(this);
        }

        public EditorObjeto Editor
        {
            get => _editor;
            set => EstablecerEditor(value);
        }

        public ResultadoDialogo Resultado
        {
            get;
            private set;
        }
    }
}
