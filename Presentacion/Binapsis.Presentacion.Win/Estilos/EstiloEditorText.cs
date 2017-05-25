using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace Binapsis.Presentacion.Win.Estilos
{
    internal class EstiloEditorText : EstiloEditorBase
    {
        TextEdit _textEdit;
        MaskProperties _mask;

        public EstiloEditorText(EstiloBase estilo) 
            : base(estilo)
        {
        }

        protected override void EstablecerEditor(BaseEdit editor)
        {
            base.EstablecerEditor(editor);
            _textEdit = (TextEdit)editor;
            _mask = Editor.Properties.Mask;
            _mask.UseMaskAsDisplayFormat = true;
        }

        public new TextEdit Editor
        {
            get { return _textEdit; }
        }
        
        public MaskType MaskType
        {
            get { return _mask.MaskType; }
            set { _mask.MaskType = value; }
        }

        public string EditMask
        {
            get { return _mask.EditMask; }
            set { _mask.EditMask = value; }
        }

    }
}
