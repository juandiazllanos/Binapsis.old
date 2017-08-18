using Binapsis.Presentacion.Editores;
using System.Windows.Forms;

namespace Binapsis.Presentacion.Win
{
    public class Dialogo : IDialogo
    {
        UserControl _editor;
        TerminarHandler _terminar;
        FormDialogo _form;

        public Dialogo()
        {
            _form = new FormDialogo();
            _form.ConfirmarDialogo = true;
        }

        private void EstablecerEditor(UserControl editor)
        {
            _form.Editor = editor;
            _editor = editor;
        }

        public void Mostrar()
        {
            _form.ConfirmarDialogo = ConfirmarDialogo;
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

        public void Cerrar(ResultadoDialogo resultado)
        {
            _form.Cerrar(resultado);
        }

        public UserControl Editor
        {
            get => _editor;
            set => EstablecerEditor(value);
        }

        public ResultadoDialogo Resultado
        {
            get;
            private set;
        }

        public bool ConfirmarDialogo
        {
            get;
            set;
        }
    }
}
