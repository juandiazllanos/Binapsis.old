using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Binapsis.Presentacion.Win.Estilos
{
    internal class FabricaEstilo
    {
        public EstiloBase Crear(Estilo estilo)
        {
            EstiloBase estiloBase = null;

            switch (estilo)
            {
                case Estilo.CheckEdit:
                    estiloBase = new EstiloBase(new RepositoryItemCheckEdit());
                    break;
                case Estilo.DateEdit:
                    estiloBase = new EstiloText(new RepositoryItemDateEdit());
                    break;
                case Estilo.DecimalEdit:
                    estiloBase = new EstiloText(new RepositoryItemTextEdit()) { MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric, EditMask = "n" };
                    break;
                case Estilo.EnumeracionEdit:
                    estiloBase = new EstiloText(new RepositoryItemComboBox() { TextEditStyle = TextEditStyles.DisableTextEditor });
                    break;
                case Estilo.IntegerEdit:
                    estiloBase = new EstiloText(new RepositoryItemTextEdit()) { MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric, EditMask = "d" };
                    break;
                case Estilo.TextSimpleEdit:
                    estiloBase = new EstiloText(new RepositoryItemTextEdit());
                    break;
                case Estilo.TextMemoEdit:
                    estiloBase = new EstiloText(new RepositoryItemMemoEdit());
                    break;
                case Estilo.TimeEdit:
                    estiloBase = new EstiloText(new RepositoryItemTimeEdit());
                    break;

                    
                case Estilo.ButtonEdit:
                    estiloBase = new EstiloButton(new RepositoryItemButtonEdit() { TextEditStyle = TextEditStyles.HideTextEditor });
                    break;
                case Estilo.DateButtonEdit:
                    estiloBase = new EstiloButton(new RepositoryItemDateEdit());
                    break;
                case Estilo.DecimalButtonEdit:
                    estiloBase = new EstiloButton(new RepositoryItemTextEdit()) { MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric, EditMask = "n" };
                    break;
                case Estilo.IntegerButtonEdit:
                    estiloBase = new EstiloButton(new RepositoryItemTextEdit()) { MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric, EditMask = "d" };
                    break;
                case Estilo.TextButtonEdit:
                    estiloBase = new EstiloButton(new RepositoryItemButtonEdit());
                    break;
                case Estilo.TimeButtonEdit:
                    estiloBase = new EstiloButton(new RepositoryItemTimeEdit());
                    break;

            }

            return estiloBase;
        }

        public EstiloEditorBase CrearEditor(Estilo estilo)
        {
            EstiloBase estiloBase = Crear(estilo);
            EstiloEditorBase estiloEditor = null;
            
            switch (estilo)
            {
                case Estilo.CheckEdit:
                    estiloEditor = new EstiloEditorCheckEdit(estiloBase);
                    break;
                case Estilo.TextMemoEdit:
                    estiloEditor = new EstiloEditorTextMemoEdit(estiloBase);
                    break;
                case Estilo.DateEdit:
                case Estilo.DecimalEdit:
                case Estilo.EnumeracionEdit:
                case Estilo.IntegerEdit:
                case Estilo.TextSimpleEdit:
                case Estilo.TimeEdit:
                    estiloEditor = new EstiloEditorText(estiloBase);                
                    break;


                
                case Estilo.DateButtonEdit:                    
                case Estilo.DecimalButtonEdit:
                case Estilo.EnumeracionButtonEdit:
                case Estilo.IntegerButtonEdit:
                case Estilo.TextButtonEdit:
                case Estilo.TimeButtonEdit:                
                    estiloEditor = new EstiloEditorButton(estiloBase);
                    break;

            }

            return estiloEditor;
        }

        public static FabricaEstilo Instancia { get; } = new FabricaEstilo();
    }
}
