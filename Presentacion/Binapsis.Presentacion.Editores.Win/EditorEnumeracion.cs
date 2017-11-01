using Binapsis.Presentacion.Editores;
using DevExpress.XtraEditors;
using System.ComponentModel;

namespace Binapsis.Presentacion.Editores.Win
{
    [ToolboxItem(true)]
    public partial class EditorEnumeracion : EditorBase, IEditorEnumeracion
    {
        public EditorEnumeracion()
        {
            InitializeComponent();
        }
        protected override void Inicializar()
        {
            Estilo = Estilo.EnumeracionEdit;
        }

        void IEditorEnumeracion.Agregar(object valor, string texto)
        {
            ComboBoxEdit comboBox = (Editor as ComboBoxEdit);
            if (comboBox == null) return;

            comboBox.Properties.Items.Add(valor);
        }

        void IEditorEnumeracion.Remover(object valor)
        {
            
        }
    }
}
