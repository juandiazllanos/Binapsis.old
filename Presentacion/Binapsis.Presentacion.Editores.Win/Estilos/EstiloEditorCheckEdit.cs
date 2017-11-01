using DevExpress.XtraEditors;

namespace Binapsis.Presentacion.Editores.Win.Estilos
{
    internal class EstiloEditorCheckEdit : EstiloEditorBase
    {
        CheckEdit _editor;

        public EstiloEditorCheckEdit(EstiloBase estilo) 
            : base(estilo)
        {
        }

        protected override void EstablecerEditor(BaseEdit editor)
        {
            base.EstablecerEditor(editor);
            _editor = (CheckEdit)editor;
        }

        public override int MaximoAlto
        {
            get {  return 0; }
        }
    }
}
