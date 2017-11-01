using Binapsis.Presentacion.Editores;
using System.Windows.Forms;

namespace Binapsis.Presentacion.Editores.Win
{
    public class Dialogo : IDialogo
    {
        UserControl _editor;
        TerminarHandler _terminar;
        FormDialogo _form;


        #region Constructores
        public Dialogo()
        {
            _form = new FormDialogo();
            _form.ConfirmarDialogo = true;
        }
        #endregion


        #region Metodos
        public void EstablecerEditor(IEditorObjeto editorObjeto)
        {
            if (editorObjeto is UserControl userControl)
                EstablecerEditor(userControl);
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
        #endregion


        #region Propiedades
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
        #endregion


        #region IDialogo
        void IDialogo.Mostrar()
        {
            Mostrar();
        }

        void IDialogo.Mostrar(TerminarHandler terminar)
        {
            Mostrar(terminar);
        }

        void IDialogo.Establecer(IEditorObjeto editorObjeto)
        {
            EstablecerEditor(editorObjeto);
        }

        ResultadoDialogo IDialogo.Resultado
        {
            get => Resultado;
        }
        #endregion

    }
}
