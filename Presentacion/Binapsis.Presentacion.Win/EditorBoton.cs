using Binapsis.Presentacion.Win.Diseñadores;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;

namespace Binapsis.Presentacion.Win
{
    public partial class EditorBoton : EditorBase
    {
        ButtonEdit _buttonEdit;
        Botones _botones = new Botones();

        public EditorBoton()
            : base()
        {
            InitializeComponent();    
        }
        
        protected override void EstablecerEditor(BaseEdit editor)
        {
            base.EstablecerEditor(editor);

            _botones = new Botones();

            if (editor != null && (editor.GetType().GetTypeInfo().IsSubclassOf(typeof(ButtonEdit)) || editor.GetType() == typeof(ButtonEdit)))
                _buttonEdit = (ButtonEdit)editor;

            if (_buttonEdit == null) return;
            
            // establecer botones
            _botones.ButtonCollection = _buttonEdit.Properties.Buttons;
            // asociar enter al primer boton
            _buttonEdit.KeyDown += (s, e) => { if (e.KeyCode == System.Windows.Forms.Keys.Enter) Invocar(); };
        }
        
        private void Invocar()
        {
            if (Botones.Count == 0) return;
            Botones[0].EditorButton.PerformClick();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditorBotones), typeof(UITypeEditor))]
        public Botones Botones
        {
            get { return _botones; }
        }
    }
}
