using DevExpress.XtraEditors;

namespace Binapsis.Presentacion.Editores.Win.Estilos
{
    internal class EstiloEditorButton : EstiloEditorText
    {
        ButtonEdit _buttonEdit;

        public EstiloEditorButton(EstiloBase estilo) 
            : base(estilo)
        {
        }

        protected override void EstablecerEditor(BaseEdit editor)
        {
            base.EstablecerEditor(editor);
            _buttonEdit = (ButtonEdit)editor;
        }

        public new ButtonEdit Editor
        {
            get { return _buttonEdit; }
        }


    }
}
